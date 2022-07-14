using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell_controll : MonoBehaviour
{
    [SerializeField] private Sell_UI sell_ui;
    [SerializeField] private GameObject frontPanel;
    [SerializeField] private GameObject left_button;
    [SerializeField] private GameObject right_button;

    public int m_currentItem_count;
    public Item m_currentItem;
    private Inventory_controll m_inventory_Controll;
    public int m_maxCount;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnSellingItem += OpenSellPanel;
    }

    public void OpenSellPanel(Item item, int count, Inventory_controll inventory_Controll)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        if (count > 0)
        {
            right_button.SetActive(true);
            left_button.SetActive(true);
            m_currentItem_count = 1;
        }
        if(count == 1)
        {
            right_button.SetActive(false);
            left_button.SetActive(true);
            m_currentItem_count = 1;
        }
        else if(count == 0)
        {
            left_button.SetActive(false);
            right_button.SetActive(false);
            m_currentItem_count = 0;
        }
        switch (item.typeElement)
        {
            case Type_Element.Neutral:
                switch (item.typeItem)
                {
                    case TypeItem.Sword:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetSword_count(1, TypeElement.Neutral);
                        else if(item.Rank == 2)
                            m_maxCount = inventory_Controll.GetSword_count(2, TypeElement.Neutral);
                        else if(item.Rank == 3)
                            m_maxCount = inventory_Controll.GetSword_count(3, TypeElement.Neutral);
                        break;
                    case TypeItem.Shield:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetShield_count(1, TypeElement.Neutral);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetShield_count(2, TypeElement.Neutral);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetShield_count(3, TypeElement.Neutral);
                        break;
                    case TypeItem.Amulet:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetAmulet_count(1, TypeElement.Neutral);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetAmulet_count(2, TypeElement.Neutral);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetAmulet_count(3, TypeElement.Neutral);
                        break;
                }
                break;
            case Type_Element.Undead:
                switch (item.typeItem)
                {
                    case TypeItem.Sword:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetSword_count(1, TypeElement.Undead);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetSword_count(2, TypeElement.Undead);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetSword_count(3, TypeElement.Undead);
                        break;
                    case TypeItem.Shield:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetShield_count(1, TypeElement.Undead);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetShield_count(2, TypeElement.Undead);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetShield_count(3, TypeElement.Undead);
                        break;
                    case TypeItem.Amulet:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetAmulet_count(1, TypeElement.Undead);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetAmulet_count(2, TypeElement.Undead);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetAmulet_count(3, TypeElement.Undead);
                        break;
                }
                break;
            case Type_Element.Order:
                switch (item.typeItem)
                {
                    case TypeItem.Sword:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetSword_count(1, TypeElement.Order);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetSword_count(2, TypeElement.Order);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetSword_count(3, TypeElement.Order);
                        break;
                    case TypeItem.Shield:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetShield_count(1, TypeElement.Order);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetShield_count(2, TypeElement.Order);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetShield_count(3, TypeElement.Order);
                        break;
                    case TypeItem.Amulet:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetAmulet_count(1, TypeElement.Order);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetAmulet_count(2, TypeElement.Order);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetAmulet_count(3, TypeElement.Order);
                        break;
                }
                break;
            case Type_Element.Demon:
                switch (item.typeItem)
                {
                    case TypeItem.Sword:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetSword_count(1, TypeElement.Demon);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetSword_count(2, TypeElement.Demon);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetSword_count(3, TypeElement.Demon);
                        break;
                    case TypeItem.Shield:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetShield_count(1, TypeElement.Demon);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetShield_count(2, TypeElement.Demon);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetShield_count(3, TypeElement.Demon);
                        break;
                    case TypeItem.Amulet:
                        if (item.Rank == 1)
                            m_maxCount = inventory_Controll.GetAmulet_count(1, TypeElement.Demon);
                        else if (item.Rank == 2)
                            m_maxCount = inventory_Controll.GetAmulet_count(2, TypeElement.Demon);
                        else if (item.Rank == 3)
                            m_maxCount = inventory_Controll.GetAmulet_count(3, TypeElement.Demon);
                        break;
                }
                break;

        }
        m_inventory_Controll = inventory_Controll;
        m_currentItem = item;
        sell_ui.Initialise(item, count, item.Selling_price * m_currentItem_count);
    }
    public void ClosePanel()
    {
        frontPanel.SetActive(false);
        gameObject.SetActive(false);
    }
    public void SwitchCount(int index)
    {
        if (index == 0)
        {
            if (m_currentItem_count > 0)
            {
                left_button.SetActive(true);
                right_button.SetActive(true);
                m_currentItem_count--;
            }
            if(m_currentItem_count == 0)
            {
                right_button.SetActive(true);
                left_button.SetActive(false);
            }
        }
        else if(index == 1)
        {
            if (m_currentItem_count < m_maxCount)
            {
                right_button.SetActive(true);
                left_button.SetActive(true);
                m_currentItem_count++;
            }
            if (m_currentItem_count == m_maxCount)
            {
                left_button.SetActive(true);
                right_button.SetActive(false);
            }
        }
        sell_ui.ChangeCurrentCount(m_currentItem_count, m_currentItem.Selling_price * m_currentItem_count);
    }
    public void MaxButton()
    {
        if (m_maxCount == 0)
        {
            left_button.SetActive(false);
            right_button.SetActive(false);
        }
        else
        {
            left_button.SetActive(true);
            right_button.SetActive(false);
        }
        m_currentItem_count = m_maxCount;
        sell_ui.ChangeCurrentCount(m_currentItem_count, m_currentItem.Selling_price * m_currentItem_count);
    }

    public void SellItems()
    {
        Gold.AddGold(m_currentItem.Selling_price * m_currentItem_count);
        switch (m_currentItem.typeElement)
        {
            case Type_Element.Neutral:
                switch (m_currentItem.typeItem)
                {
                    case TypeItem.Sword:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(1, TypeElement.Neutral);
                            }
                        }
                        else if(m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(2, TypeElement.Neutral);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(3, TypeElement.Neutral);
                            }
                        }
                        break;
                    case TypeItem.Shield:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(1, TypeElement.Neutral);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(2, TypeElement.Neutral);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(3, TypeElement.Neutral);
                            }
                        }
                        break;
                    case TypeItem.Amulet:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(1, TypeElement.Neutral);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(2, TypeElement.Neutral);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(3, TypeElement.Neutral);
                            }
                        }
                        break;
                }
                break;
            case Type_Element.Undead:
                switch (m_currentItem.typeItem)
                {
                    case TypeItem.Sword:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(1, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(2, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(3, TypeElement.Undead);
                            }
                        }
                        break;
                    case TypeItem.Shield:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(1, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(2, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(3, TypeElement.Undead);
                            }
                        }
                        break;
                    case TypeItem.Amulet:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(1, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(2, TypeElement.Undead);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(3, TypeElement.Undead);
                            }
                        }
                        break;
                }
                break;
            case Type_Element.Order:
                switch (m_currentItem.typeItem)
                {
                    case TypeItem.Sword:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(1, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(2, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(3, TypeElement.Order);
                            }
                        }
                        break;
                    case TypeItem.Shield:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(1, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(2, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(3, TypeElement.Order);
                            }
                        }
                        break;
                    case TypeItem.Amulet:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(1, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(2, TypeElement.Order);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(3, TypeElement.Order);
                            }
                        }
                        break;
                }
                break;
            case Type_Element.Demon:
                switch (m_currentItem.typeItem)
                {
                    case TypeItem.Sword:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(1, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(2, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_sword(3, TypeElement.Demon);
                            }
                        }
                        break;
                    case TypeItem.Shield:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(1, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(2, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_shield(3, TypeElement.Demon);
                            }
                        }
                        break;
                    case TypeItem.Amulet:
                        if (m_currentItem.Rank == 1)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(1, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 2)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(2, TypeElement.Demon);
                            }
                        }
                        else if (m_currentItem.Rank == 3)
                        {
                            for (int i = 0; i < m_currentItem_count; i++)
                            {
                                m_inventory_Controll.TakeItem_amulet(3, TypeElement.Demon);
                            }
                        }
                        break;
                }
                break;
        }
        m_maxCount -= m_currentItem_count;
        if(m_maxCount == 0 )
           m_currentItem_count = 0;
        else
            m_currentItem_count = 1;

        sell_ui.Initialise(m_currentItem, m_maxCount, m_currentItem.Selling_price * m_currentItem_count);
        if(m_maxCount == 0)
        {
            left_button.SetActive(false);
            right_button.SetActive(false);
        }
        else if(m_maxCount == 1)
        {
            left_button.SetActive(true);
            right_button.SetActive(false);
        }
        else if(m_maxCount > 1)
        {
            left_button.SetActive(true);
            right_button.SetActive(true);
        }
    }
}
