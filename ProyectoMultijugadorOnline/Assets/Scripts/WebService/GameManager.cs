using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player playerData;
    public Skin[] skinsDisponibles;
    public bool[] equipado;
    public int idSkinEquip;
    public int playerEliminado;
    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
