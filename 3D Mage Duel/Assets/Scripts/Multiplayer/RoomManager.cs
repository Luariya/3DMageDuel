using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 2;
    public string MainScene = "NextScene";

    private bool isSceneChanging = false;

  
        void Start()
        {
            if (PhotonNetwork.IsConnectedAndReady)
            {
                // Join or create a room with the name "MyRoom"
                PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
            }
            else
            {
                Debug.Log("PhotonNetwork is not connected and ready");
            }
        }

        // Other methods and callbacks...
    

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers && PhotonNetwork.IsMasterClient && !isSceneChanging)
        {
            isSceneChanging = true;
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // You can add any necessary logic before changing the scene
        SceneManager.LoadScene("MainScene");
    }
}