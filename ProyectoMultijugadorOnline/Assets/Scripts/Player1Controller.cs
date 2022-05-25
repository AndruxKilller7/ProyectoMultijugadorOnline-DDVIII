using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player1Controller : MonoBehaviour
{
    public Image barlife;
    public float vida;
    public GameObject panelGameOver;
    void Start()
    {
        barlife = GameObject.Find("LifeBarP1").GetComponent<Image>();
    }

   
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100f);
        barlife.fillAmount = vida / 100f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            vida -= 5f;
        }
    }
}
