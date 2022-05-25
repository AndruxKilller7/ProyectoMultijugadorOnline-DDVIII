using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player1Movement : NetworkBehaviour
{
    public float velocidad;
    public float velocidadDeRotacion;
   

    
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * velocidadDeRotacion * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * velocidadDeRotacion * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
    }
}
