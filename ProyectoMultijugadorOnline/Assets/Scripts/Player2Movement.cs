using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player2Movement : MonoBehaviour
{
    public float velocidad;
    public float velocidadDeRotacion;



    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.forward * velocidadDeRotacion * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.back * velocidadDeRotacion * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
    }
}
