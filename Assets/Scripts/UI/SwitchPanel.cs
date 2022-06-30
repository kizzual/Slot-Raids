using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
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
    [SerializeField] private GameController raidController;
    private void Start()
    {
        image = InventoryBtn.GetComponent<Image>();
    }
    public void ActivateCurrentButton(int indexCurrentButton)
    {
        InventoryOnOff(true);

        raidController.ShowHeroPanel();
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
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 2)
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
