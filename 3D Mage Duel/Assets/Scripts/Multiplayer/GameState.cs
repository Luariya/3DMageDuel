using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameState : MonoBehaviourPunCallbacks
{
    public GameObject victory;
    public GameObject gameOver;
    private PhotonView view;

    private bool isGameOver = false;

    private void Start()
    {
        victory.SetActive(false);
        gameOver.SetActive(false);
    }

    [PunRPC]

    private void Update()
    {
        if (gameOver.activeInHierarchy)
        {
            SetGameOverRPC();
        }

        if (isGameOver)
        {
            if (view.IsMine)
            {
                gameOver.SetActive(true);
            }
            
            if (!view.IsMine) 
            {
                victory.SetActive(true);
            }
        }
    }

    [PunRPC]
    public void SetGameOverRPC()
    {
        isGameOver = true;
    }

    public void SetGameOver()
    {
        photonView.RPC("SetGameOverRPC", RpcTarget.All);
    }
}