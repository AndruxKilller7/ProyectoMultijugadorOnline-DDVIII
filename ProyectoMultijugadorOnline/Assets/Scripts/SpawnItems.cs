using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnItems : NetworkBehaviour
{

    public GameObject[] items;
    [SyncVar]public float tiempoDeSpawn;
    [SyncVar]public float contadorDeTiempo;

    void Start()
    {
        
    }

   
    void Update()
    {
        SpawnStart();
    }

    public void SpawnStart()
    {
        contadorDeTiempo += 0.1f * Time.deltaTime;
        if(contadorDeTiempo>=tiempoDeSpawn)
        {
          
            InstanciarItem();
            contadorDeTiempo = 0.0f;
        }
    }

  
  
    [ClientRpc]
    public void InstanciarItem()
    {
         Instantiate(items[Random.Range(0, 2)], new Vector3(Random.Range(transform.position.x + 7, transform.position.x - 7), Random.Range(transform.position.y + 5, transform.position.y + 7), transform.position.z), transform.rotation);
        //NetworkServer.Spawn(itemsS);
       

    }
}
