using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPosition;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Instantiate the player prefab with ownership
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition.position, Quaternion.identity, 0);
        }
    }
}