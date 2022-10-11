using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    public GameObject Button;
    public void Initialise()
    {
        if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
        {
            if (!PlayerPrefs.HasKey("FirstStart"))
            {
                gameObject.SetActive(true);
                StartCoroutine(hello());
            }
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(hello());
        }
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("FirstStart", 1);

    }
    IEnumerator hello()
    {
        yield return new WaitForSeconds(1.5f);
        Button.SetActive(true);
    }
}
