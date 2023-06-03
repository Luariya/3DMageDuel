using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Settings;
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void CreditScreen()
    {
        Credits.SetActive(true);
    }

    public void SettingsScreen()
    {
        Settings.SetActive(true);
    }
}

