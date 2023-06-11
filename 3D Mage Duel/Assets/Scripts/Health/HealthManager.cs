using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Photon.Pun;

public class HealthManager : MonoBehaviourPunCallbacks
{
    public int maxHearts = 1;
    private int currentHearts;
    public GameObject gameOver;
    public GameObject Victory;

    private GameObject Heart1;

    private bool initialized;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        GameObject canvasGameObject = GameObject.Find("Canvas");
        if (canvasGameObject != null)
        {
            gameOver = canvasGameObject.transform.Find("gameOverScreen").gameObject;
            Victory = canvasGameObject.transform.Find("VictoryScreen").gameObject;
        }
        InitializeHearts();

        if (view.IsMine)
        {
            currentHearts = maxHearts;
        }
    }

    private void InitializeHearts()
    {
        if (!photonView.IsMine)
            return;

        initialized = true;

        GameObject Player = this.gameObject;

        Heart1 = this.transform.Find("Canvas/Heart 1").gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                photonView.RPC("DecreaseHearts", RpcTarget.All);
            }
        }
    }

    private void Update()
    {      
            if (!initialized && photonView.IsMine)
            {
                InitializeHearts();
            }      

        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Destroy(Heart1);
            }
        }

        DestroyHearts();
    }

    [PunRPC]
    public void DestroyHearts()
    {
        if (currentHearts < 1)
        {
            Destroy(Heart1);
        }        
    }

    [PunRPC]
    public void DecreaseHearts()
    {
        currentHearts--;

        if (view.IsMine)
        {
            if (currentHearts <= 0)
            {
                GameOver();
            }
        }
        if (!view.IsMine)
        {
            if (currentHearts <= 0)
            {
                Win();
            }
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
       PhotonNetwork.Destroy(Heart1);
    }

    private void Win()
    {
        Victory.SetActive(true);
        PhotonNetwork.Destroy(Heart1);
    }
}
