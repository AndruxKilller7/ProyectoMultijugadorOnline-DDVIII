using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroyEffects : NetworkBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 3f);
        
    }

   
    void Update()
    {
        
    }
}
