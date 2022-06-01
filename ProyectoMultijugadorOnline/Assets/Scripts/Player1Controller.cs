using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class Player1Controller : NetworkBehaviour
{
    public Image barlife;
    [SyncVar] public float vida;
    public GameObject panelGameOver;
    void Start()
    {
        //barlife = GameObject.Find("LifeBarP1").GetComponent<Image>();
    }

   
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100f);
        
        ControlDeVida();
    }


    public void ControlDeVida()
    {
        if(vida<=0.0f)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
            
        }
    }

    [ClientRpc]
    public void ControlDeBarra(float vida)
    {
        barlife.fillAmount = vida / 100f;

    }

    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            vida -= 5f;
            ControlDeBarra(vida);
        }
    }
}
