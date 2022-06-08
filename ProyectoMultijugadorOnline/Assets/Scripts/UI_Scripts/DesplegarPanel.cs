using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplegarPanel : MonoBehaviour
{
    public GameObject[] paneles;


    void Start()
    {
        
    }

   

    void Update()
    {
        
    }

    public void Desplegar(int id)
    {
        //paneles[id].SetActive(true);
        for(int i = 0; i < paneles.Length; i++)
        {
            paneles[i].SetActive(false);
            if(i==id)
            {
                paneles[i].SetActive(true);
            }
        }
       
    }

   




}
