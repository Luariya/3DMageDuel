using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

}

