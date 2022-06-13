using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class ComprarSkins : MonoBehaviour
{
    WebRequest controlDeServicio;
    Skins skinsDispobibles;
    public float[] costos;
    void Start()
    {
        
        controlDeServicio = GameObject.Find("Main Camera").GetComponent<WebRequest>();
        Debug.Log("MoneyActual"+controlDeServicio.moneyPlayer);
        StartCoroutine(GetSkinsRequest("http://localhost:8242/api/skins"));




    }

    
    void Update()
    {

    }

   

    public void ComprarPersonajesButton(int idSkin)
    {
        Debug.Log(skinsDispobibles.skins[idSkin - 1].name);
        if (controlDeServicio.moneyPlayer >= skinsDispobibles.skins[idSkin-1].value)
        {
            StartCoroutine(BuySkin("http://localhost:8242/api/playerSkins", idSkin));
            //controlDeServicio.moneyPlayer -= skinsDispobibles.skins[idSkin - 1].value;
           
        }
        else
        {
            Debug.Log("No tienes monedasSuficientes");
        }

        //StartCoroutine(PutCoins("http://localhost:8242/api/players/"));





    }

    IEnumerator BuySkin(string url, int id)
    {

        WWWForm form = new WWWForm();
        form.AddField("Id",id );
        form.AddField("PlayerId", controlDeServicio.idPlayer);
        form.AddField("SkinId", id);

        using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
        {
            yield return webrequest.SendWebRequest();

            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    //error.text = "Error en el servidor";
                    break;
                case UnityWebRequest.Result.Success:
                    //OnButtonClickRefresh();
                    controlDeServicio.moneyPlayer = controlDeServicio.moneyPlayer- skinsDispobibles.skins[id - 1].value;
                   
                    //Debug.Log(controlDeServicio.moneyPlayer);
                    print("success");
                    //controlDeServicio.ActualizarValores();

                    break;

            };
        }
    }


    IEnumerator GetSkinsRequest(string url)
    {

        using (UnityWebRequest webrequest = UnityWebRequest.Get(url))
        {
            yield return webrequest.SendWebRequest();
            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    skinsDispobibles = JsonUtility.FromJson<Skins>("{\"skins\":" + webrequest.downloadHandler.text + "}");
                    for(int i=0;i<skinsDispobibles.skins.Length;i++)
                    {
                        Debug.Log(skinsDispobibles.skins[i].value);
                    }
                    

              


                    break;
            }
        }
    }

  












}
