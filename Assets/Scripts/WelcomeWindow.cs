using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    public void Initialise()
    {
        if(!PlayerPrefs.HasKey("FirstStart"))
        {
            gameObject.SetActive(true);
        }
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("FirstStart", 1);
    }
}
