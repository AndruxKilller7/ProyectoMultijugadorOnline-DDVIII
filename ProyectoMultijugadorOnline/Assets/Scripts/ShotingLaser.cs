using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingLaser : MonoBehaviour
{
    public GameObject laser;
    public Transform pivotLaser;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(laser, pivotLaser.position, transform.rotation);
        }
    }
}
