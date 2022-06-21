using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloserInventory : MonoBehaviour
{
    public Sprite spriteOpen;
    public Sprite spriteClose;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void InventoryOnOff(GameObject Inventory)
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
