using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Photon.Pun;

public class HealthManager : MonoBehaviourPunCallbacks
{
    public int maxHearts = 3;
    private int currentHearts;
    public GameObject gameOver;
    public GameObject Victory;
    private GameState gameState;

    private GameObject Heart1;
    private GameObject Heart2;
    private GameObject Heart3;

    private bool initialized;

    PhotonView view;

    private void Start()
    {

        gameState = FindObjectOfType<GameState>();

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
        Heart2 = this.transform.Find("Canvas/Heart 2").gameObject;
        Heart3 = this.transform.Find("Canvas/Heart 3").gameObject;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(Heart3);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(Heart2);
            }
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
        if (currentHearts < 3)
        {
            Destroy(Heart3);
        }
        if (currentHearts < 2)
        {
            Destroy(Heart2);
        }        
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
            if (currentHearts < 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
    }
}
