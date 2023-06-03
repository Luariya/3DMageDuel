using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

  

    private bool isGameOver = false;


    // Call this method to trigger the game over screen
    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);

        }
    }
}