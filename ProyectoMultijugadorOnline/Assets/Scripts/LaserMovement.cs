using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LaserMovement : NetworkBehaviour
{
    public float velociadad;
    public GameObject particles;
    
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * velociadad * Time.deltaTime);
    }

   
   [ServerCallback]
   private void OnCollisionEnter(Collision other) 
   {
       if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("PERRO FEO");
            GameObject par= Instantiate(particles, transform.position, transform.rotation);
            NetworkServer.Spawn(par);
            Destroy(this.gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }

   
}
