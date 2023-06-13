using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Buttons : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Settings;
    public AudioSource buttonsound;

    public void QuitButton()
    {
        buttonsound.Play();
        Debug.Log("Quit");
        Application.Quit();
        
    }

    public void HomeButton()
    {
        PhotonView photonView = GetComponent<PhotonView>();

        if (photonView != null && photonView.IsMine)
        {
            PhotonNetwork.Disconnect();
        }

        Invoke("LoadScene", 1f);
        buttonsound.Play();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void CreditScreen()
    {
        buttonsound.Play();
        Credits.SetActive(true);
        
    }

    public void SettingsScreen()
    {
        buttonsound.Play();
        Settings.SetActive(true);
        
    }

    public void GoBack()
    {
        buttonsound.Play();
        Credits.SetActive(false);
        Settings.SetActive(false);
    }
    public void StartButton()
    {
        buttonsound.Play();
        SceneManager.LoadScene("Loading");

    }
}


