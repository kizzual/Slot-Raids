using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [Header("Panels")]
    public GameObject[] panel;
    [Header("Buttons")]
    public GameObject[] button;
    public void ActivateCurrentButton(int indexCurrentButton)
    {
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != indexCurrentButton)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                panel[i].SetActive(false);
            }
            else
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                panel[i].SetActive(true);
            }
        }
    }
}
