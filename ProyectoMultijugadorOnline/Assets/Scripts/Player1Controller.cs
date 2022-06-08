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
    void Start()
    {
       

        
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
            Destroy(this.gameObject);
            Time.timeScale = 0;
            GameOver();


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

    [ClientRpc]
    public void ControlDeBarra()
    {
        anim.SetTrigger("Hit");


        //barlife.fillAmount = vida / 100f;

    }



    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            vida -= 5f;
            ControlDeBarra();
            PruebaControlDeBarra(vida,idPlayerShip);
        }
    }
}
