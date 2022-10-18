using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCombo : MonoBehaviour
{
    [SerializeField] private Inventory_controll inventory_Controll;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private Raid_control raidControl;
    [SerializeField] private QuestControll QuestControll;
    [SerializeField] private OfflineGreating offline_greatings;
    [SerializeField] private List<Raid_button> raid_buttons;

    private int m_boostGold = 1;
    private int m_boostItem = 1;


    public void CheckOfflinePrize()
    {
        if (PlayerPrefs.HasKey("LastSession"))
        { 

            long tmp = Utils.GetSeconds("LastSession");
   //         Debug.Log("tmp =  " + tmp);
            int totalOfflineRaids = (int)(tmp / 20);

            //     Debug.Log("OfflineRaids =  " + totalOfflineRaids);
            List<Raid_UI> slots = raidControl.CheckWinPrize();

            List<Item> winItems = new List<Item>();
            long winGold = 0;
            bool isEmptyRaid = true;
            for (int k = 0; k < totalOfflineRaids; k++)
            {
                raidControl.CheckOffLinePrize();

                for (int i = 0; i < slots.Count; i++)
                {
       //             Debug.Log("CheckSlot  id =   " + i + "   isOpened  " + slots[i].isOpened + "   and current hero   =   " + slots[i].m_currentHero);
                    if (slots[i].isOpened && slots[i].m_currentHero != null)
                    {
                        isEmptyRaid = false;
                        slots[i].m_currentHero.GoToRaid();
                        if (slots[i].GetDice().prize == DiceControll.Prize.Item)
                        {
                            for (int j = 0; j < m_boostItem; j++)
                            {
                                winItems.Add(slots[i].GetDice().winItem);
                            }
                            raidControl.GetParticles().PlayParticleWitItem(i, slots[i].GetDice().winItem);
                            winGold += slots[i].m_currentHero.GetGoldProfit();
                            Debug.Log("item  id =   " + i);
                        }
                        else if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                        {
                            winGold += slots[i].m_currentHero.GetGoldProfit();
                            raidControl.GetParticles().PlayParticleWitoutItem(i);
                            Debug.Log("gold  id =   " + i);
                        }

                    }
                }
            }
            if (!isEmptyRaid)
            {
                for (int i = 0; i < totalOfflineRaids; i++)
                {
                    CurrentZone.Current_Zone.GoToRaid();
                }
            }
            if (totalOfflineRaids > 0)
            {
        //        Debug.Log("CHECK Offline  _  1" );
       //         Debug.Log(winGold * m_boostGold + "  win + boost");
                Gold.AddGold(winGold * m_boostGold);

                QuestControll.RaidConplete( winGold * m_boostGold);
                
                ItemsAwarding(winItems);

                offline_greatings.OfflineReward(winGold, winItems);
            }
        }
        foreach (var item in raid_buttons)
        {  
            if (item.gameObject.activeSelf)
            {
                item.GoRaidAfterOffline();
            }
        }
    }

    private void ItemsAwarding(List<Item> winItems)
    {
        for (int i = 0; i < winItems.Count; i++)
        {
            inventory_Controll.ReturnItem(winItems[i]);
        }
        boost_Controll.RaidComplete();
        raidControl.DisplayWinItems(winItems);
    }
}
