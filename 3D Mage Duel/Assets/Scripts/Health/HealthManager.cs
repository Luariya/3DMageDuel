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

    public void DecreaseHearts()
    {
        currentHearts--;

        if (currentHearts == 2) 
        { 
            Heart3?.SetActive(false);
        }
        else if (currentHearts == 1)
        {
            Heart2?.SetActive(false);
        }
        else if(currentHearts == 0)
        {
            Heart1?.SetActive(false);
        }


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
