using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float velociadad;
    public GameObject particles;
    
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velociadad * Time.deltaTime);
    }

   
   private void OnCollisionEnter(Collision other) 
   {
       if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("PERRO FEO");
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

   
}
