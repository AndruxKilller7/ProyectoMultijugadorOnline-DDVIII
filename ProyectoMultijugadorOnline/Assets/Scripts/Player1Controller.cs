using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;


public class Player1Controller : NetworkBehaviour
{
    public Image barlife;
    [SyncVar] public float vida=100f;
    public Animator anim;
    
    void Start()
    {
       

        
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
            GameOver();
           
            
        }
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
      
    }

   

    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            vida -= 5f;
            ControlDeBarra();
        }
    }
}
