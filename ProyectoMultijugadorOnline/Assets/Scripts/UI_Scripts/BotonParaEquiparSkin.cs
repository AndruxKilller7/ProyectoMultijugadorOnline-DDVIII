using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonParaEquiparSkin : MonoBehaviour
{
    public int id;
    void Start()
    {
        GameManager.instance.idSkinEquip = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquiparSkin()
    {
        GameManager.instance.equipado[id-1] = true;
        GameManager.instance.idSkinEquip = id - 1;
        Debug.Log(GameManager.instance.idSkinEquip);
    }
}
