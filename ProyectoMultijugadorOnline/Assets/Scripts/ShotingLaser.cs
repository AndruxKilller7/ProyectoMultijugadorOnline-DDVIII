using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ShotingLaser : NetworkBehaviour
{
    public GameObject laser;
    public Transform pivotLaser;
    public float fireRate;
    public float nextFire;

   

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    [Command]
    public void Shoot()
    {
        if(Time.time>=nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject laserF = Instantiate(laser, pivotLaser.position, transform.rotation);
            NetworkServer.Spawn(laserF);
        }
      
    }
}
