using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerGame : NetworkManager
{
    public Transform pivotPlayer1;
    public Transform pivotPlayer2;
    

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        
        Transform start = numPlayers == 0 ? pivotPlayer1 : pivotPlayer2;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        print("sdasd");
        //base.OnServerAddPlayer(conn);

    }


   
}
