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
    public Text coinsUpdate;
    void Start()
    {
       
        Debug.Log("ID_PLAYER:" + idPlayer);
       
    }


    void Update()
    {
        idPlayer = GameManager.instance.playerData.id;
        coinsUpdate.text = GameManager.instance.playerData.money.ToString();
        moneyPlayer = GameManager.instance.playerData.money;
    }

    public void ComprarDinero(int valorDeDinero)
    {
        valorDeDinero = valorDeDinero + moneyPlayer;
        moneyPlayer = valorDeDinero;
        Debug.Log("Money:" + moneyPlayer);
       
        StartCoroutine(PutPlayer("http://localhost:8242/api/players/" + idPlayer));
       
        //coinsUpdate.text = GameManager.instance.playerData.money.ToString();
        

    }

    public void ComprarSkin()
    {
        StartCoroutine(PutPlayer("http://localhost:8242/api/players/" + idPlayer));
    }

    public void ActualizarValores()
    {
        StartCoroutine(GetRequestPlayer("http://localhost:8242/api/players/" + idPlayer));
        

    }


    IEnumerator PutPlayer(string url)
    {

        string money = moneyPlayer.ToString();
        //string nick = "sad";
        string name = "bger";
        //string json = "{\"Id\":" + idPlayer.ToString() + ", \"money\":'" + moneyPlayer.ToString() + "' }";
        string json = "{\"Id\":" + idPlayer + ", \"NickName\":'" + name + "', \"Money\":'" + money + "' }";
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
                    ActualizarValores();

                    break;
            }
        }
    }

    IEnumerator GetRequestPlayer(string url)
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
                    print(webrequest.downloadHandler.text);


                    Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    GameManager.instance.playerData = player;
                    //Debug.Log("Actualizado" + GameManager.instance.playerData.money);
                
                    break;
            }
        }
    }
}
