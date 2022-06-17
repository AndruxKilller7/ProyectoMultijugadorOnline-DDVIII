using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class StartGameScript : NetworkBehaviour
{
    public Text contador;
    [SyncVar]public int tiempoParaContinuar;
    [SyncVar] public float timeC;
    [SyncVar] public float tiempoMaximo;
    [SyncVar] public bool empezar;
    [SyncVar] public bool contadorF;
    [SyncVar] public bool startGame;
    void Start()
    {

    }


    void Update()
    {
        if(empezar)
        {
            ControlDeTexto();
        }
     
       
    }

    
    public void ContadorIniciado()
    {
        if (tiempoParaContinuar > 0&& contadorF==false)
        {
            timeC += 0.1f * Time.deltaTime;
            if (timeC >= tiempoMaximo)
            {
                TextUpdater();
                timeC = 0.0f;
            }
            if (tiempoParaContinuar <= 0)
            {
                contadorF = true;
                startGame = true;
                TextFight();
                timeC = 0.0f;
                Destroy(this.gameObject, 1f);

            }

        }

    }

   
    public void ControlDeTexto()
    {
        if (startGame==false)
        {
            if (contadorF == false)
            {
                TextoNum();
            }
            else
            {
                TextFight();
            }

            ContadorIniciado();
        }
    }

    [ClientRpc]
    public void TextoNum()
    {
        contador.text = tiempoParaContinuar.ToString();
    }

    [ClientRpc]
    public void TextFight()
    {
        contador.text = "FIGHT";
    }

    //[ClientRpc]
    public void TextUpdater()
    {
        tiempoParaContinuar -= 1;
    }
    
}
