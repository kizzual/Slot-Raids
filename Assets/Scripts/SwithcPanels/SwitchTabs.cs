using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTabs : MonoBehaviour
{
    [Header("Panels")]
    public GameObject[] panel;
    [Header("Buttons")]
    public GameObject[] button;
    public Sprite spriteOpen;
    public Sprite spriteClose;
    private Image image;
    public GameObject Inventory;
    public Image InventoryBtn;
    public GameObject boostPanel;
    public GameObject questPanel;
    public int CurrentPanel;
    private void Start()
    {
        CurrentPanel = 0;
           image = InventoryBtn.GetComponent<Image>();
        /*for (int i = 0; i < panel.Length; i++)
        {
            if (i != 2)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                panel[i].SetActive(false);
            }
            else if (i == 2)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < panel.Length; i++)
        {
            if (i == 0)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                panel[i].SetActive(true);
            }
        } */
        ActivateCurrentButton(0);
    }


    public void GoToRaid(Zone zone)
    {
        ActivateCurrentButton(2);
    }
    public void ActivateCurrentButton(int indexCurrentButton)
    {
        CurrentPanel = indexCurrentButton;
        InventoryOnOff(true);
        boostPanel.SetActive(false);
        questPanel.SetActive(false);

        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 2)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                panel[i].SetActive(false);
            }
            else if(i == 2)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
               
            }
        }
        button[0].gameObject.transform.GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < panel.Length; i++)
        {
           if(i == indexCurrentButton && i !=0)
            {
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                button[0].gameObject.transform.GetChild(2).gameObject.SetActive(true);
                panel[i].SetActive(true);
            }
           else if(i == indexCurrentButton && i == 0)
            {
                panel[i].SetActive(true);
                button[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                button[0].gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        if (button[2].gameObject.transform.GetChild(1).gameObject.activeSelf)
            SoundControl._instance.UnMuteSound();
        else
            SoundControl._instance.MuteSound();

    }
    public void InventoryOnOff(bool onlyClose = false)
    {
        if (onlyClose)
        {
            image.sprite = spriteOpen;
            Inventory.SetActive(false);
            return;
        }
        else
        {
            if (Inventory.activeSelf)
            {
                image.sprite = spriteOpen;
                Inventory.SetActive(false);
                return;
            }
            else
            {
                image.sprite = spriteClose;
                Inventory.SetActive(true);
            }
        }

    }
    private void OnEnable()
    {
        /* for (int i = 0; i < panel.Length; i++)
         {
             if (i != 0 && i != 2)
             {
                 button[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
                 panel[i].SetActive(false);
             }
             else
             {
                 button[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                 panel[i].SetActive(true);
             }
         }*/
        
    }
}
