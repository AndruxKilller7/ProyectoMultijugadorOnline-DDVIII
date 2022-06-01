using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class BarraDeVida : NetworkBehaviour
{
    public Image barra;
    Player1Controller playerControl;
    void Start()
    {
        barra = GetComponent<Image>();
        
    }

    
    void Update()
    {
        
    }
}
