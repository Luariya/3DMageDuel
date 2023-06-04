using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetWork_Manager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab1; // Reference to player prefab 1
    [SerializeField] private GameObject playerPrefab2; // Reference to player prefab 2

    private const string PlayerTagKey = "PlayerTag";

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        // Set the player tag for the local player before joining the room
        SetPlayerTag("Player1"); // Replace "Player1" with the desired tag for Player 1
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions());
    }

    public override void OnJoinedRoom()
    {
        // Check if the custom property exists and is set for the local player
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(PlayerTagKey, out object playerTagObj))
        {
            string playerTag = playerTagObj as string;

            // Instantiate the appropriate player prefab based on the player tag
            if (playerTag == "Player1")
            {
                Debug.Log("Player 1 joined. Tag: " + playerTag);
                PhotonNetwork.Instantiate(playerPrefab1.name, Vector3.zero, Quaternion.identity);
            }
            else if (playerTag == "Player2")
            {
                Debug.Log("Player 2 joined. Tag: " + playerTag);
                PhotonNetwork.Instantiate(playerPrefab2.name, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Invalid player tag: " + playerTag);
            }
        }
        else
        {
            Debug.LogError("Player tag not found in custom properties!");
        }
    }

    // Call this method to set the player tag for the local player
    private void SetPlayerTag(string tag)
    {
        Hashtable playerProps = new Hashtable();
        playerProps.Add(PlayerTagKey, tag);
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProps);
    }
}