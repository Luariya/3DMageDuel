using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (photonView.IsMine)
            {
                GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
                PlayerMovement playerMovement = playerObj.GetComponent<PlayerMovement>();
                playerMovement.SetupPlayer(photonView.Owner);
            }
        }
    }
}