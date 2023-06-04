using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Check if this is the local player
            if (photonView.IsMine)
            {
                // Instantiate the player prefab and enable it
                GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
                playerObj.SetActive(true);
            }
        }
    }
}