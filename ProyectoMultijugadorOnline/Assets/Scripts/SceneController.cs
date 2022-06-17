using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    
    void Start()
    {
       
    }

 
    void Update()
    {
        
    }


    public void ReiniciarEscena()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

}
