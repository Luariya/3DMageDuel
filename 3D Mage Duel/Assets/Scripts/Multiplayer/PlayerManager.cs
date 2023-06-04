using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab1; // Reference to the first player prefab in the scene
    public GameObject playerPrefab2; // Reference to the second player prefab in the scene

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Check if this is the local player
            if (photonView.IsMine)
            {
                // Find the appropriate player prefab based on player index
                GameObject selectedPlayerPrefab;
                if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
                {
                    selectedPlayerPrefab = playerPrefab1;
                }
                else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
                {
                    selectedPlayerPrefab = playerPrefab2;
                }
                else
                {
                    Debug.LogError("Invalid player index");
                    return;
                }

                // Instantiate the player prefab and enable it
                GameObject playerObj = PhotonNetwork.Instantiate(selectedPlayerPrefab.name, transform.position, transform.rotation);
                playerObj.SetActive(true);
            }
        }
    }
}