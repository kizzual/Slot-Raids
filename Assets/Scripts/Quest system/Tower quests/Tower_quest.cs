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
    private List<Item> m_items = new List<Item>();
    private void OnEnable()
    {
        First_Line_Quest_Initialise();
        Second_Line_Quest_Initialise();
        Third_Line_Quest_Initialise();
        questUI.Initialise(m_currentGold, m_currentRaid);
    }
    public void OpenQuestPanel()
    {
        QuestPanel.SetActive(true);
    }
    public void RaidComplete(List<Item> items, long goldValue, int combo, int unLuck)
    {
        m_currentGold += goldValue;
        m_currentRaid++;
        m_currentCombo = combo;
        m_currentLuck = items.Count;
        m_currentUnLuck = unLuck;
        m_raid++;
        m_items = items;
        questUI.Initialise(m_currentGold, m_currentRaid);
        RaidConplete();
        First_Line_Quest_Initialise();
        Second_Line_Quest_Initialise();
        Third_Line_Quest_Initialise();
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
                first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGathering(m_raid);
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
                            first_Line_quest[m_currentFirstLineQuestindex].goal.ItemGathering(1, 0);
                        }
                    }
                    if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem != null)
                    {
                        if (m_items[i] == first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem)
                        {
                            first_Line_quest[m_currentFirstLineQuestindex].goal.ItemGathering(0, 1);
                        }
                    }
                }
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsItemColeted())
                {
                    tower_Quest_UI[0].QuestComplete();
                }
            }
        }
        if (m_currentSecondLineQuestindex < second_Line_quest.Count)
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
                            second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(1, 0);
                        }
                    }
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                    {
                        if (m_items[i] == second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem)
                        {
                            second_Line_quest[m_currentSecondLineQuestindex].goal.ItemGathering(0, 1);
                        }
                    }
                }
                if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsItemColeted())
                {
                    tower_Quest_UI[1].QuestComplete();
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
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.ItemGathering(1, 0);
                        }
                    }
                    if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem != null)
                    {
                        if (m_items[i] == third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem)
                        {
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.ItemGathering(0, 1);
                        }
                    }
                }
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsItemColeted())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
        }
     
       
      
    }


    private void First_Line_Quest_Initialise()
    {
        if (m_currentFirstLineQuestindex < first_Line_quest.Count)
        {
            RaidConplete();
            tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
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
                                //���� ����
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
                    //���� ����
                    break;
            }
            m_raid = 0;
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
                                //���� ����
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
                case Quest.RewardType.Gold:
                    Gold.AddGold(second_Line_quest[m_currentSecondLineQuestindex].GoldReward);
                    break;
                case Quest.RewardType.Boost:
                    //���� ����
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
        }
        else
            tower_Quest_UI[2].gameObject.SetActive(false);
    }
    public void Third_Line_Quest_finish()  // �������� �������� �������� ������� �������� �����
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
                            case Quest.RewardType.Gold:
                                Gold.AddGold(third_Line_quest[m_currentThitrdLineQuestindex].GoldReward);
                                break;
                            case Quest.RewardType.Boost:
                                //���� ����
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
                case Quest.RewardType.Gold:
                    Gold.AddGold(third_Line_quest[m_currentThitrdLineQuestindex].GoldReward);
                    break;
                case Quest.RewardType.Boost:
                    //���� ����
                    break;
            }
            m_currentThitrdLineQuestindex++;
            Third_Line_Quest_Initialise();
        }
    }
}