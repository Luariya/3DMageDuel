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
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    private void Start()
    {
        currentHearts = maxHearts;
        currentHearts2 = maxHearts;
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
        gameOverScreen.SetActive(true);
    }
}
