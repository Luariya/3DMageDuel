using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;
    private int currentHearts2;
    public GameObject gameOver;
    public GameObject Victory;

    private void Start()
    {
        currentHearts = maxHearts;
        currentHearts2 = maxHearts;

        GameObject canvasGameObject = GameObject.Find("Canvas");
        if (canvasGameObject != null)
        {
            // Reference the GameObject in the Canvas
            gameOver = canvasGameObject.transform.Find("gameOverScreen").gameObject;
        }
    }

    public void DecreaseHearts()
    {
        currentHearts--;

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    public void DecreaseHearts2()
    {
        currentHearts2--;

        if (currentHearts2 <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
    }
}
