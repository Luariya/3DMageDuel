using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // Reference to the player prefab in the scene

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Check if this is the local player
            if (photonView.IsMine)
            {
                // Instantiate the player prefab and enable it
                GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
                playerObj.SetActive(true);
            }
        }
    }
}