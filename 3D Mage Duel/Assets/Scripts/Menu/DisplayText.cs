using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI obj_text; 
    public TMP_InputField display;

    private void Start()
    {
        obj_text.text = PlayerPrefs.GetString("user_name");

    }

    public void Create()
    {
        obj_text.text = display.text;
        PlayerPrefs.SetString("user_name", obj_text.text);
        PlayerPrefs.Save();
    }
}
