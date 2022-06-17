using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ShotingLaser : NetworkBehaviour
{
    public GameObject laser;
    public GameObject rocket;
    public Transform pivotLaser;
    public float fireRate;
    public float nextFire;
    [SyncVar]public bool activeRocket;
    [SyncVar] public bool activeShield;
    [SyncVar]public float timeCount;
    [SyncVar] public float timeCountS;
    public Transform[] pivotesRocket;
    public GameObject shield;
   

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            ShootRocket();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivarEscudo();
            activeRocket = true;
        }

        ContadorActive();
        ContadorEscudo();
    }

    [Command]
    public void Shoot()
    {
        if(activeRocket==false)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject laserF = Instantiate(laser, pivotLaser.position, transform.rotation);
                NetworkServer.Spawn(laserF);
            }
        }
       
      
    }

    [Command]
    public void ShootRocket()
    {
        if(activeRocket)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject rocketF = Instantiate(rocket, pivotesRocket[0].position, transform.rotation);
                NetworkServer.Spawn(rocketF);
                GameObject rocketH = Instantiate(rocket, pivotesRocket[1].position, transform.rotation);
                NetworkServer.Spawn(rocketH);
            }
        }
       
    }

    
    public void ContadorActive()
    {
        if (activeRocket)
        {
            timeCount = 0.0f;
            timeCount += 0.1f * Time.deltaTime;

        }

        if(timeCount>2f)
        {
            activeRocket = false;
            timeCount = 0.0f;
        }
    }

    public void ContadorEscudo()
    {
        if (activeShield)
        {

            timeCountS += 0.1f * Time.deltaTime;

        }

        if (timeCountS > 2f)
        {
            shield.SetActive(false);
            activeShield = false;
            timeCountS = 0.0f;
        }
    }

    [Command]
    public void ActivarEscudo()
    {
        if(activeShield)
        {
            shield.SetActive(true);
        }
        
    }


    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ItemR"))
        {
            activeShield = true;
        
        }
    }
   
}
