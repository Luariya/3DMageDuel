using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Play()
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
            PhotonNetwork.JoinOrCreateRoom("MyRoom", roomOptions, TypedLobby.Default);
        }
        else
        {
            Debug.Log("Not connected to Photon Network");
        }
    }

    public void LeaveRoomAndLoadScene()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            Debug.Log("Left room");
        }
        else
        {
            Debug.Log("Not currently in a room");
        }

        SceneManager.LoadScene("StartScreen"); 
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}