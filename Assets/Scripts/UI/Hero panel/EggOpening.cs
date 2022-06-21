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

    [SerializeField] private Character character;

    [SerializeField] private Button add_button;
    [SerializeField] private GameObject frontPanel;

    private HeroSlot currentSlot;
    void Update()
    {
        
    }

    public void Open_NeutralEgg(HeroSlot slot)
    {
        currentSlot = slot;
        neutralEggPanel.SetActive(true);
    //    undeadEggPanel.SetActive(false);
   //     orderEggPanel.SetActive(false);
   //     DemonEggPanel.SetActive(false);
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
    public void Open_UndeadEgg(HeroSlot slot)
    {
        currentSlot = slot;
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
    public void Open_OrderEgg(HeroSlot slot)
    {
        currentSlot = slot;
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
    public void Open_DemonEgg(HeroSlot slot)
    {
        currentSlot = slot;
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
    public void Add_NeutralHero()
    {
        currentSlot.isEpmty = true;
        neutralInventory._eggs_count--;
        character.Add_NeutralHero();
        ClosePanels();
    }
    public void Add_UndeadHero()
    {
        currentSlot.isEpmty = true;
        undeadInventory._eggs_count--;
        character.Add_UndeadHero();
        ClosePanels();
    }
    public void Add_OrderHero()
    {
        currentSlot.isEpmty = true;
        orderInventory._eggs_count--;
        character.Add_OrderHero();
        ClosePanels();
    }
    public void Add_DemonHero()
    {
        currentSlot.isEpmty = true;
        DemonInventory._eggs_count--;
        character.Add_DemonHero();
        ClosePanels();
    }
    public void ClosePanels()
    {
        neutralEggPanel.SetActive(false);
    //    undeadEggPanel.SetActive(false);
    //    orderEggPanel.SetActive(false);
    //    DemonEggPanel.SetActive(false);
        frontPanel.SetActive(false);

    }
}
