using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTutorialSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private Inventory_controll InventoryPanel;
    [SerializeField] private Item item;
    [SerializeField] private SwitchTabs switchtabs;
    [SerializeField] private Sell_controll sell_controll;
    [SerializeField] private Char_slot char_slot;
    [SerializeField] private Characteristics characteristics;
    [SerializeField] private Panel_UI panel_UI;
    [SerializeField] private AddingItem addingItem;
    [SerializeField] private List<Raid_button> raid_buttons;
    private bool m_isFirstTime = true;
    public Text test_1;
    public Text test_2;
    public void StepByStep(int index)
    {
        if (m_isFirstTime)
        {
             test_2.text = "CHECK ";
            if (index == 0)
            {
                gameObject.SetActive(true);
                steps[index].gameObject.SetActive(true);
                foreach (var item in raid_buttons)
                {
                    item.PauseRaid();
                }
            }
            else if (index == 1)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                InventoryPanel.ReturnItem(item);
                InventoryPanel.ReturnItem(item);
                InventoryPanel.gameObject.SetActive(true);
            }
            else if (index == 2)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);

                InventoryPanel.SellItemNeutral(1);
            }
            else if (index == 3)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                sell_controll.SellItems();
            }
            else if (index == 4)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                sell_controll.ClosePanel();
            }
            else if (index == 5)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                switchtabs.ActivateCurrentButton(1);
            }
            else if (index == 6)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                char_slot.OpenStats();
            }
            else if (index == 7)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                characteristics.AddItem(1);
            }
            else if (index == 8)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                panel_UI.SetMark(1);
            }
            else if (index == 9)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                addingItem.ClosePanel();
            }
            else if (index == 10)
            {
                steps[index - 1].gameObject.SetActive(false);
                steps[index].gameObject.SetActive(true);
                characteristics.ClosePanel();
            }
            else if (index == 11)
            {
                steps[index - 1].gameObject.SetActive(false);
                switchtabs.ActivateCurrentButton(2);
                gameObject.SetActive(false);
                PlayerPrefs.SetInt("NewTutorial", 1);
            }
        }
        
    }
    public void Firstinitialise()
    {
        if (PlayerPrefs.HasKey("NewTutorial"))
        {
            m_isFirstTime = false;
            foreach (var item in steps)
            {
                item.SetActive(false);
            }
            test_1.text = "bool =  false";
        }
        else
        {
            test_1.text = "bool =  true ";

            m_isFirstTime = true;
        }
    }
}
