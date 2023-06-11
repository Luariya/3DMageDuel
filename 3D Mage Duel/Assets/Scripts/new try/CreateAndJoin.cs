using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    private const string PlayerTag = "Player"; // Tag for the player prefab

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        // Instantiate the player prefab
        GameObject player = PhotonNetwork.Instantiate("PlayerPrefab", Vector3.zero, Quaternion.identity);

        // Set the tag of the player prefab
        player.tag = PlayerTag;

        // Assign a unique identifier (e.g., player's PhotonNetwork.PlayerName) to the player prefab
        Player photonPlayer = PhotonNetwork.LocalPlayer;
        player.name = photonPlayer.NickName;

        PhotonNetwork.LoadLevel("MainScene");
        Debug.Log("Joined Room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room: " + message);
    }
}
