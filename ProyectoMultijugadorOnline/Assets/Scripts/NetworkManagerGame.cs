using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerGame : NetworkManager
{
    public Transform pivotPlayer1;
    public Transform pivotPlayer2;
    //public Image barlife1;
    //public Image barlife2;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        //Image barlifes = numPlayers == 0 ? barlife1 : barlife2;
        Transform start = numPlayers == 0 ? pivotPlayer1 : pivotPlayer2;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        player.GetComponent<Player1Controller>().idPlayerShip = numPlayers;
        NetworkServer.AddPlayerForConnection(conn, player);
       
        print("sdasd");
        //base.OnServerAddPlayer(conn);


    }


   
}
