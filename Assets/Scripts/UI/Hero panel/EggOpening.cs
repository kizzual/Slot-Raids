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
    [SerializeField] private Sprite AddButton_activeSprite;
    [SerializeField] private Sprite AddButton_InActiveSprite;
    [SerializeField] private List<Button> add_button;
    [SerializeField] private GameObject frontPanel;
    [SerializeField] private Image neutralEgg;
    [SerializeField] private Image undeadEgg;
    [SerializeField] private Image orderEgg;
    [SerializeField] private Image demonEgg;
    private HeroSlot currentSlot;
    void Update()
    {
        
    }

    public void Open_NeutralEgg(HeroSlot slot)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentSlot = slot;
        neutralEggPanel.SetActive(true);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(false);
        neutralEggCount_text.text = neutralInventory._eggs_count.ToString();
        if(neutralInventory._eggs_count > 0)
        {
            neutralEgg.enabled = true;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_activeSprite;
                item.enabled = true;
            }
        }
        else
        {
            neutralEgg.enabled = false;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_InActiveSprite;
                item.enabled = false;
            }
        }
    }
    public void Open_UndeadEgg(HeroSlot slot)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentSlot = slot;
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(true);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(false);
        undeadEggCount_text.text = undeadInventory._eggs_count.ToString();
        if (undeadInventory._eggs_count > 0)
        {
            undeadEgg.enabled = true;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_activeSprite;
                item.enabled = true;
            }          
        }
        else
        {
            undeadEgg.enabled = false;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_InActiveSprite;
                item.enabled = false;
            }
        }
    }
    public void Open_OrderEgg(HeroSlot slot)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentSlot = slot;
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(true);
        DemonEggPanel.SetActive(false);
        orderEggCount_text.text = orderInventory._eggs_count.ToString();
        if (orderInventory._eggs_count > 0)
        {
            orderEgg.enabled = true;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_activeSprite;
                item.enabled = true;
            }
     
        }
        else
        {
            orderEgg.enabled = false;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_InActiveSprite;
                item.enabled = false;
            }
         
        }
    }
    public void Open_DemonEgg(HeroSlot slot)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentSlot = slot;
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(true);
        demonEggCount_text.text = DemonInventory._eggs_count.ToString();
        if (DemonInventory._eggs_count > 0)
        {
            demonEgg.enabled = true;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_activeSprite;
                item.enabled = true;
            }
          
        }
        else
        {
            demonEgg.enabled = false;
            foreach (var item in add_button)
            {
                item.gameObject.GetComponent<Image>().sprite = AddButton_InActiveSprite;
                item.enabled = false;
            }
        }
    }
    public void Add_EggNeutral()
    {
        neutralInventory._eggs_count--;
        character.Add_EggNeutral();
        ClosePanels();
    }
    public void Add_EggUndead()
    {
        undeadInventory._eggs_count--;
        character.Add_EggUndead();
        ClosePanels();
    }
    public void Add_EggOrder()
    {
        orderInventory._eggs_count--;
        character.Add_EggOrder();
        ClosePanels();
    }
    public void Add_EggDemon()
    {
        DemonInventory._eggs_count--;
        character.Add_EggDemon();
        ClosePanels();
    }
    public void ClosePanels()
    {
        neutralEggPanel.SetActive(false);
        undeadEggPanel.SetActive(false);
        orderEggPanel.SetActive(false);
        DemonEggPanel.SetActive(false);
        frontPanel.SetActive(false);

    }
}
