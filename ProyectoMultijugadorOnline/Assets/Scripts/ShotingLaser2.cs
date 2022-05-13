using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingLaser2 : MonoBehaviour
{
    public GameObject laser;
    public Transform pivotLaser;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, pivotLaser.position, transform.rotation);
        }
    }
}
