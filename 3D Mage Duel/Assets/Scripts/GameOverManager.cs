using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
  

    private bool isGameOver = false;
    private bool isGameWon = false;

    // Call this method to trigger the game over screen
    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);

        }
    }
    public void TriggerVictory()
    {
        if(!isGameWon)
        {
            isGameWon = true;
            victoryScreen.SetActive(true);
        }
    }
}