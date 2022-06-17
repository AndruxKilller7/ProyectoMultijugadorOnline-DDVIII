using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Botones : MonoBehaviour
{
    ComprarSkins controller;
    public Image vendidoImage;
    public int id;
    public GameObject skinSystem;
   
    void Start()
    {
        controller = GameObject.Find("Main Camera").GetComponent<ComprarSkins>();
        
        if(controller.costos[id - 1].disponible==false)
        {
            skinSystem.GetComponent<SkinContainer>().vendidoImage.gameObject.SetActive(true);
        }
    }

  
    void Update()
    {
        
    }

    public void ComprarCharacter()
    {
        controller.ComprarPersonajesButton(id);
        
        if(GameManager.instance.playerData.money>=controller.costos[id-1].value)
        {
            skinSystem.GetComponent<SkinContainer>().vendidoImage.gameObject.SetActive(true);
        }
       
    }
}
