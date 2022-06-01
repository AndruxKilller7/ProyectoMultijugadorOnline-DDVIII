using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;



public class Player2Movement : NetworkBehaviour
{
    public float velocidad;
    public float velocidadDeRotacion;



    void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.2f, 9.2f), Mathf.Clamp(transform.position.y, -2f, 3.88f), transform.position.z);

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
