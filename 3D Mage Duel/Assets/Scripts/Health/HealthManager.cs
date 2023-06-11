using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;
    public GameObject gameOver;
    public GameObject Victory;
    private GameState gameState;

    private GameObject Heart1;
    private GameObject Heart2;
    private GameObject Heart3;

    private void Start()
    {
        currentHearts = maxHearts;

        gameState = FindObjectOfType<GameState>();

        GameObject canvasGameObject = GameObject.Find("Canvas");
        if (canvasGameObject != null)
        {
            gameOver = canvasGameObject.transform.Find("gameOverScreen").gameObject;
            Victory = canvasGameObject.transform.Find("VictoryScreen").gameObject;
        }

        Heart1 = gameObject.transform.Find("Heart 1").gameObject;
        Heart2 = gameObject.transform.Find("Heart 2").gameObject;
        Heart3 = gameObject.transform.Find("Heart 3").gameObject;
    }

    private void Update()
    {
        switch (currentHearts)
        {
            case 0:
                {
                    Heart1.gameObject.SetActive(false);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    Debug.Log("0");
                    break;
                }
            case 1:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    Debug.Log("1");
                    break;

                }
            case 2:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(false);
                    Debug.Log("2");
                    break;
                }
            case 3:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(true);
                    Debug.Log("3");
                    break;
                }
        }
    }

    public void DecreaseHearts()
    {
        currentHearts--;

        if (currentHearts <= 0)
        {
            GameOver();
            gameState.SetGameOverRPC();
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
    }
}
