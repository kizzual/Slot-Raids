using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingItem : MonoBehaviour
{
    [SerializeField] private Panel_UI panel_ui;
    [SerializeField] private Inventory_controll inventoryControl;
    [SerializeField] private GameObject frontPanel;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private Characteristics characteristics;

    private enum ItemType
    {
        Sword,
        Shield,
        Amulet
    }
    private ItemType m_itemType;
    private Hero m_currentHero;

    private int CheckMark()
    {
        if (panel_ui.Rank_1_mark.activeSelf)
            return 1;
        else if (panel_ui.Rank_2_mark.activeSelf)
            return 2;
        else if (panel_ui.Rank_3_mark.activeSelf)
            return 3;
        else
            return 0;
    }

 
    public void OpenPanel_Sword(Hero hero)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        panel_ui.DIsplaySwordsInfo(inventoryControl, hero);
        m_itemType = ItemType.Sword;
        m_currentHero = hero;
    }
    public void OpenPanel_Shield(Hero hero)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        panel_ui.DIsplayShieldsInfo(inventoryControl, hero);
        m_itemType = ItemType.Shield;
        m_currentHero = hero;
    }
    public void OpenPanel_Amulet(Hero hero)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        panel_ui.DIsplayAmuletInfo(inventoryControl, hero);
        m_itemType = ItemType.Amulet;
        m_currentHero = hero;
    }
    public void ClosePanel()
    {
        switch (m_itemType)
        {
            case ItemType.Sword:
                {
                    if(m_currentHero.GetItem_Sword() != null)
                    {
                        if(CheckMark() == 0)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Sword());
                            m_currentHero.RemoveCurrentItem(m_currentHero.GetItem_Sword());
                            //реализовать возможность убрать айтем 
                        }
                        else if (CheckMark() == 1)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Sword());
                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Sword());
                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Sword());
                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(3, m_currentHero.typeElement));
                        }
                    }
                    else
                    {
                        if (CheckMark() == 1)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {

                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {

                            m_currentHero.AddItem(inventoryControl.TakeItem_sword(3, m_currentHero.typeElement));
                        }
                    }
                }
                break;
            case ItemType.Shield:
                {
                    if (m_currentHero.GetItem_Shield() != null)
                    {
                        if (CheckMark() == 0)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Shield());
                            m_currentHero.RemoveCurrentItem(m_currentHero.GetItem_Shield());
                        }
                        else if (CheckMark() == 1)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Shield());
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Shield());
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Shield());
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(3, m_currentHero.typeElement));
                        }
                    }
                    else
                    {
                        if (CheckMark() == 1)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_shield(3, m_currentHero.typeElement));
                        }
                    }
                }
                break;
            case ItemType.Amulet:
                {
                    if (m_currentHero.GetItem_Amulet() != null)
                    {
                        if (CheckMark() == 0)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Amulet());
                            m_currentHero.RemoveCurrentItem(m_currentHero.GetItem_Amulet());
                        }
                        else if (CheckMark() == 1)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Amulet());
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Amulet());
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {
                            inventoryControl.ReturnItem(m_currentHero.GetItem_Amulet());
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(3, m_currentHero.typeElement));
                        }
                    }
                    else
                    {
                        if (CheckMark() == 1)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(1, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 2)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(2, m_currentHero.typeElement));
                        }
                        else if (CheckMark() == 3)
                        {
                            m_currentHero.AddItem(inventoryControl.TakeItem_amulet(3, m_currentHero.typeElement));
                        }
                    }
                }
                break;
        }
        raid_control.UpdateHeroStats(m_currentHero);
        char_Controller.ChangeHeroStats(m_currentHero);
        characteristics.UpgradeHeroStats(m_currentHero);

        gameObject.SetActive(false);
        frontPanel.SetActive(false);
    }
}
