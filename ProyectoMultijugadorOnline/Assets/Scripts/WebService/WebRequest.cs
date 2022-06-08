using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class WebRequest : MonoBehaviour
{
    public int moneyPlayer;
    public int idPlayer;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void ComprarDinero(int valorDeDinero)
    {
        moneyPlayer = valorDeDinero;
        StartCoroutine(PutPlayer("http://localhost:8242/api/players/"+idPlayer));
    }


    IEnumerator PutPlayer(string url)
    {
        //PlayerSkins players = JsonUtility.FromJson<PlayerSkins>("{\"playerSkins\":" + webrequest.downloadHandler.text + "}");
        string money = moneyPlayer.ToString();
        string name = "Jry";
        string json = "{\"Id\":" + idPlayer.ToString() + ", \"NickName\":'" + name + "', \"Money\":'" + money + "' }";
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

                    Debug.Log("CompraRealizada");


                    break;
            }
        }
    }
}
