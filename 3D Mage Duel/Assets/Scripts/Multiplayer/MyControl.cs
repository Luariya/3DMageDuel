using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyControl : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        Control();
    }

    [PunRPC]

    void Control()
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            // Enable player control script for the local player
            player.GetComponent<PlayerBewegung>().enabled = true;
        }
        else
        {
            // Disable player control script for other players
            player.GetComponent<PlayerBewegung>().enabled = false;
        }
    }
}
