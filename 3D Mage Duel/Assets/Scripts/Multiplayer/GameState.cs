using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameState : MonoBehaviourPunCallbacks
{
    private GameObject victory;
    private GameObject gameOver;

    private bool isGameOver = false;

    private void Start()
    {
        // Disable victory and game over screens initially
        victory.SetActive(false);
        gameOver.SetActive(false);

        GameObject canvasGameObject = GameObject.Find("Canvas");
        if (canvasGameObject != null)
        {
            // Reference the GameObject in the Canvas
            gameOver = canvasGameObject.transform.Find("gameOverScreen").gameObject;
            victory = canvasGameObject.transform.Find("VictoryScreen").gameObject;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (photonView.IsMine)
            {
                // Show game over screen for the local player
                gameOver.SetActive(true);
            }
            
            if (!photonView.IsMine) 
            {
                // Show victory screen for the remote player
                victory.SetActive(true);
            }
        }

        SetGameOverRPC();

        SetGameOver();
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