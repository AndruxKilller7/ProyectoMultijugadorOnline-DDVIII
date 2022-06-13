using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;


public class SkinSystem : MonoBehaviour
{
    Skins skinsDispobibles;
    GameObject[] contenedorDeSkins;
    public GameObject contenedor;
    public GameObject padre;
    //ComprarSkins controller;
    //public Text[] tectoPersonaje;
    //public GameObject[] pruebas;
    void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8242/api/skins"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void botonDeActivasion()
    {
      

    }

    IEnumerator GetRequest(string url)
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
                    contenedorDeSkins = new GameObject[skinsDispobibles.skins.Length];
                    //tectoPersonaje = new Text[skinsDispobibles.skins.Length];
                    Debug.Log(skinsDispobibles.skins.Length);
                    Debug.Log(contenedorDeSkins.Length);
                    //pruebas = new GameObject[contenedorDeSkins.Length];
                    for (int i = 0; i < skinsDispobibles.skins.Length; i++)
                    {
                        contenedorDeSkins[i] = contenedor;
                        contenedorDeSkins[i].GetComponent<SkinContainer>().nameSkin.text = skinsDispobibles.skins[i].name;
                        contenedorDeSkins[i].GetComponent<SkinContainer>().value.text = skinsDispobibles.skins[i].value.ToString();
                        contenedorDeSkins[i].GetComponent<SkinContainer>().imageSkin.sprite = Resources.Load<Sprite>("Skin" + skinsDispobibles.skins[i].id);
                        contenedorDeSkins[i].GetComponent<SkinContainer>().botonDeCompra.GetComponent<Botones>().id = skinsDispobibles.skins[i].id;
                        //Debug.Log(i);
                        //contenedorDeSkins[i].GetComponent<Botones>().id = skinsDispobibles.skins[i].id;

                        Instantiate(contenedorDeSkins[i], padre.transform.position, transform.rotation, padre.transform);

                    }


                    break;
            }
        }
    }
}
