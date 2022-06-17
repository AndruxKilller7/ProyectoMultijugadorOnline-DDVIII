using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public InputField emailLogin;
    public InputField passwordLogin;
    public Text errorText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGame()
    {
        StartCoroutine(PostLogin("http://localhost:8242/api/users/authenticate"));
    }

    IEnumerator PostLogin(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", emailLogin.text);
        form.AddField("Password", passwordLogin.text);
        using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
        {
            yield return webrequest.SendWebRequest();

            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorText.text = "Error en el servidor";
                    break;
                case UnityWebRequest.Result.Success:
                    if (webrequest.downloadHandler.text == "")
                    {
                        errorText.text = "El usuario o la contraseña son incorrectas";
                    }
                    else
                    {
                        //print(webrequest.downloadHandler.text);
                        Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                        GameManager.instance.playerData = player;
                        SceneManager.LoadScene(2);
                    }
                    break;

            };
        }
    }
}
