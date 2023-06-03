using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Not connected to Photon server.");
        }
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            // Both players have joined the room
            Debug.Log("Both players have joined the room.");
            // Implement any game logic or scene transitions here
        }
    }
}