using System.Collections.Generic;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public enum QuestPanelType
    {
        Tower,
        Green,
        Blue,
        Yellow,
        Red
    }
    public QuestPanelType questPanelType;
    [SerializeField] private List<Tower_q_UI> tower_Quest_UI;
    [SerializeField] private List<Quest> first_Line_quest;
    [SerializeField] private List<Quest> second_Line_quest;
    [SerializeField] private List<Quest> third_Line_quest;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Inventory_controll inventory_controll;
    [SerializeField] private DisplayReward m_displayReward;
    [SerializeField] private Boost_Controll m_boostControll;
    [SerializeField] private GameObject CardButton;

    public int m_currentFirstLineQuestindex { get; set; } = 0;
    public int m_currentSecondLineQuestindex { get; set; } = 0;
    public int m_currentThitrdLineQuestindex { get; set; } = 0;
    private int m_rewardLine;
    public int raidsCount { get; set; }
    public long goldsCount { get; set; }
    private int currentTowerGrade;
    public void GetRaidInfo(int towerGrade, int raidsCount, long goldsCount)
    {
        this.raidsCount = raidsCount;
        this.goldsCount = goldsCount;
        currentTowerGrade = towerGrade;
        CheckLineQuest_first();
        CheckLineQuest_seoncd();
        CheckLineQuest_third();
    }
    private void CheckLineQuest_first()
    { 
        if (m_currentFirstLineQuestindex < first_Line_quest.Count)
        {
            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType)
            {
                case GoalType.Gold_Gathering:
                    {
                       
                        first_Line_quest[m_currentFirstLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                        {
                           
                            tower_Quest_UI[0].QuestComplete();
                        }
                        break;
                    }
                // реализовать combo_Gathering:
                case GoalType.Raid_Gathering:
                    {
                        first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGathering(raidsCount);
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[0].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Upgrade_Tower:
                    {
                        first_Line_quest[m_currentFirstLineQuestindex].goal.UpgradeTower(currentTowerGrade);
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal. IsReached())
                        {
                            Debug.Log("Cmplete");
                            tower_Quest_UI[0].QuestComplete();
                        }
                        break;
                    }
                // реализовать Luck_Gathering
                // реализовать Death_Gathering
                case GoalType.Item_Gathering:
                    {
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem != null)
                        {
                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }
                        }
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem != null)
                        {
                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem != null)
                        {
                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (first_Line_quest[m_currentFirstLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    first_Line_quest[m_currentFirstLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsItemColeted())
                        {
                            tower_Quest_UI[0].QuestComplete();
                        }

                        break;
                    }
                case GoalType.raid_Gathering_byElement:
                    {
                        first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byElement(CurrentZone.Current_Zone.RaidsCount);
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[0].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Raid_ByZone:
                    {
                        Debug.Log(first_Line_quest[m_currentFirstLineQuestindex].goal.ZoneToRaid.nameLocation);
                        Debug.Log(CurrentZone.Current_Zone.nameLocation);

                        first_Line_quest[m_currentFirstLineQuestindex].goal.RaidGarhering_byZone(first_Line_quest[m_currentFirstLineQuestindex].goal.ZoneToRaid.RaidsCount);
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[0].QuestComplete();

                        }
                        break;
                    }
                case GoalType.heroRaid:
                    {
                        first_Line_quest[m_currentFirstLineQuestindex].goal.HeroRaid();
                        tower_Quest_UI[0].Initialise_quest(first_Line_quest[m_currentFirstLineQuestindex]);
                        if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[0].QuestComplete();
                        }
                        break;
                    }
            }
        }
     
    }
    private void CheckLineQuest_seoncd()
    {
        if (m_currentSecondLineQuestindex < second_Line_quest.Count)
        {
            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType)
            {
                case GoalType.Gold_Gathering:
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                        break;
                    }
                // реализовать combo_Gathering:
                case GoalType.Raid_Gathering:
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGathering(raidsCount);
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Upgrade_Tower:
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.UpgradeTower(currentTowerGrade);
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                        break;
                    }
                // реализовать Luck_Gathering
                // реализовать Death_Gathering
                case GoalType.Item_Gathering:
                    {
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem != null)
                        {
                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem != null)
                        {
                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem != null)
                        {
                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    second_Line_quest[m_currentSecondLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsItemColeted())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }

                        break;
                    }
                case GoalType.raid_Gathering_byElement:
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byElement(CurrentZone.Current_Zone.RaidsCount);
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Raid_ByZone:
                    {
                        if (CurrentZone.Current_Zone == second_Line_quest[m_currentSecondLineQuestindex].goal.ZoneToRaid)
                        {
                            second_Line_quest[m_currentSecondLineQuestindex].goal.RaidGarhering_byZone(second_Line_quest[m_currentSecondLineQuestindex].goal.ZoneToRaid.RaidsCount);
                            tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                            if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                            {
                                tower_Quest_UI[1].QuestComplete();

                            }
                        }
                        break;
                    }
                case GoalType.heroRaid:
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.HeroRaid();
                        tower_Quest_UI[1].Initialise_quest(second_Line_quest[m_currentSecondLineQuestindex]);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[1].QuestComplete();
                        }
                        break;
                    }

            }
        }
    }
    private void CheckLineQuest_third()
    {
        if (m_currentThitrdLineQuestindex < third_Line_quest.Count)
        {
            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType)
            {
                case GoalType.Gold_Gathering:
                    {
                        third_Line_quest[m_currentThitrdLineQuestindex].goal.GoldGathering(Gold.GetCurrentGold());
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }
                        break;
                    }
                // реализовать combo_Gathering:
                case GoalType.Raid_Gathering:
                    {
                        third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGathering(raidsCount);
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Upgrade_Tower:
                    {
                        third_Line_quest[m_currentThitrdLineQuestindex].goal.UpgradeTower(currentTowerGrade);
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }
                        break;
                    }
                // реализовать Luck_Gathering
                // реализовать Death_Gathering
                case GoalType.Item_Gathering:
                    {
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.firstItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.FirstItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }
                        }
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.secondItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.SecondItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem != null)
                        {
                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetSword_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Shield:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetShield_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.typeElement)
                                    {
                                        case Type_Element.Neutral:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Neutral));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Neutral));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Neutral));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Undead:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Undead));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Undead));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Undead));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Order:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Order));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Order));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Order));
                                                    break;
                                            }
                                            break;
                                        case Type_Element.Demon:
                                            switch (third_Line_quest[m_currentThitrdLineQuestindex].goal.thirdItem.Rank)
                                            {
                                                case 1:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(1, TypeElement.Demon));
                                                    break;
                                                case 2:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(2, TypeElement.Demon));
                                                    break;
                                                case 3:
                                                    third_Line_quest[m_currentThitrdLineQuestindex].goal.ThirdItemGathering(inventory_controll.GetAmulet_count(3, TypeElement.Demon));
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                            }
                        }
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsItemColeted())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }

                        break;
                    }
                case GoalType.raid_Gathering_byElement:
                    {
                        third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byElement(CurrentZone.Current_Zone.RaidsCount);
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }
                        break;
                    }
                case GoalType.Raid_ByZone:
                    {
                        if (CurrentZone.Current_Zone == third_Line_quest[m_currentThitrdLineQuestindex].goal.ZoneToRaid)
                        {
                            third_Line_quest[m_currentThitrdLineQuestindex].goal.RaidGarhering_byZone(third_Line_quest[m_currentThitrdLineQuestindex].goal.ZoneToRaid.RaidsCount);
                            tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                            if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                            {
                                tower_Quest_UI[2].QuestComplete();

                            }
                        }
                        break;
                    }
                case GoalType.heroRaid:
                    {
                        third_Line_quest[m_currentThitrdLineQuestindex].goal.HeroRaid();
                        tower_Quest_UI[2].Initialise_quest(third_Line_quest[m_currentThitrdLineQuestindex]);
                        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                        {
                            tower_Quest_UI[2].QuestComplete();
                        }
                        break;
                    }

            }
        }
    }

    public void CompleteQuestAndReward(int lineIndex)
    {
        List<Quest> line = new List<Quest>();
        if (lineIndex == 0)
        {
            line = first_Line_quest;
            m_rewardLine = m_currentFirstLineQuestindex;
            m_currentFirstLineQuestindex++;
        }
        else if( lineIndex == 1)
        {
            line =  second_Line_quest;
            m_rewardLine = m_currentSecondLineQuestindex;
            m_currentSecondLineQuestindex++;
        }
        else
        {
            line = third_Line_quest;
            m_rewardLine = m_currentThitrdLineQuestindex;
            m_currentThitrdLineQuestindex++;
        }
        if (line[m_rewardLine].PassItems)
        {
            switch (line[m_rewardLine].goal.goalType)
            {
                case GoalType.Item_Gathering:
                    {
                        if (line[m_rewardLine].goal.firstItem != null)
                        {
                            switch (line[m_rewardLine].goal.firstItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < line[m_rewardLine].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < line[m_rewardLine].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < line[m_rewardLine].goal.firstItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.firstItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.firstItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }
                        if (line[m_rewardLine].goal.secondItem != null)
                        {
                            switch (line[m_rewardLine].goal.secondItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < line[m_rewardLine].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < line[m_rewardLine].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < line[m_rewardLine].goal.secondItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.secondItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.secondItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }
                        if (line[m_rewardLine].goal.thirdItem != null)
                        {
                            switch (line[m_rewardLine].goal.thirdItem.typeItem)
                            {
                                case TypeItem.Sword:
                                    for (int i = 0; i < line[m_rewardLine].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_sword(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Shield:
                                    for (int i = 0; i < line[m_rewardLine].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_shield(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                                case TypeItem.Amulet:
                                    for (int i = 0; i < line[m_rewardLine].goal.thirdItem_requiredAmount; i++)
                                    {
                                        if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Neutral)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Neutral);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Undead)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Undead);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Order)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Order);
                                        else if (line[m_rewardLine].goal.thirdItem.typeElement == Type_Element.Demon)
                                            inventory_controll.TakeItem_amulet(line[m_rewardLine].goal.thirdItem.Rank, TypeElement.Demon);
                                    }
                                    break;
                            }
                        }

                        switch (line[m_rewardLine].rewardType)
                        {
                            case Quest.RewardType.Hero:
                                line[m_rewardLine].HeroReward.isOpened = true;
                                line[m_rewardLine].HeroReward.isNewHero = true;
                                //             char_Controller.CheckForNewHeroes();
                                m_displayReward.Initialise(line[m_rewardLine].HeroReward);
                                break;
                            case Quest.RewardType.Boost:
                                m_boostControll.OpenCard(line[m_rewardLine].BoostCard);
                                m_displayReward.Initialise(line[m_rewardLine].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                line[m_rewardLine].Location.isOpened = true;
                                line[m_rewardLine].Location.isNewZone = true;
                                //        checkAttentionIcon.CheckAttention();
                                m_displayReward.Initialise(line[m_rewardLine].Location);
                                break;
                        }
                        break;
                    }
            }
        }
        else if (!line[m_rewardLine].PassItems)
        {
            if (!line[m_rewardLine].isCustomReward)
            {
                switch (line[m_rewardLine].rewardType)
                {
                    case Quest.RewardType.Hero:
                        line[m_rewardLine].HeroReward.isOpened = true;
                        line[m_rewardLine].HeroReward.isNewHero = true;
                        //             char_Controller.CheckForNewHeroes();
                        m_displayReward.Initialise(line[m_rewardLine].HeroReward);
                        break;
                    case Quest.RewardType.Boost:
                        m_boostControll.OpenCard(line[m_rewardLine].BoostCard);
                        m_displayReward.Initialise(line[m_rewardLine].BoostCard);
                        break;
                    case Quest.RewardType.Location:
                        line[m_rewardLine].Location.isOpened = true;
                        line[m_rewardLine].Location.isNewZone = true;
                        //        checkAttentionIcon.CheckAttention();
                        m_displayReward.Initialise(line[m_rewardLine].Location);
                        break;
                    case Quest.RewardType.Slot:
                        m_displayReward.Initialise();
                        raid_control.StopRaid();
                        raid_control.CheckGrade(PlayerPrefs.GetInt("TowerLvl"));
                        raid_control.StartRaid();

                        break;
                }
            }
            else if(line[m_rewardLine].isCustomReward)
            {
                if(line[m_rewardLine].customRewardID == 0)
                {
                    CardButton.SetActive(true);
                    m_boostControll.OpenCard(line[m_rewardLine].BoostCard);
                    m_boostControll.OpenCard(line[m_rewardLine].customBoost);
                    m_displayReward.Initialise(line[m_rewardLine].BoostCard);
                }
            }

        }

     
        if(lineIndex == 0)
        {
            CheckLineQuest_first();
        }
        else if(lineIndex == 1)
        {
            CheckLineQuest_seoncd();
        }
        else
        {
            CheckLineQuest_third();
        }
        if (m_rewardLine + 1 <= line.Count)
        {
            tower_Quest_UI[lineIndex].Initialise_quest(line[m_rewardLine + 1]);
        }
        else
        {
            tower_Quest_UI[lineIndex].gameObject.SetActive(false);
        }
    }

    public List<Quest> GetFirstLineQuest() => first_Line_quest;
    public List<Quest> GetSecondLineQuest() => second_Line_quest;
    public List<Quest> GetThirdLineQuest() => third_Line_quest;

}


