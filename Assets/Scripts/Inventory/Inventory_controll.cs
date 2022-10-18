using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_controll : MonoBehaviour
{
    [SerializeField] private List<Inventory_UI> _inventories_ui;
    public List<Item> m_Sword_1 = new List<Item>();
    public List<Item> m_Sword_2 = new List<Item>();
    public List<Item> m_Sword_3 = new List<Item>();
    public List<Item> m_Shield_1 = new List<Item>();
    public List<Item> m_Shield_2= new List<Item>();
    public List<Item> m_Shield_3 = new List<Item>();
    public List<Item> m_Amuulet_1 = new List<Item>();
    public List<Item> m_Amuulet_2 = new List<Item>();
    public List<Item> m_Amuulet_3 = new List<Item>();
    [SerializeField] private Sell_controll sell_controll;
    private int m_neutralCount;
    private int m_undeadCount;
    private int m_orderCount;
    private int m_demonCount;
    private long m_totalPrice_neutral;
    private long m_totalPrice_undead;
    private long m_totalPrice_order;
    private long m_totalPrice_demon;

       private void OnEnable()
    {
        DisplayInventoryItems();
    }

    public int GetSword_count(int itemRank, TypeElement typeElement)
    {
        int count = 0;
        if (itemRank == 1)
        {
            foreach (var item in m_Sword_1)
            {
                if(item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }
            return count;
        }
        else if (itemRank == 2)
        {
            foreach (var item in m_Sword_2)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }
            
            return count;
        }
        else if (itemRank == 3)
        {
            foreach (var item in m_Sword_3)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return m_Sword_3.Count;
        }
        else
            return -1;
    }
    public int GetShield_count(int itemRank, TypeElement typeElement)
    {
        int count = 0;
        if (itemRank == 1)
        {
            foreach (var item in m_Shield_1)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else if (itemRank == 2)
        {
            foreach (var item in m_Shield_2)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else if (itemRank == 3)
        {
            foreach (var item in m_Shield_3)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else
            return -1;
    }
    public int GetAmulet_count(int itemRank, TypeElement typeElement)
    {
        int count = 0;
        if (itemRank == 1)
        {
            foreach (var item in m_Amuulet_1)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else if (itemRank == 2)
        {
            foreach (var item in m_Amuulet_2)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else if (itemRank == 3)
        {
            foreach (var item in m_Amuulet_3)
            {
                if (item.typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    item.typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    item.typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    item.typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    count++;
                }
            }

            return count;
        }
        else
            return -1;
    }
    public Sprite GetSprite_Sword(int indexRank, TypeElement typeElement)
    {
        if (indexRank == 1)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if(m_Sword_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Sword_1[i].GetComponent<Image>().sprite;
                }
            }
        }
        else if (indexRank == 2)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Sword_2[i].GetComponent<Image>().sprite;
                }
            }
        }
        else if (indexRank == 3)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Sword_3[i].GetComponent<Image>().sprite;
                }
            }

        }
        return null;
    }
    public Sprite GetSprite_Shield(int indexRank, TypeElement typeElement)
    {
        if (indexRank == 1)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Shield_1[i].GetComponent<Image>().sprite;
                }
            }

        }
        else if (indexRank == 2)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Shield_2[i].GetComponent<Image>().sprite;
                }
            }

        }
        else if (indexRank == 3)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Shield_3[i].GetComponent<Image>().sprite;
                }
            }

        }
        return null;
    }
    public Sprite GetSprite_Amulet(int indexRank, TypeElement typeElement)
    {
        if (indexRank == 1)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Amuulet_1[i].GetComponent<Image>().sprite;
                }
            }

        }
        else if (indexRank == 2)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Amuulet_2[i].GetComponent<Image>().sprite;
                }
            }

        }
        else if (indexRank == 3)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    return m_Amuulet_3[i].GetComponent<Image>().sprite;
                }
            }

        }
        return null;
    }
    public Item TakeItem_sword(int itemRank, TypeElement typeElement)
    {
        Item tmpItem;
        if(itemRank == 1 && m_Sword_1.Count > 0)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if(m_Sword_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon )
                {
                    tmpItem = m_Sword_1[i];
                    m_Sword_1.RemoveAt(i);
                    CountSword_1();
                    return tmpItem;
                }
            }
        }
        else if(itemRank == 2 && m_Sword_2.Count > 0)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {

                    tmpItem = m_Sword_2[i];
                    m_Sword_2.RemoveAt(i);
                    CountSword_2();
                    return tmpItem;
                }
            }
        }
        else if (itemRank == 3 && m_Sword_3.Count > 0)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Sword_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Sword_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Sword_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Sword_3[i];
                    m_Sword_3.RemoveAt(i);
                    CountSword_3();
                    return tmpItem;
                }
            }
        }
       
        return null;
    }
    public Item TakeItem_shield(int itemRank, TypeElement typeElement)
    {
        Item tmpItem;
        if (itemRank == 1 && m_Shield_1.Count > 0)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Shield_1[i];
                    m_Shield_1.RemoveAt(i);
                    CountShield_1();
                    return tmpItem;
                }
            }
        }
        else if (itemRank == 2 && m_Shield_2.Count > 0)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Shield_2[i];
                    m_Shield_2.RemoveAt(i);
                    CountShield_2();
                    return tmpItem;
                }
            }
        }
        else if (itemRank == 3 && m_Shield_3.Count > 0)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Shield_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Shield_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Shield_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Shield_3[i];
                    m_Shield_3.RemoveAt(i);
                    CountShield_3();
                    return tmpItem;
                }
            }
        }

        return null;
    }
    public Item TakeItem_amulet(int itemRank, TypeElement typeElement)
    {
        Item tmpItem;
        if (itemRank == 1 && m_Amuulet_1.Count > 0)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_1[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_1[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_1[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Amuulet_1[i];
                    m_Amuulet_1.RemoveAt(i);
                    CountAmulet_1();
                    return tmpItem;
                }
            }
        }
        else if (itemRank == 2 && m_Amuulet_2.Count > 0)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_2[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_2[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_2[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Amuulet_2[i];
                    m_Amuulet_2.RemoveAt(i);
                    CountAmulet_2();
                    return tmpItem;
                }
            }
        }
        else if (itemRank == 3 && m_Amuulet_3.Count > 0)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Neutral && typeElement == TypeElement.Neutral ||
                    m_Amuulet_3[i].typeElement == Type_Element.Undead && typeElement == TypeElement.Undead ||
                    m_Amuulet_3[i].typeElement == Type_Element.Order && typeElement == TypeElement.Order ||
                    m_Amuulet_3[i].typeElement == Type_Element.Demon && typeElement == TypeElement.Demon)
                {
                    tmpItem = m_Amuulet_3[i];
                    m_Amuulet_3.RemoveAt(i);
                    CountAmulet_3();
                    return tmpItem;
                }
            }
        }

        return null;
    }
    public void ReturnItem(Item item)
    {
        switch (item.typeItem)
        {
            case TypeItem.Sword:
                switch (item.Rank)
                {
                    case 1:
                        m_Sword_1.Add(item);
                        CountSword_1();
                        break;
                    case 2:
                        m_Sword_2.Add(item);
                        CountSword_2();
                        break;
                    case 3:
                        m_Sword_3.Add(item);
                        CountSword_3();
                        break;
                }
                break;
            case TypeItem.Shield:
                switch (item.Rank)
                {
                    case 1:
                        m_Shield_1.Add(item);
                        CountShield_1();
                        break;
                    case 2:
                        m_Shield_2.Add(item);
                        CountShield_2();
                        break;
                    case 3:
                        m_Shield_3.Add(item);
                        CountShield_3();
                        break;
                }
                break;
            case TypeItem.Amulet:
                switch (item.Rank)
                {
                    case 1:
                        m_Amuulet_1.Add(item);
                        CountAmulet_1();
                        break;
                    case 2:
                        m_Amuulet_2.Add(item);
                        CountAmulet_2();
                        break;
                    case 3:
                        m_Amuulet_3.Add(item);
                        CountAmulet_3();
                        break;
                }
                break;
        }

    }
    public void DisplayInventoryItems()
    {
        CountSword_1();
        CountSword_2();
        CountSword_3();
        CountShield_1();
        CountShield_2();
        CountShield_3();
        CountAmulet_1();
        CountAmulet_2();
        CountAmulet_3();
        CheckFillPrice();
    }
    public void SellItemNeutral(int itemIndex)
    {
        int count = 0;
        Item item = new Item();
        if(itemIndex == 1)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if(m_Sword_1[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Sword_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 2)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Sword_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 3)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Sword_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 4)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Shield_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 5)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Shield_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 6)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Shield_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 7)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Amuulet_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 8)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Amuulet_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 9)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Neutral)
                {
                    count++;
                    item = m_Amuulet_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }



    }
    public void SellItemUndead(int itemIndex)
    {
        int count = 0;
        Item item = new Item();
        if (itemIndex == 1)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Sword_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 2)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Sword_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 3)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Sword_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 4)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Shield_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 5)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Shield_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 6)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Shield_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 7)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Amuulet_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 8)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Amuulet_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 9)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Undead)
                {
                    count++;
                    item = m_Amuulet_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }



    }
    public void SellItemOrder(int itemIndex)
    {
        int count = 0;
        Item item = new Item();
        if (itemIndex == 1)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Sword_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 2)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Sword_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 3)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Sword_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 4)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Shield_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 5)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Shield_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 6)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Shield_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 7)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Amuulet_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 8)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Amuulet_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 9)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Order)
                {
                    count++;
                    item = m_Amuulet_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }



    }
    public void SellItemDemon(int itemIndex)
    {
        int count = 0;
        Item item = new Item();
        if (itemIndex == 1)
        {
            for (int i = 0; i < m_Sword_1.Count; i++)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Sword_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 2)
        {
            for (int i = 0; i < m_Sword_2.Count; i++)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Sword_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 3)
        {
            for (int i = 0; i < m_Sword_3.Count; i++)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Sword_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 4)
        {
            for (int i = 0; i < m_Shield_1.Count; i++)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Shield_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 5)
        {
            for (int i = 0; i < m_Shield_2.Count; i++)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Shield_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 6)
        {
            for (int i = 0; i < m_Shield_3.Count; i++)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Shield_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 7)
        {
            for (int i = 0; i < m_Amuulet_1.Count; i++)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Amuulet_1[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 8)
        {
            for (int i = 0; i < m_Amuulet_2.Count; i++)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Amuulet_2[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }
        if (itemIndex == 9)
        {
            for (int i = 0; i < m_Amuulet_3.Count; i++)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Demon)
                {
                    count++;
                    item = m_Amuulet_3[i];
                }
            }
            sell_controll.OpenSellPanel(item, count, this);
        }



    }
    public void SellAllItems(int panelIndex)
    {
        long goldValue = 0;
        if(panelIndex == 1)
        {
            for (int i = m_Sword_1.Count - 1; i >= 0; i--)
            {
                if(m_Sword_1[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Sword_1[i].Selling_price;
                    m_Sword_1.RemoveAt(i);
                }
            }
            for (int i = m_Sword_2.Count - 1; i >= 0; i--)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Sword_2[i].Selling_price;
                    m_Sword_2.RemoveAt(i);
                }
            }
            for (int i = m_Sword_3.Count - 1; i >= 0; i--)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Sword_3[i].Selling_price;
                    m_Sword_3.RemoveAt(i);
                }
            }
            for (int i = m_Shield_1.Count - 1; i >= 0; i--)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Shield_1[i].Selling_price;
                    m_Shield_1.RemoveAt(i);
                }
            }
            for (int i = m_Shield_2.Count - 1; i >= 0; i--)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Shield_2[i].Selling_price;
                    m_Shield_2.RemoveAt(i);
                }
            }
            for (int i = m_Shield_3.Count - 1; i >= 0; i--)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Shield_3[i].Selling_price;
                    m_Shield_3.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_1.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Amuulet_1[i].Selling_price;
                    m_Amuulet_1.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_2.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Amuulet_2[i].Selling_price;
                    m_Amuulet_2.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_3.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Neutral)
                {
                    goldValue += m_Amuulet_3[i].Selling_price;
                    m_Amuulet_3.RemoveAt(i);
                }
            }
            Gold.AddGold(goldValue);
            DisplayInventoryItems();
        }
        if (panelIndex == 2)
        {
            for (int i = m_Sword_1.Count - 1; i >= 0; i--)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Sword_1[i].Selling_price;
                    m_Sword_1.RemoveAt(i);
                }
            }
            for (int i = m_Sword_2.Count - 1; i >= 0; i--)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Sword_2[i].Selling_price;
                    m_Sword_2.RemoveAt(i);
                }
            }
            for (int i = m_Sword_3.Count - 1; i >= 0; i--)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Sword_3[i].Selling_price;
                    m_Sword_3.RemoveAt(i);
                }
            }
            for (int i = m_Shield_1.Count - 1; i >= 0; i--)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Shield_1[i].Selling_price;
                    m_Shield_1.RemoveAt(i);
                }
            }
            for (int i = m_Shield_2.Count - 1; i >= 0; i--)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Shield_2[i].Selling_price;
                    m_Shield_2.RemoveAt(i);
                }
            }
            for (int i = m_Shield_3.Count - 1; i >= 0; i--)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Shield_3[i].Selling_price;
                    m_Shield_3.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_1.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Amuulet_1[i].Selling_price;
                    m_Amuulet_1.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_2.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Amuulet_2[i].Selling_price;
                    m_Amuulet_2.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_3.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Undead)
                {
                    goldValue += m_Amuulet_3[i].Selling_price;
                    m_Amuulet_3.RemoveAt(i);
                }
            }
            Gold.AddGold(goldValue);
            DisplayInventoryItems();
        }
        if (panelIndex == 3)
        {
            for (int i = m_Sword_1.Count - 1; i >= 0; i--)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Sword_1[i].Selling_price;
                    m_Sword_1.RemoveAt(i);
                }
            }
            for (int i = m_Sword_2.Count - 1; i >= 0; i--)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Sword_2[i].Selling_price;
                    m_Sword_2.RemoveAt(i);
                }
            }
            for (int i = m_Sword_3.Count - 1; i >= 0; i--)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Sword_3[i].Selling_price;
                    m_Sword_3.RemoveAt(i);
                }
            }
            for (int i = m_Shield_1.Count - 1; i >= 0; i--)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Shield_1[i].Selling_price;
                    m_Shield_1.RemoveAt(i);
                }
            }
            for (int i = m_Shield_2.Count - 1; i >= 0; i--)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Shield_2[i].Selling_price;
                    m_Shield_2.RemoveAt(i);
                }
            }
            for (int i = m_Shield_3.Count - 1; i >= 0; i--)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Shield_3[i].Selling_price;
                    m_Shield_3.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_1.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Amuulet_1[i].Selling_price;
                    m_Amuulet_1.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_2.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Amuulet_2[i].Selling_price;
                    m_Amuulet_2.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_3.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Order)
                {
                    goldValue += m_Amuulet_3[i].Selling_price;
                    m_Amuulet_3.RemoveAt(i);
                }
            }
            Gold.AddGold(goldValue);
            DisplayInventoryItems();
        }
        if (panelIndex == 4)
        {
            for (int i = m_Sword_1.Count - 1; i >= 0; i--)
            {
                if (m_Sword_1[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Sword_1[i].Selling_price;
                    m_Sword_1.RemoveAt(i);
                }
            }
            for (int i = m_Sword_2.Count - 1; i >= 0; i--)
            {
                if (m_Sword_2[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Sword_2[i].Selling_price;
                    m_Sword_2.RemoveAt(i);
                }
            }
            for (int i = m_Sword_3.Count - 1; i >= 0; i--)
            {
                if (m_Sword_3[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Sword_3[i].Selling_price;
                    m_Sword_3.RemoveAt(i);
                }
            }
            for (int i = m_Shield_1.Count - 1; i >= 0; i--)
            {
                if (m_Shield_1[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Shield_1[i].Selling_price;
                    m_Shield_1.RemoveAt(i);
                }
            }
            for (int i = m_Shield_2.Count - 1; i >= 0; i--)
            {
                if (m_Shield_2[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Shield_2[i].Selling_price;
                    m_Shield_2.RemoveAt(i);
                }
            }
            for (int i = m_Shield_3.Count - 1; i >= 0; i--)
            {
                if (m_Shield_3[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Shield_3[i].Selling_price;
                    m_Shield_3.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_1.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_1[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Amuulet_1[i].Selling_price;
                    m_Amuulet_1.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_2.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_2[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Amuulet_2[i].Selling_price;
                    m_Amuulet_2.RemoveAt(i);
                }
            }
            for (int i = m_Amuulet_3.Count - 1; i >= 0; i--)
            {
                if (m_Amuulet_3[i].typeElement == Type_Element.Demon)
                {
                    goldValue += m_Amuulet_3[i].Selling_price;
                    m_Amuulet_3.RemoveAt(i);
                }
            }
            Gold.AddGold(goldValue);
            DisplayInventoryItems();
        }

    }
    private void CheckFillPrice()
    {
        m_totalPrice_neutral = 0;
        m_totalPrice_undead = 0;
        m_totalPrice_order = 0;
        m_totalPrice_demon = 0;

        foreach (var item in m_Sword_1)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if(item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Sword_2)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Sword_3)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Shield_1)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Shield_2)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Shield_3)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Amuulet_1)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Amuulet_2)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        foreach (var item in m_Amuulet_3)
        {
            if (item.typeElement == Type_Element.Neutral)
                m_totalPrice_neutral += item.Selling_price;
            else if (item.typeElement == Type_Element.Undead)
                m_totalPrice_undead += item.Selling_price;
            else if (item.typeElement == Type_Element.Order)
                m_totalPrice_order += item.Selling_price;
            else if (item.typeElement == Type_Element.Demon)
                m_totalPrice_demon += item.Selling_price;
        }
        _inventories_ui[0].DisplaySellPrice(m_totalPrice_neutral);
        _inventories_ui[1].DisplaySellPrice(m_totalPrice_undead);
        _inventories_ui[2].DisplaySellPrice(m_totalPrice_order);
        _inventories_ui[3].DisplaySellPrice(m_totalPrice_demon);
    }
    public void LoadInventory(InventorySaver saver)
    {
        m_Sword_1 = saver.m_Sword_1;
        m_Sword_2 = saver.m_Sword_2;
        m_Sword_3 = saver.m_Sword_3;
        m_Shield_1 = saver.m_Shield_1;
        m_Shield_2 = saver.m_Shield_2;
        m_Shield_3 = saver.m_Shield_3;
        m_Amuulet_1 = saver.m_Amuulet_1;
        m_Amuulet_2 = saver.m_Amuulet_2;
        m_Amuulet_3 = saver.m_Amuulet_3;
    }
    #region count
    private void CountSword_1()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Sword_1.Count; i++)
        {
            if (m_Sword_1[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Sword_1[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Sword_1[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Sword_1[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplaySword_1(m_neutralCount);
        _inventories_ui[1].DisplaySword_1(m_undeadCount);
        _inventories_ui[2].DisplaySword_1(m_orderCount);
        _inventories_ui[3].DisplaySword_1(m_demonCount);
    }
    private void CountSword_2()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Sword_2.Count; i++)
        {
            if (m_Sword_2[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Sword_2[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Sword_2[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Sword_2[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplaySword_2(m_neutralCount);
        _inventories_ui[1].DisplaySword_2(m_undeadCount);
        _inventories_ui[2].DisplaySword_2(m_orderCount);
        _inventories_ui[3].DisplaySword_2(m_demonCount);
    }
    private void CountSword_3()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Sword_3.Count; i++)
        {
            if (m_Sword_3[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Sword_3[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Sword_3[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Sword_3[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplaySword_3(m_neutralCount);
        _inventories_ui[1].DisplaySword_3(m_undeadCount);
        _inventories_ui[2].DisplaySword_3(m_orderCount);
        _inventories_ui[3].DisplaySword_3(m_demonCount);
    }
    private void CountShield_1()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Shield_1.Count; i++)
        {
            if (m_Shield_1[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Shield_1[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Shield_1[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Shield_1[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayShield_1(m_neutralCount);
        _inventories_ui[1].DisplayShield_1(m_undeadCount);
        _inventories_ui[2].DisplayShield_1(m_orderCount);
        _inventories_ui[3].DisplayShield_1(m_demonCount);
    }
    private void CountShield_2()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Shield_2.Count; i++)
        {
            if (m_Shield_2[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Shield_2[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Shield_2[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Shield_2[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayShield_2(m_neutralCount);
        _inventories_ui[1].DisplayShield_2(m_undeadCount);
        _inventories_ui[2].DisplayShield_2(m_orderCount);
        _inventories_ui[3].DisplayShield_2(m_demonCount);
    }
    private void CountShield_3()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Shield_3.Count; i++)
        {
            if (m_Shield_3[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Shield_3[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Shield_3[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Shield_3[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayShield_3(m_neutralCount);
        _inventories_ui[1].DisplayShield_3(m_undeadCount);
        _inventories_ui[2].DisplayShield_3(m_orderCount);
        _inventories_ui[3].DisplayShield_3(m_demonCount);
    }
    private void CountAmulet_1()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Amuulet_1.Count; i++)
        {
            if (m_Amuulet_1[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Amuulet_1[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Amuulet_1[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Amuulet_1[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayAmulet_1(m_neutralCount);
        _inventories_ui[1].DisplayAmulet_1(m_undeadCount);
        _inventories_ui[2].DisplayAmulet_1(m_orderCount);
        _inventories_ui[3].DisplayAmulet_1(m_demonCount);
    }
    private void CountAmulet_2()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Amuulet_2.Count; i++)
        {
            if (m_Amuulet_2[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Amuulet_2[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Amuulet_2[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Amuulet_2[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayAmulet_2(m_neutralCount);
        _inventories_ui[1].DisplayAmulet_2(m_undeadCount);
        _inventories_ui[2].DisplayAmulet_2(m_orderCount);
        _inventories_ui[3].DisplayAmulet_2(m_demonCount);
    }
    private void CountAmulet_3()
    {
        m_neutralCount = 0;
        m_undeadCount = 0;
        m_orderCount = 0;
        m_demonCount = 0;
        for (int i = 0; i < m_Amuulet_3.Count; i++)
        {
            if (m_Amuulet_3[i].typeElement == Type_Element.Neutral)
                m_neutralCount++;
            else if (m_Amuulet_3[i].typeElement == Type_Element.Undead)
                m_undeadCount++;
            else if (m_Amuulet_3[i].typeElement == Type_Element.Order)
                m_orderCount++;
            else if (m_Amuulet_3[i].typeElement == Type_Element.Demon)
                m_demonCount++;
        }
        _inventories_ui[0].DisplayAmulet_3(m_neutralCount);
        _inventories_ui[1].DisplayAmulet_3(m_undeadCount);
        _inventories_ui[2].DisplayAmulet_3(m_orderCount);
        _inventories_ui[3].DisplayAmulet_3(m_demonCount);
    }
    #endregion
}
