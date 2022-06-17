using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashoLaser : MonoBehaviour
{
    private LineRenderer line;
    public GameObject cubeParticle;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    
    }

   
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit,10f))
        {
            //line.SetPosition(1, new Vector3(0, 0, 10f));
            line.SetPosition(1, new Vector3(0, 0, hit.distance));
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            if (hit.collider.CompareTag("Player"))
            {
                Instantiate(cubeParticle, hit.collider.transform.position, transform.rotation);
            }
        }
       
        

   

       





    }
   
}
