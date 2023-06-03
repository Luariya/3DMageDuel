using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab1; // Prefab for player 1 character
    public GameObject playerPrefab2; // Prefab for player 2 character

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                // Instantiate the player character for player 1
                PhotonNetwork.Instantiate(playerPrefab1.name, Vector3.zero, Quaternion.identity);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsConnectedAndReady && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (newPlayer.IsLocal)
            {
                // Instantiate the player character for player 2
                PhotonNetwork.Instantiate(playerPrefab2.name, Vector3.zero, Quaternion.identity);
            }
        }
    }
}