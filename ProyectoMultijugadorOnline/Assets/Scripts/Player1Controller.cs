using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;


public class Player1Controller : NetworkBehaviour
{
    public Image barlife;
    [SyncVar] public float vida=100.0f;
    public Animator anim;
    public int idPlayerShip;
    public GameObject modelShip;
    public Mesh[] skins;
    [SyncVar] public int seleccionado;
    
    void Start()
    {
       
       

        if (idPlayerShip == 0)
        {
            SkinSelect(seleccionado);
            //modelShip.GetComponent<Renderer>().materials[4].color = Color.red;


            DeterminarColor1();
        }

        if (idPlayerShip == 1)
        {

            //modelShip.GetComponent<Renderer>().materials[4].color = Color.blue;
            DeterminarColor2();


        }


    }


    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100.0f);
       
        ControlDeVida();

       
     }


    public void ControlDeVida()
    {
        if (vida <= 0.0f)
        {
            if(idPlayerShip==0)
            {
                Destroy(this.gameObject);
                GameManager.instance.playerEliminado = 1;
                GameOver();
            }

            if (idPlayerShip == 1)
            {
                Destroy(this.gameObject);
                GameManager.instance.playerEliminado = 2;
                GameOver();
            }

        }

        if (idPlayerShip == 0 && GameManager.instance.playerEliminado == 2)
        {
            Win();
        }

        if (idPlayerShip == 1 && GameManager.instance.playerEliminado == 1)
        {
            Win();
        }
    }

    [ClientRpc]
    public void PruebaControlDeBarra(float vida,int id)
    {


        barlife = GameObject.Find("LifeBarP" + id).GetComponent<Image>();
        barlife.fillAmount = (vida / 100.0f);

    }

    [TargetRpc]
    public void GameOver()
    {
        SceneManager.LoadScene(1);

    }

    [TargetRpc]
    public void Win()
    {
        SceneManager.LoadScene(3);

    }

    [ClientRpc]
    public void ControlDeBarra()
    {
        anim.SetTrigger("Hit");


        //barlife.fillAmount = vida / 100f;

    }

    [ClientRpc]
    public void DeterminarColor1()
    {
        modelShip.GetComponent<Renderer>().materials[4].color = Color.red;
        

    }

    [ClientRpc]
    public void DeterminarColor2()
    {
        modelShip.GetComponent<Renderer>().materials[4].color = Color.blue;
       

    }
   
    
  
   [ClientRpc]
    public void SkinSelect(int id)
    {

        Debug.Log(seleccionado);
        modelShip.GetComponent<MeshFilter>().mesh = skins[id];
    }
   
    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser")|| collision.gameObject.CompareTag("Rocket"))
        {
            vida -= 5f;
            ControlDeBarra();
            PruebaControlDeBarra(vida,idPlayerShip);
        }

        if (collision.gameObject.CompareTag("ItemS"))
        {
            vida += 3f;
            PruebaControlDeBarra(vida, idPlayerShip);

        }

    }

    
}
