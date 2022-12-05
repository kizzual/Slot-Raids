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
    [SerializeField] private BaseLoader baseLoader;
    [SerializeField] private MainTutorial MainTutorial;

    private int m_boostGold = 1;
    private int m_boostItem = 1;


    public void CheckOfflinePrize()
    {
        if (MainTutorial.mainTutorIsEnded &&
                MainTutorial.secondTutorIsEnded &&
                MainTutorial.thirdTutorIsEnded)
        { 

            long tmp = Utils.GetSeconds("LastSession");
            
            int totalOfflineRaids = (int)(tmp / 20);
            if (totalOfflineRaids > 1000)
                totalOfflineRaids = 1000;

            List<Raid_UI> slots = raidControl.CheckWinPrize();

            List<Item> winItems = new List<Item>();
            long winGold = 0;
            bool isEmptyRaid = true;
            for (int k = 0; k < totalOfflineRaids; k++)
            {
                raidControl.CheckOffLinePrize();

                for (int i = 0; i < slots.Count; i++)
                {
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
                            winGold += slots[i].m_currentHero.GetGoldProfit();
                        }
                        else if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                        {
                            winGold += slots[i].m_currentHero.GetGoldProfit();
                        }

                    }
                }
                boost_Controll.RaidComplete();
            }
            if (!isEmptyRaid)
            {
                QuestControll.OfflineRaids(totalOfflineRaids);
                CurrentZone.Current_Zone.OffLineRaid(totalOfflineRaids);
            }
            if (totalOfflineRaids > 0)
            {
                Gold.AddGold(winGold * m_boostGold);
               
                QuestControll.RaidConplete(winGold * m_boostGold);

                ItemsAwarding(winItems);

                offline_greatings.OfflineReward(winGold, winItems);
                baseLoader.SaveAll();
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
        
        raidControl.DisplayWinItems(winItems);
    }

}
