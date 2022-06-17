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
    public Skin[] costos;
    
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
        if (controlDeServicio.moneyPlayer >= skinsDispobibles.skins[idSkin-1].value && skinsDispobibles.skins[idSkin - 1].disponible)
        {
            StartCoroutine(BuySkin("http://localhost:8242/api/playerSkins", idSkin));
            skinsDispobibles.skins[idSkin - 1].disponible= false;
            StartCoroutine(PutSkin("http://localhost:8242/api/skins/" + idSkin, skinsDispobibles.skins[idSkin - 1].id, skinsDispobibles.skins[idSkin - 1].value, skinsDispobibles.skins[idSkin - 1].code, skinsDispobibles.skins[idSkin - 1].disponible, skinsDispobibles.skins[idSkin - 1].name));
            //controlDeServicio.moneyPlayer -= skinsDispobibles.skins[idSkin - 1].value;
           
        }
        if(controlDeServicio.moneyPlayer < skinsDispobibles.skins[idSkin - 1].value)
        {
            Debug.Log("No tienes monedasSuficientes");
        }

        if(skinsDispobibles.skins[idSkin - 1].disponible==false)
        {
            Debug.Log("Skin No disponible");
        }

        //StartCoroutine(PutCoins("http://localhost:8242/api/players/"));





    }

    public void ActualizarSkin(GameObject boton)
    {

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
                 
                    controlDeServicio.moneyPlayer = controlDeServicio.moneyPlayer- skinsDispobibles.skins[id - 1].value;
                    
                    controlDeServicio.ComprarSkin();
                    

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
                    costos = new Skin[skinsDispobibles.skins.Length];
                    GameManager.instance.skinsDisponibles= skinsDispobibles.skins;
                    for (int i=0;i<skinsDispobibles.skins.Length;i++)
                    {
                        Debug.Log(skinsDispobibles.skins[i].value);
                        costos[i] = skinsDispobibles.skins[i];
                      
                        
                        
                    }
                    

              


                    break;
            }
        }
    }



    IEnumerator PutSkin(string url,int idSkin,int value, string code, bool disp, string name)
    {

       
        string json = "{\"Id\":" + idSkin + ", \"Name\":'" + name + "', \"Code\":'" + code + "', \"Value\":'" + value + "', \"Disponible\":'" + disp + "' }";
        Debug.Log(json);
        byte[] body = Encoding.UTF8.GetBytes(json);


        using (UnityWebRequest webrequest = UnityWebRequest.Put(url, body))
        {
            webrequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
            webrequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webrequest.SetRequestHeader("Content-Type", "application/json");
            yield return webrequest.SendWebRequest();
            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:

                    Debug.Log("SkinActualizada");
                 

                    break;
            }
        }
    }










}
