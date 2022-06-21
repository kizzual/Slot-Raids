using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggOpening : MonoBehaviour
{
    [SerializeField] private GameObject neutralEggPanel;
    [SerializeField] private Text neutralEggCount_text;
    [SerializeField] private GameObject undeadEggPanel;
    [SerializeField] private Text undeadEggCount_text;
    [SerializeField] private GameObject orderEggPanel;
    [SerializeField] private Text orderEggCount_text;
    [SerializeField] private GameObject DemonEggPanel;
    [SerializeField] private Text demonEggCount_text;

    [SerializeField] private Inventory neutralInventory;
    [SerializeField] private Inventory undeadInventory;
    [SerializeField] private Inventory orderInventory;
    [SerializeField] private Inventory DemonInventory;
    [SerializeField] private Button add_button;
    void Update()
    {
        
    }

    public void Add_NeutralEgg()
    {
        neutralEggPanel.SetActive(true);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(false);
        neutralEggCount_text.text = neutralInventory._eggs_count.ToString();
        if(neutralInventory._eggs_count > 0)
        {
            add_button.enabled = true;
        }
        else
        {
            add_button.enabled = false;
        }
    }
    public void Add_UndeadEgg()
    {
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(true);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(false);
        undeadEggCount_text.text = undeadInventory._eggs_count.ToString();
        if (undeadInventory._eggs_count > 0)
        {
            add_button.enabled = true;
        }
        else
        {
            add_button.enabled = false;
        }
    }
    public void Add_OrderEgg()
    {
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(true);
        DemonEggPanel.SetActive(false);
        orderEggCount_text.text = orderInventory._eggs_count.ToString();
        if (orderInventory._eggs_count > 0)
        {
            add_button.enabled = true;
        }
        else
        {
            add_button.enabled = false;
        }
    }
    public void Add_DemonEgg()
    {
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(true);
        demonEggCount_text.text = DemonInventory._eggs_count.ToString();
        if (DemonInventory._eggs_count > 0)
        {
            add_button.enabled = true;
        }
        else
        {
            add_button.enabled = false;
        }
    }
}
