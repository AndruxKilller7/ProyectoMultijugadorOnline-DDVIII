using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerGame : NetworkManager
{
    public Transform pivotPlayer1;
    public Transform pivotPlayer2;
    public GameObject startSystem;
   
  
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
       
        Transform start = numPlayers == 0 ? pivotPlayer1 : pivotPlayer2;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        player.GetComponent<Player1Controller>().idPlayerShip = numPlayers;
        player.GetComponent<Player1Controller>().seleccionado = GameManager.instance.idSkinEquip;
        //player.GetComponent<Player1Movement>().enabled = false;
        //player.GetComponent<ShotingLaser>().enabled = false;
       
       
        NetworkServer.AddPlayerForConnection(conn, player);

        print("sdasd");
       


        if (numPlayers==2)
        {
            startSystem.GetComponent<StartGameScript>().empezar = true;
            
        }

    }



   
}
