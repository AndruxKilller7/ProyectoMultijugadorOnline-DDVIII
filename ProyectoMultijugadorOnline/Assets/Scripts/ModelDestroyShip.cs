using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDestroyShip : MonoBehaviour
{
    Rigidbody rbCube;
    void Start()
    {
        rbCube = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        rbCube.AddForce(Vector3.right * 4f, ForceMode.Force);  
    }
}
