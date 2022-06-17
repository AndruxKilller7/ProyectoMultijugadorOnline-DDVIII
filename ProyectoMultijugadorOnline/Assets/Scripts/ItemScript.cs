using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ItemScript : NetworkBehaviour
{
   
    void Start()
    {
        Destroy(this.gameObject, 7f);
       
    }

    
    void Update()
    {
      
    }

    [Server]
    public void DestroyLaser()
    {
        NetworkServer.Destroy(this.gameObject);
    }


    [ServerCallback]
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
            DestroyLaser();
        }
    }
}
