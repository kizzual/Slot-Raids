using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_quest : MonoBehaviour
{
    [SerializeField] private List<Tower_q_UI> tower_Quest_UI;
    [SerializeField] private QuestUI questUI;


    [SerializeField] private List<Quest> first_Line_quest;
    [SerializeField] private List<Quest> second_Line_quest;
    [SerializeField] private List<Quest> third_Line_quest;
    [SerializeField] private TowerUpgrade towerUpgrade;
    [SerializeField] private Inventory_controll inventory_controll;
    [SerializeField] private GameObject QuestPanel;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private GameObject Boost;
    [SerializeField] private GameObject Attention;

    public void ActivateEvent()
    {
        GlovalEventSystem.OnCheckAchievement += RaidComplete;
    }

    private int m_currentFirstLineQuestindex = 0;
    private int m_currentSecondLineQuestindex = 0;
    private int m_currentThitrdLineQuestindex = 0;

    private int m_currentRaid = 0;
    private long m_currentGold = 0;
    private int m_currentCombo = 0;
    private int m_currentLuck = 0;
    private int m_currentUnLuck = 0;
    private int m_raid = 0;
    private int m_raid_byElement_neutral = 0;
    private int m_raid_byElement_undead = 0;
    private int m_raid_byElement_order = 0;
    private int m_raid_byElement_demon = 0;

    public List<Item> m_items;// = new List<Item>();
    private void OnEnable()
    {
        First_Line_Quest_Initialise();
        Second_Line_Quest_Initialise();
        Third_Line_Quest_Initialise();
        questUI.Initialise(m_currentGold, m_currentRaid);
        AttentionIcon();
    }
    public void OpenQuestPanel()
    {
        QuestPanel.SetActive(true);
    }
    public void RaidComplete(List<Item> items, long goldValue, int combo, int unLuck)
    {
        m_items.Clear();
        for (int i = 0; i < items.Count; i++)
        {
            m_items.Add(items[i]);
        }
        m_currentGold += goldValue;
        m_currentRaid++;
        m_currentCombo = combo;
        m_currentLuck = items.Count;
        m_currentUnLuck = unLuck;
        if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order++;
            }
            else if(CurrentZone.Current_Zone.typeElement == Type__Element.Demon && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon++;
            }
       

        }
        if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Demon && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon++;
            }

        }
        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order++;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Demon && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon++;
            }

        }
        if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.heroRaid)
        {
            first_Line_quest[m_currentFirstLineQuestindex].goal.HeroRaid();
        }
        if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.heroRaid)
        {
            second_Line_quest[m_currentSecondLineQuestindex].goal.HeroRaid();
        }
        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.heroRaid)
        {
            third_Line_quest[m_currentThitrdLineQuestindex].goal.HeroRaid();
        }
        if(first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Raid_ByZone)
        {
            if (CurrentZone.Current_Zone ==  first_Line_quest[m_currentFirstLineQuestindex].goal.ZoneToRaid)
            {
                m_raid = 1;
            }
            else
            {
                m_raid = 0;
            }
        }
        if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Raid_ByZone)
        {
            if (CurrentZone.Current_Zone == second_Line_quest[m_currentSecondLineQuestindex].goal.ZoneToRaid)
            {
                m_raid = 1;
            }
            else
            {
                m_raid = 0;
            }
        }
        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Raid_ByZone)
        {
            if (CurrentZone.Current_Zone == third_Line_quest[m_currentThitrdLineQuestindex].goal.ZoneToRaid)
            {
                m_raid = 1;
            }
            else
            {
                m_raid = 0;
            }
        }


        questUI.Initialise(m_currentGold, m_currentRaid);
        RaidConplete();
        First_Line_Quest_Initialise();
        Second_Line_Quest_Initialise();
        Third_Line_Quest_Initialise();
        AttentionIcon();
    }
    public void RaidConplete()
    { 
        if (m_currentFirstLineQuestindex < first_Line_quest.Count)
        {
            if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Gold_Gathering)
            {
                if (first_Line_quest[m_currentFirstLineQuestindex].PassItems)
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                    }
                }
                else
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.GoldGathering(m_currentGold);
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                    }
                }

            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Combo_Gathering)
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.ComboGathering(m_currentCombo);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Raid_Gathering) //
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGathering(m_currentRaid);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Upgrade_Tower)
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.UpgradeTower(towerUpgrade.currentGrade);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Luck_Gathering)
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.LuckGathering(m_currentLuck);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Death_Gathering)
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.UnLuckGathering(m_currentUnLuck);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Item_Gathering)
            {
                for (int i = 0; i < m_items.Count; i++)
                {
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem != null)
                    {
                        if (m_items[i] == first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem)
                        {
                            first_Line_quest[m_currentFirstLineQuestindex].goal.ItemGathering(1, 0, 0);
                        }
                    }
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem != null)
                    {
                        if (m_items[i] == first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem)
                        {
                            first_Line_quest[m_currentFirstLineQuestindex].goal.ItemGathering(0, 1, 0);
                        }
                    }
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem != null)
                    {
                        if (m_items[i] == first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem)
                        {
                            first_Line_quest[m_currentFirstLineQuestindex].goal.ItemGathering(0, 0, 1);
                        }
                    }
                }
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsItemColeted())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
                m_items.Clear();
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement) //
            {

                first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byElement(CurrentZone.Current_Zone.RaidsCount);
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            
/*                else if (first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Undead)
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_undead);
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                       
                    }
                    m_raid_byElement_undead = 0;
                }
                else if (first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Order)
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_order);
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                       
                    }
                    m_raid_byElement_order = 0;

                }
                else if (first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Demon)
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_demon);
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                       
                    }
                    m_raid_byElement_demon = 0;
                }*/

            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Raid_ByZone) //
            {
                if (CurrentZone.Current_Zone == first_Line_quest[m_currentFirstLineQuestindex].goal.ZoneToRaid)
                {
                    first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byZone(CurrentZone.Current_Zone.RaidsCount);
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[0].QuestComplete();
                        m_raid = 0;
                    }
                }
            }

        }
        if (m_currentSecondLineQuestindex < second_Line_quest.Count)
        {
            if (m_currentSecondLineQuestindex != 0)
            {
                if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Gold_Gathering)
                {
                    if (second_Line_quest[m_currentSecondLineQuestindex].PassItems)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                    }
                    else
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(m_currentGold);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                    }

                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Combo_Gathering)
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.ComboGathering(m_currentCombo);
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Raid_Gathering) //
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGathering(m_currentRaid);
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Upgrade_Tower)
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.UpgradeTower(towerUpgrade.currentGrade);
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Luck_Gathering)
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.LuckGathering(m_currentLuck);
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Death_Gathering)
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.UnLuckGathering(m_currentUnLuck);
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Item_Gathering)
                {
                    for (int i = 0; i < m_items.Count; i++)
                    {
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(1, 0, 0);
                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(0, 1, 0);
                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(0, 0, 1);
                            }
                        }
                    }
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsItemColeted())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                    m_items.Clear();
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement) //
                {
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Neutral)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_neutral);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                            m_raid_byElement_neutral = 0;
                        }
                    }
                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Undead)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_undead);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                            m_raid_byElement_undead = 0;
                        }
                    }
                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Order)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_order);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                            m_raid_byElement_order = 0;
                        }
                    }
                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Demon)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_demon);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                            m_raid_byElement_demon = 0;
                        }
                    }

                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Raid_ByZone) //
                {
                    if (CurrentZone.Current_Zone == second_Line_quest[m_currentSecondLineQuestindex].goal.ZoneToRaid)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byZone(CurrentZone.Current_Zone.RaidsCount);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                            m_raid = 0;
                        }
                    }
                }
            }
            else if(m_currentSecondLineQuestindex == 0)
            {
                if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Gold_Gathering)
                {
                    if(towerUpgrade.currentGrade == 1)
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(1000);
                    }
                    else
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(0);
                    }                    
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Item_Gathering)
                {
                    for (int i = 0; i < m_items.Count; i++)
                    {
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(1, 0, 0);
                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(0, 1, 0);
                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem != null)
                        {
                            if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem)
                            {
                                second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(0, 0, 1);
                            }
                        }
                    }
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsItemColeted())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                    m_items.Clear();
                }

            }
        }
        if (m_currentThitrdLineQuestindex < third_Line_quest.Count)
        {
            if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Gold_Gathering)
            {
                if (third_Line_quest[m_currentThitrdLineQuestindex].PassItems)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                    }
                }
                else
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.GoldGathering(m_currentGold);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                    }
                }

            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Combo_Gathering)
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.ComboGathering(m_currentCombo);
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Raid_Gathering) //
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGathering(m_currentRaid);
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
     
                    tower_Quest_UI[2].QuestComplete();
                }
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Upgrade_Tower)
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.UpgradeTower(towerUpgrade.currentGrade);
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Luck_Gathering)
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.LuckGathering(m_currentLuck);
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Death_Gathering)
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.UnLuckGathering(m_currentUnLuck);
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Item_Gathering)
            {
                for (int i = 0; i < m_items.Count; i++)
                {
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem != null)
                    {
                        if (m_items[i] == third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem)
                        {
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.ItemGathering(1, 0, 0);
                        }
                    }
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem != null)
                    {
                        if (m_items[i] == third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem)
                        {
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.ItemGathering(0, 1, 0);
                        }
                    }
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem != null)
                    {
                        if (m_items[i] == third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem)
                        {
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.ItemGathering(0, 0, 1);
                        }
                    }
                }
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsItemColeted())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
                m_items.Clear();
            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement) //
            {
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Neutral)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_neutral);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                        m_raid_byElement_neutral = 0;
                    }
                }
                else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Undead)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_undead);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                        m_raid_byElement_undead = 0;
                    }
                }
                else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Order)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_order);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                        m_raid_byElement_order = 0;
                    }
                }
                else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Demon)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byElement(m_raid_byElement_demon);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                        m_raid_byElement_demon = 0;
                    }
                }

            }
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Raid_ByZone) //
            {
                if (CurrentZone.Current_Zone == third_Line_quest[m_currentThitrdLineQuestindex].goal.ZoneToRaid)
                {
                    third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byZone(CurrentZone.Current_Zone.RaidsCount);
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[2].QuestComplete();
                        m_raid = 0;
                    }
                }
            }

          
        }

    }

    private void AttentionIcon()
    {
  /*      if(first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached() ||
            second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached() ||
            third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached() )
        {
            Attention.SetActive(true);
            Debug.Log("ACTIVE", gameObject);
        }
        else
        {
            Attention.SetActive(false);
            Debug.Log("DEACTIVE", gameObject);

        }*/
    }
    private void First_Line_Quest_Initialise()
    {
        if (m_currentFirstLineQuestindex < first_Line_quest.Count)
        {
            RaidConplete();
            tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
            RaidConplete();
        }
        else
            tower_Quest_UI[0].gameObject.SetActive(false);
    }
    public void First_Line_Quest_finish()  // �������� �������� �������� ������� �������� �����
    {
        if (first_Line_quest[m_currentFirstLineQuestindex].PassItems)
        {
            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType)
            {
                case GoalType.Gold_Gathering:
                    if (Gold.GetCurrentGold() >= first_Line_quest[m_currentFirstLineQuestindex].goal.requiredAmount)
                    {
                        Gold.SpendGold(first_Line_quest[m_currentFirstLineQuestindex].goal.requiredAmount);
                        switch (first_Line_quest[m_currentFirstLineQuestindex].rewardType)
                        {
                            case Quest.RewardType.Hero:
                                first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isOpened = true;
                                break;
                            case Quest.RewardType.Gold:
                                Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                                break;
                        }
                        m_currentFirstLineQuestindex++;
                        First_Line_Quest_Initialise();
                    }
                    break;
                case GoalType.Item_Gathering:
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem != null)
                    {
                        switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem != null)
                    {
                        switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem != null)
                    {
                        switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    switch (first_Line_quest[m_currentFirstLineQuestindex].rewardType)
                    {
                        case Quest.RewardType.Hero:
                            first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isOpened = true;
                            break;
                        case Quest.RewardType.Gold:
                            Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                            break;
                        case Quest.RewardType.Boost:
                            boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                            break;
                        case Quest.RewardType.Location:
                            first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                            break;
                    }
                    m_currentFirstLineQuestindex++;
                    First_Line_Quest_Initialise();
                    break;
            }
        }
        else
        {
            switch (first_Line_quest[m_currentFirstLineQuestindex].rewardType)
            {
                case Quest.RewardType.Hero:
                    first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isOpened = true;
                    break;
                case Quest.RewardType.Gold:
                    Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                    break;
                case Quest.RewardType.Boost:
                    boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                    break;
                case Quest.RewardType.Location:
                    first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                    break;
            }
     
           m_currentFirstLineQuestindex++;
            First_Line_Quest_Initialise();
        }

    }
    private void Second_Line_Quest_Initialise()
    {
        if (m_currentSecondLineQuestindex < second_Line_quest.Count)
        {
            RaidConplete();
            tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
            RaidConplete();
        }
        else
            tower_Quest_UI[1].gameObject.SetActive(false);
    }
    public void Second_Line_Quest_finish()  // �������� �������� �������� ������� �������� �����
    {
        if (second_Line_quest[m_currentSecondLineQuestindex].PassItems)
        {
            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType)
            {
                case GoalType.Gold_Gathering:
                    if (Gold.GetCurrentGold() >= second_Line_quest[m_currentSecondLineQuestindex].goal.requiredAmount)
                    {
                        Gold.SpendGold(second_Line_quest[m_currentSecondLineQuestindex].goal.requiredAmount);
                        switch (second_Line_quest[m_currentSecondLineQuestindex].rewardType)
                        {
                            case Quest.RewardType.Hero:
                                second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isOpened = true;
                                break;
                            case Quest.RewardType.Gold:
                                Gold.AddGold(second_Line_quest[m_currentSecondLineQuestindex].GoldReward);
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                                break;
                        }
                        m_currentSecondLineQuestindex++;
                        Second_Line_Quest_Initialise();
                    }
                    break;
                case GoalType.Item_Gathering:
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem != null)
                    {
                        switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                    {
                        switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                    {
                        switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeItem)
                        {
                            case TypeItem.Sword:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_sword(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Shield:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_shield(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                            case TypeItem.Amulet:
                                for (int i = 0; i < second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                {
                                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                    else if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                        inventory_controll.TakeItem_amulet(second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                }
                                break;
                        }
                    }
                    switch (second_Line_quest[m_currentSecondLineQuestindex].rewardType)
                    {
                        case Quest.RewardType.Hero:
                            second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isOpened = true;
                            break;
                        case Quest.RewardType.Gold:
                            Gold.AddGold(second_Line_quest[m_currentSecondLineQuestindex].GoldReward);
                            break;
                        case Quest.RewardType.Boost:
                            boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                            break;
                        case Quest.RewardType.Location:
                            second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                            break;
                    }
                    m_currentSecondLineQuestindex++;
                    Second_Line_Quest_Initialise();

                    break;
            }
        }
        else
        {
            switch (second_Line_quest[m_currentSecondLineQuestindex].rewardType)
            {
                case Quest.RewardType.Hero:
                    second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isOpened = true;
                    break;
                case Quest.RewardType.Boost:
                    boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                    break;
                case Quest.RewardType.Location:
                    second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                    break;
            }
            m_currentSecondLineQuestindex++;
            Second_Line_Quest_Initialise();
        }
    }
    private void Third_Line_Quest_Initialise()
    {
        if (m_currentThitrdLineQuestindex < third_Line_quest.Count)
        {
            RaidConplete();
            tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
            RaidConplete();
        }
        else
            tower_Quest_UI[2].gameObject.SetActive(false);
    }
    public void Third_Line_Quest_finish()  // �������� �������� �������� ������� �������� �����
    {
        if (m_currentThitrdLineQuestindex != 0)
        {
            if (third_Line_quest[m_currentThitrdLineQuestindex].PassItems)
            {
                switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType)
                {
                    case GoalType.Gold_Gathering:
                        if (Gold.GetCurrentGold() >= third_Line_quest[m_currentThitrdLineQuestindex].goal.requiredAmount)
                        {
                            Gold.SpendGold(third_Line_quest[m_currentThitrdLineQuestindex].goal.requiredAmount);
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].rewardType)
                            {
                                case Quest.RewardType.Hero:
                                    third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isOpened = true;
                                    break;
                                case Quest.RewardType.Boost:
                                    boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                    break;
                                case Quest.RewardType.Location:
                                    third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                                    break;
                            }
                            m_currentThitrdLineQuestindex++;
                            Third_Line_Quest_Initialise();
                        }
                        break;
                    case GoalType.Item_Gathering:
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }
                        switch (third_Line_quest[m_currentThitrdLineQuestindex].rewardType)
                        {
                            case Quest.RewardType.Hero:
                                third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isOpened = true;
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                                break;
                        }
                        m_currentThitrdLineQuestindex++;
                        Third_Line_Quest_Initialise();

                        break;
                }
            }
            else
            {
                switch (third_Line_quest[m_currentThitrdLineQuestindex].rewardType)
                {
                    case Quest.RewardType.Hero:
                        third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isOpened = true;
                        break;
                    case Quest.RewardType.Boost:
                        boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                        break;
                    case Quest.RewardType.Location:
                        third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                        break;
                }
                m_currentThitrdLineQuestindex++;
                Third_Line_Quest_Initialise();
            }
        }
        else if(m_currentThitrdLineQuestindex == 0)
        {
            Boost.SetActive(true);
            boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
            m_currentThitrdLineQuestindex++;
            Third_Line_Quest_Initialise();

        }
    }
}