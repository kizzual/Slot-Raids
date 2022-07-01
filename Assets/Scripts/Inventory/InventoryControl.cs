using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    const string SaveFilename = "Inventories";
    [SerializeField] private NeutralItemsSO neutralItemsSO;
    [SerializeField] private UndeadItemsSO undeadItemsSO;
    [SerializeField] private OrderItemsSO orderItemsSO;
    [SerializeField] private DemonItemsSO demonItemsSO;

    [SerializeField] private Selling selling;
    [SerializeField] private GameObject FrontPanel;

    public List<Inventory> Inventories;
    private  List<SavedInvetory> SavedInventories = new List<SavedInvetory>();
 
    public void Loading()
    {
        LoadInventory();
        InitialiseInventory();
    }
    
    public void SellAllItems(int indexPanel)
    {
        if(indexPanel == 0)
        {
            int gold = 0;
            if (Inventories[indexPanel]._eggs_count > 0)
            {
                gold += (Inventories[indexPanel]._eggs_count * neutralItemsSO.Egg.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_1_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_1_count * neutralItemsSO.sword_1.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_2_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_2_count * neutralItemsSO.sword_2.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_3_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_3_count * neutralItemsSO.sword_3.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_1_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_1_count * neutralItemsSO.shield_1.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_2_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_2_count * neutralItemsSO.shield_2.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_3_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_3_count * neutralItemsSO.shield_3.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_1_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_1_count * neutralItemsSO.Amulet_1.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_2_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_2_count * neutralItemsSO.Amulet_2.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_3_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_3_count * neutralItemsSO.Amulet_3.sellingPrice);
            }
            Inventories[indexPanel].SellAllItems();
            Gold.AddGold(gold);
        }
        if (indexPanel == 1)
        {
            int gold = 0;
            if (Inventories[indexPanel]._eggs_count > 0)
            {
                gold += (Inventories[indexPanel]._eggs_count * undeadItemsSO.Egg.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_1_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_1_count * undeadItemsSO.sword_1.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_2_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_2_count * undeadItemsSO.sword_2.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_3_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_3_count * undeadItemsSO.sword_3.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_1_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_1_count * undeadItemsSO.shield_1.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_2_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_2_count * undeadItemsSO.shield_2.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_3_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_3_count * undeadItemsSO.shield_3.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_1_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_1_count * undeadItemsSO.Amulet_1.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_2_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_2_count * undeadItemsSO.Amulet_2.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_3_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_3_count * undeadItemsSO.Amulet_3.sellingPrice);
            }
            Inventories[indexPanel].SellAllItems();
            Gold.AddGold(gold);
        }
        if (indexPanel == 2)
        {
            int gold = 0;
            if (Inventories[indexPanel]._eggs_count > 0)
            {
                gold += (Inventories[indexPanel]._eggs_count * orderItemsSO.Egg.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_1_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_1_count * orderItemsSO.sword_1.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_2_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_2_count * orderItemsSO.sword_2.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_3_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_3_count * orderItemsSO.sword_3.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_1_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_1_count * orderItemsSO.shield_1.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_2_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_2_count * orderItemsSO.shield_2.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_3_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_3_count * orderItemsSO.shield_3.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_1_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_1_count * orderItemsSO.Amulet_1.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_2_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_2_count * orderItemsSO.Amulet_2.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_3_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_3_count * orderItemsSO.Amulet_3.sellingPrice);
            }
            Inventories[indexPanel].SellAllItems();
            Gold.AddGold(gold);
        }
        if (indexPanel == 3)
        {
            int gold = 0;
            if (Inventories[indexPanel]._eggs_count > 0)
            {
                gold += (Inventories[indexPanel]._eggs_count * demonItemsSO.Egg.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_1_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_1_count * demonItemsSO.sword_1.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_2_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_2_count * demonItemsSO.sword_2.sellingPrice);
            }
            if (Inventories[indexPanel]._swords_3_count > 0)
            {
                gold += (Inventories[indexPanel]._swords_3_count * demonItemsSO.sword_3.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_1_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_1_count * demonItemsSO.shield_1.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_2_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_2_count * demonItemsSO.shield_2.sellingPrice);
            }
            if (Inventories[indexPanel]._shield_3_count > 0)
            {
                gold += (Inventories[indexPanel]._shield_3_count * demonItemsSO.shield_3.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_1_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_1_count * demonItemsSO.Amulet_1.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_2_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_2_count * demonItemsSO.Amulet_2.sellingPrice);
            }
            if (Inventories[indexPanel]._amulet_3_count > 0)
            {
                gold += (Inventories[indexPanel]._amulet_3_count * demonItemsSO.Amulet_3.sellingPrice);
            }
            Inventories[indexPanel].SellAllItems();
            Gold.AddGold(gold);
        }

    }
    private void CheckSellGold()
    {
        for (int indexPanel = 0; indexPanel < Inventories.Count; indexPanel++)
        {
            if (indexPanel == 0)
            {
                int gold = 0;
                if (Inventories[indexPanel]._eggs_count > 0)
                {
                    gold += (Inventories[indexPanel]._eggs_count * neutralItemsSO.Egg.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_1_count * neutralItemsSO.sword_1.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_2_count * neutralItemsSO.sword_2.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_3_count * neutralItemsSO.sword_3.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_1_count * neutralItemsSO.shield_1.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_2_count * neutralItemsSO.shield_2.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_3_count * neutralItemsSO.shield_3.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_1_count * neutralItemsSO.Amulet_1.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_2_count * neutralItemsSO.Amulet_2.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_3_count * neutralItemsSO.Amulet_3.sellingPrice);
                }
                Inventories[indexPanel].DisplaySellingGold(gold);
            }
            if (indexPanel == 1)
            {
                int gold = 0;
                if (Inventories[indexPanel]._eggs_count > 0)
                {
                    gold += (Inventories[indexPanel]._eggs_count * undeadItemsSO.Egg.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_1_count * undeadItemsSO.sword_1.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_2_count * undeadItemsSO.sword_2.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_3_count * undeadItemsSO.sword_3.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_1_count * undeadItemsSO.shield_1.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_2_count * undeadItemsSO.shield_2.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_3_count * undeadItemsSO.shield_3.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_1_count * undeadItemsSO.Amulet_1.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_2_count * undeadItemsSO.Amulet_2.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_3_count * undeadItemsSO.Amulet_3.sellingPrice);
                }
                Inventories[indexPanel].DisplaySellingGold(gold);
            }
            if (indexPanel == 2)
            {
                int gold = 0;
                if (Inventories[indexPanel]._eggs_count > 0)
                {
                    gold += (Inventories[indexPanel]._eggs_count * orderItemsSO.Egg.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_1_count * orderItemsSO.sword_1.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_2_count * orderItemsSO.sword_2.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_3_count * orderItemsSO.sword_3.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_1_count * orderItemsSO.shield_1.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_2_count * orderItemsSO.shield_2.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_3_count * orderItemsSO.shield_3.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_1_count * orderItemsSO.Amulet_1.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_2_count * orderItemsSO.Amulet_2.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_3_count * orderItemsSO.Amulet_3.sellingPrice);
                }
                Inventories[indexPanel].DisplaySellingGold(gold);
            }
            if (indexPanel == 3)
            {
                int gold = 0;
                if (Inventories[indexPanel]._eggs_count > 0)
                {
                    gold += (Inventories[indexPanel]._eggs_count * demonItemsSO.Egg.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_1_count * demonItemsSO.sword_1.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_2_count * demonItemsSO.sword_2.sellingPrice);
                }
                if (Inventories[indexPanel]._swords_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._swords_3_count * demonItemsSO.sword_3.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_1_count * demonItemsSO.shield_1.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_2_count * demonItemsSO.shield_2.sellingPrice);
                }
                if (Inventories[indexPanel]._shield_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._shield_3_count * demonItemsSO.shield_3.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_1_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_1_count * demonItemsSO.Amulet_1.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_2_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_2_count * demonItemsSO.Amulet_2.sellingPrice);
                }
                if (Inventories[indexPanel]._amulet_3_count > 0)
                {
                    gold += (Inventories[indexPanel]._amulet_3_count * demonItemsSO.Amulet_3.sellingPrice);
                }
                Inventories[indexPanel].DisplaySellingGold(gold);
            }
        }
    }
    public void SellNeutralItems(int indexItem)
    {
        Prize prize = new Prize();
        if(indexItem == 1)
        {
            prize = neutralItemsSO.sword_1;
        }
        else if (indexItem == 2)
        {
            prize = neutralItemsSO.sword_2;
        }
        else if (indexItem == 3)
        {
            prize = neutralItemsSO.sword_3;
        }
        else if(indexItem == 4)
        {
            prize = neutralItemsSO.shield_1;
        }
        else if (indexItem == 5)
        {
            prize = neutralItemsSO.shield_2;
        }
        else if (indexItem == 6)
        {
            prize = neutralItemsSO.shield_3;
        }
        else if (indexItem == 7)
        {
            prize = neutralItemsSO.Amulet_1;
        }
        else if (indexItem == 8)
        {
            prize = neutralItemsSO.Amulet_2;
        }
        else if (indexItem == 9)
        {
            prize = neutralItemsSO.Amulet_3;
        }
        FrontPanel.SetActive(true);
        selling.TakeAllInfo(prize, Inventories[0]);
    }
    public void SellUndeadItems(int indexItem)
    {
        Prize prize = new Prize();
        if (indexItem == 1)
        {
            prize = undeadItemsSO.sword_1;
        }
        else if (indexItem == 2)
        {
            prize = undeadItemsSO.sword_2;
        }
        else if (indexItem == 3)
        {
            prize = undeadItemsSO.sword_3;
        }
        else if (indexItem == 4)
        {
            prize = undeadItemsSO.shield_1;
        }
        else if (indexItem == 5)
        {
            prize = undeadItemsSO.shield_2;
        }
        else if (indexItem == 6)
        {
            prize = undeadItemsSO.shield_3;
        }
        else if (indexItem == 7)
        {
            prize = undeadItemsSO.Amulet_1;
        }
        else if (indexItem == 8)
        {
            prize = undeadItemsSO.Amulet_2;
        }
        else if (indexItem == 9)
        {
            prize = undeadItemsSO.Amulet_3;
        }
        FrontPanel.SetActive(true);
        selling.TakeAllInfo(prize, Inventories[1]);
    }
    public void SellOrderItems(int indexItem)
    {
        Prize prize = new Prize();
        if (indexItem == 1)
        {
            prize = orderItemsSO.sword_1;
        }
        else if (indexItem == 2)
        {
            prize = orderItemsSO.sword_2;
        }
        else if (indexItem == 3)
        {
            prize = orderItemsSO.sword_3;
        }
        else if (indexItem == 4)
        {
            prize = orderItemsSO.shield_1;
        }
        else if (indexItem == 5)
        {
            prize = orderItemsSO.shield_2;
        }
        else if (indexItem == 6)
        {
            prize = orderItemsSO.shield_3;
        }
        else if (indexItem == 7)
        {
            prize = orderItemsSO.Amulet_1;
        }
        else if (indexItem == 8)
        {
            prize = orderItemsSO.Amulet_2;
        }
        else if (indexItem == 9)
        {
            prize = orderItemsSO.Amulet_3;
        }
        FrontPanel.SetActive(true);
        selling.TakeAllInfo(prize, Inventories[2]);
    }
    public void SellDemonItems(int indexItem)
    {
        Prize prize = new Prize();
        if (indexItem == 1)
        {
            prize = demonItemsSO.sword_1;
        }
        else if (indexItem == 2)
        {
            prize = demonItemsSO.sword_2;
        }
        else if (indexItem == 3)
        {
            prize = demonItemsSO.sword_3;
        }
        else if (indexItem == 4)
        {
            prize = demonItemsSO.shield_1;
        }
        else if (indexItem == 5)
        {
            prize = demonItemsSO.shield_2;
        }
        else if (indexItem == 6)
        {
            prize = demonItemsSO.shield_3;
        }
        else if (indexItem == 7)
        {
            prize = demonItemsSO.Amulet_1;
        }
        else if (indexItem == 8)
        {
            prize = demonItemsSO.Amulet_2;
        }
        else if (indexItem == 9)
        {
            prize = demonItemsSO.Amulet_3;
        }
        FrontPanel.SetActive(true);
        selling.TakeAllInfo(prize, Inventories[3]);
    }
    private void OnEnable()
    {
        CheckSellGold();
        for (int i = 0; i < Inventories.Count; i++)
        {
            if(i == 0)
            {
               Inventories[i].gameObject.SetActive(true);
            }
            else
            {
                Inventories[i].gameObject.SetActive(false);
            }


        }
    }
    private void InitialiseInventory()
    {
        if (SavedInventories.Count < 1)
        {
            foreach (var item in Inventories)
            {

                item.CountInitialise();
                item.Initialise();

            }
        }
        else 
        {
            for (int i = 0; i < SavedInventories.Count; i++)
            {
                Inventories[i].SetSaveInfo(SavedInventories[i]);
            }
        }
    }

    public void WinItems(List<Prize> prize)
    {
        for (int i = 0; i < prize.Count; i++)
        {
            switch (prize[i]._Type)
            {
                case Type.death:
                    break;
                case Type.item_sword_1:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._swords_1_count++;
                    break;
                case Type.item_sword_2:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._swords_2_count++;
                    break;
                case Type.item_sword_3:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._swords_3_count++;
                    break;
                case Type.item_shield_1:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._shield_1_count++;
                    break;
                case Type.item_shield_2:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._shield_2_count++;
                    break;
                case Type.item_shield_3:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._shield_3_count++;
                    break;
                case Type.item_amulet_1:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._amulet_1_count++;
                    break;
                case Type.item_amulet_2:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._amulet_2_count++;
                    break;
                case Type.item_amulet_3:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._amulet_2_count++;
                    break;
                case Type.item_egg_neutral:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._eggs_count++;
                    break;
                case Type.item_egg_undead:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._eggs_count++;
                    break;
                case Type.item_egg_order:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._eggs_count++;
                    break;
                case Type.item_egg_demons:
                    if (CheckELement(prize[i]) != null)
                        CheckELement(prize[i])._eggs_count++;
                    break;
                default:
                    break;
            }
            foreach (var item in Inventories)
            {
                item.CountInitialise();
                item.Initialise();
            }
        }
    }

    private Inventory CheckELement(Prize prize)
    {
        Debug.Log("prize element = " + prize._ElementType);

        switch (prize._ElementType)
        {
            case ElementType.Neutral:
                return Inventories[0];
            case ElementType.Undead:
                return Inventories[1];
            case ElementType.Order:
                return Inventories[2];
            case ElementType.Demon:
                return Inventories[3];
        }
        return null;
    }    
    #region Open inventory
    public void OpenFullInventory()
    {
        foreach (var item in Inventories)
        {
            item.OpenFullInventory();
        }
    } // open default inventory 
    public void OpenInventoryWithModifier_eggs()    // open inventory  with modifer egg
    {
        foreach (var item in Inventories)
        {
            item.OpenOnly_Eggs();
        }
    }
    public void OpenInventoryWithModifier_swords(Hero hero)    // open inventory  with modifer sword
    {
        foreach (var item in Inventories)
        {
            item.OpenOnly_Swords(hero.Level);
        }
    }
    public void OpenInventoryWithModifier_shields(Hero hero)    // open inventory  with modifer shield
    {
        
        foreach (var item in Inventories)
        {
            item.OpenOnly_Shields(hero.Level);
        }
    }
    public void OpenInventoryWithModifier_amulets(Hero hero)    // open inventory  with modifer amulet
    {
        foreach (var item in Inventories)
        {
            item.OpenOnly_Amulets(hero.Level);
        }
    }
    #endregion
    public void SwitchPanels(int index)
    {
        foreach (var item in Inventories)
        {
            item.gameObject.SetActive(false);
        }
        Inventories[index].gameObject.SetActive(true);
    }
    #region Save / Load
    public void SaveInventory()
    {
        SavedInventories.Clear();

        for (int i = 0; i < Inventories.Count; i++)
        {
            SavedInventories.Add(new SavedInvetory(Inventories[i]));
        }
        FileHandler.SaveToJSON<SavedInvetory>(SavedInventories, SaveFilename);
    }
    private void LoadInventory()
    {
        SavedInventories = FileHandler.ReadListFromJSON<SavedInvetory>(SaveFilename);
    }
    #endregion
}
[Serializable]
public class SavedInvetory
{
    public string _name;
    public int _eggs_count;
    public int _swords_1_count;
    public int _swords_2_count;
    public int _swords_3_count;
    public int _shield_1_count;
    public int _shield_2_count;
    public int _shield_3_count;
    public int _amulet_1_count;
    public int _amulet_2_count;
    public int _amulet_3_count;

    public SavedInvetory(Inventory inv)
    {
        inv.GetSaveInfo(out _name, out _eggs_count, out _swords_1_count, out _swords_2_count, out _swords_3_count, out _shield_1_count, out _shield_2_count, out _shield_3_count, out _amulet_1_count, out _amulet_2_count, out _amulet_3_count);
    }
}
