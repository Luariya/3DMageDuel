using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPun
{
    public GameObject playerPrefab;

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
            else
            {
                // Disable the PlayerManager script for remote players
                enabled = false;
            }
        }
    }
}