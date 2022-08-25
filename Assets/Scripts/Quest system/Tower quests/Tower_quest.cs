using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_quest : MonoBehaviour
{
    [SerializeField] private List<Tower_q_UI> tower_Quest_UI;
    [SerializeField] private QuestUI questUI;


    public List<Quest> first_Line_quest;
    public List<Quest> second_Line_quest;
    public List<Quest> third_Line_quest;
    [SerializeField] private TowerUpgrade towerUpgrade;
    [SerializeField] private Inventory_controll inventory_controll;
    [SerializeField] private GameObject QuestPanel;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private GameObject Boost;
    [SerializeField] private GameObject Boostimg;
    [SerializeField] private List<GameObject> Attention;
    [SerializeField] private GameObject TowerButton;
    [SerializeField] private DisplayReward displayReward;
    [SerializeField] private Hero B_1_Hero;
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private CheckAttentionIcon checkAttentionIcon;
    [SerializeField] private List<Button> raidbuttons;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnUpgradeTower += AttentionIcon;
        GlovalEventSystem.OnCheckAchievement += RaidComplete;
    }

    public int m_currentFirstLineQuestindex { get; set; } = 0;
    public int m_currentSecondLineQuestindex { get; set; } = 0;
    public int m_currentThitrdLineQuestindex { get; set; } = 0;

    public int m_currentRaid { get; set; } = 0;
    public long m_currentGold { get; set; } = 0;
    private int m_currentCombo = 0;
    private int m_currentLuck = 0;
    private int m_currentUnLuck = 0;
    private int m_raid = 0;
    private int m_raid_byElement_neutral = 0;
    private int m_raid_byElement_undead = 0;
    private int m_raid_byElement_order = 0;
    private int m_raid_byElement_demon = 0;
    private bool tutori_1 = false;
    private bool tutori_2 = false;
    private bool tutori_3 = false;
    private bool tutorHero = false;
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
        TowerButton.transform.GetChild(1).gameObject.SetActive(false);
        TowerButton.transform.GetChild(2).gameObject.SetActive(true);
      //  GlovalEventSystem.TutorialSteps(2);
     //   if(Tutorial.CheckTutorStep() == 16)
    //    {
    //        GlovalEventSystem.TutorialStepsThirdPart(16);
     //   }
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
        m_raid_byElement_neutral = 0;
        m_raid_byElement_undead = 0;
        m_raid_byElement_order = 0;
        m_raid_byElement_demon = 0;
        if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Demon && first_Line_quest[m_currentFirstLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon = 1;
            }


        }
        if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Demon && second_Line_quest[m_currentSecondLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon = 1;
            }

        }
        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.raid_Gathering_byElement)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Neutral)
            {
                m_raid_byElement_neutral = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Undead && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Undead)
            {
                m_raid_byElement_undead = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Order && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Order)
            {
                m_raid_byElement_order = 1;
            }
            else if (CurrentZone.Current_Zone.typeElement == Type__Element.Demon && third_Line_quest[m_currentThitrdLineQuestindex].goal.elementType == TypElement.Demon)
            {
                m_raid_byElement_demon = 1;
            }

        }

        if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Raid_ByZone)
        {
            if (CurrentZone.Current_Zone == first_Line_quest[m_currentFirstLineQuestindex].goal.ZoneToRaid)
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

        if (m_currentRaid > 100)
        {
            foreach (var item in raidbuttons)
            {
                item.gameObject.SetActive(true);
            }
        }
        questUI.Initialise(m_currentGold, m_currentRaid);
        RaidConplete();
        First_Line_Quest_Initialise();
        Second_Line_Quest_Initialise();
        Third_Line_Quest_Initialise();
        AttentionIcon();
        if (TutorialSystem.tutorSystem.m_currentIncdex_mainTutorial == 13)
        {
            if (Gold.GetCurrentGold() > 0)
            {
                TutorialSystem.tutorSystem.MainTutorial();
            }
        }
        if(TutorialSystem.tutorSystem.m_currentIncdex_mainTutorial == 27)
        {
            if(m_currentGold >= 1000)
            {
                TutorialSystem.tutorSystem.MainTutorial();
            }
        }
        if (TutorialSystem.tutorSystem.m_currentIncdex_mainTutorial == 33)
        {
            if (Gold.GetCurrentGold() >= 10000)
            {
         
                TutorialSystem.tutorSystem.MainTutorial();
            }
        }

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
                        if(!tutori_2 || !tutori_3)
                        {
                            if(m_currentFirstLineQuestindex == 0)
                            {
                                if (TutorialSystem.tutorSystem.m_currentIndex_openBoostTutorial == 0)
                                {
                                    tutori_3 = true;
                                    TutorialSystem.tutorSystem.BoostTutorial();
                                }
                            }
                            if (m_currentFirstLineQuestindex == 1)
                            {
                                if (TutorialSystem.tutorSystem.m_currentIndex_locationTutorial == 0)
                                {
                                    tutori_2 = true;
                                    TutorialSystem.tutorSystem.LocationTutorial();
                                }
                            }
                        }
                    }
                }
            }
            else if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.heroRaid)
            {
                first_Line_quest[m_currentFirstLineQuestindex].goal.HeroRaid();
                if (first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[0].QuestComplete();
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
                        /*    if (m_currentSecondLineQuestindex == 2 && B_1_Hero != null && towerUpgrade.currentGrade > 1)
                            {
                                if (!tutori_3)
                                {
                                    if (TutorialSystem.tutorSystem.m_currentIndex_openHeroTutorial == 0)
                                    {
                                        tutori_3 = true;
                                        TutorialSystem.tutorSystem.OpenHeroTutorial();
                                    }
                                }
                            }*/
                            tower_Quest_UI[1].QuestComplete();
                        }
                    }
                    else
                    {
                        second_Line_quest[m_currentSecondLineQuestindex].goal.GoldGathering(m_currentGold);
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                        {

                            if (B_1_Hero != null && m_currentSecondLineQuestindex == 2)
                            {
                                if (TutorialSystem.tutorSystem.m_currentIncdex_mainTutorial >= 34)
                                {
                                    tower_Quest_UI[1].QuestComplete();
                                }
                            }
                            else
                            {
                                tower_Quest_UI[1].QuestComplete();
                            }
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
                else if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.heroRaid)
                {
                    second_Line_quest[m_currentSecondLineQuestindex].goal.HeroRaid();
                    if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
                    {
                        tower_Quest_UI[1].QuestComplete();
                    }
                }
            }
            else if(m_currentSecondLineQuestindex == 0)
            {
                if (second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Gold_Gathering)
                {
                    if (towerUpgrade.currentGrade == 1)
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
                 
                    if(!tutori_1)
                    {
                        if (TutorialSystem.tutorSystem.m_currentIndex_openBoostTutorial == 6)
                        {
                            tutori_1 = true;
                            TutorialSystem.tutorSystem.BoostTutorial();
                        }
                    }
                   

      //              GlovalEventSystem.TutorialStepsThirdPart(14);
      //              PlayerPrefs.SetInt("Boost", 1 );
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
            else if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.heroRaid)
            {
                third_Line_quest[m_currentThitrdLineQuestindex].goal.HeroRaid();
                if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
                {
                    tower_Quest_UI[2].QuestComplete();
                }
            }
        }
    }

    private void AttentionIcon(int tmp = 0)
    {
        RaidConplete();
        if (first_Line_quest[m_currentFirstLineQuestindex].goal.goalType == GoalType.Item_Gathering)
        {
            if(first_Line_quest[m_currentFirstLineQuestindex].goal.IsItemColeted())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;
            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
                }
            }
        }
        else
        {
            if(first_Line_quest[m_currentFirstLineQuestindex].goal.IsReached())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;
            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
                }
            }
        }
        if(second_Line_quest[m_currentSecondLineQuestindex].goal.goalType == GoalType.Item_Gathering)
        {
            if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsItemColeted())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;

            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
                }
            }
        }
        else
        {
            if (second_Line_quest[m_currentSecondLineQuestindex].goal.IsReached())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;
            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
                }
            }
        }
        if (third_Line_quest[m_currentThitrdLineQuestindex].goal.goalType == GoalType.Item_Gathering)
        {
            if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsItemColeted())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;

            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
                }
            }
        }
        else
        {
            if (third_Line_quest[m_currentThitrdLineQuestindex].goal.IsReached())
            {
                foreach (var item in Attention)
                {
                    item.SetActive(true);
                }
                return;
            }
            else
            {
                foreach (var item in Attention)
                {
                    item.SetActive(false);
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
            RaidConplete();
        }
        else
            tower_Quest_UI[0].gameObject.SetActive(false);
        AttentionIcon();
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
                                first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isNewHero = true;
                                char_Controller.CheckForNewHeroes();
                                displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].HeroReward);
                                break;
                            case Quest.RewardType.Gold:
                                Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                                displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                                first_Line_quest[m_currentFirstLineQuestindex].Location.isNewZone = true;
                                checkAttentionIcon.CheckAttention();
                                displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].Location);
                                break;
                            case Quest.RewardType.Slot:
                                displayReward.Initialise();
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
                            first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isNewHero = true;
                            char_Controller.CheckForNewHeroes();
                            displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].HeroReward);
                            break;
                        case Quest.RewardType.Gold:
                            Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                            break;
                        case Quest.RewardType.Boost:
                            boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                            displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                            break;
                        case Quest.RewardType.Location:
                            first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                            first_Line_quest[m_currentFirstLineQuestindex].Location.isNewZone = true;
                            checkAttentionIcon.CheckAttention();
                            displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].Location);
                            break;
                        case Quest.RewardType.Slot:
                            displayReward.Initialise();
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
                    first_Line_quest[m_currentFirstLineQuestindex].HeroReward.isNewHero = true;
                    char_Controller.CheckForNewHeroes();
                    displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].HeroReward);
                    break;
                case Quest.RewardType.Gold:
                    Gold.AddGold(first_Line_quest[m_currentFirstLineQuestindex].GoldReward);
                    break;
                case Quest.RewardType.Boost:
                    boost_Controll.OpenCard(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                    displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].BoostCard);
                    break;
                case Quest.RewardType.Location:
                    first_Line_quest[m_currentFirstLineQuestindex].Location.isOpened = true;
                    first_Line_quest[m_currentFirstLineQuestindex].Location.isNewZone = true;
                    checkAttentionIcon.CheckAttention();
                    displayReward.Initialise(first_Line_quest[m_currentFirstLineQuestindex].Location);
                    break;
                case Quest.RewardType.Slot:
                    displayReward.Initialise();
                    break;
            }
     
           m_currentFirstLineQuestindex++;
            First_Line_Quest_Initialise();
        }
    //    GlovalEventSystem.TutorialSteps(3);

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
        AttentionIcon();
    }
    public void Second_Line_Quest_finish()  // �������� �������� �������� ������� �������� �����
    {
    //    if (Tutorial.CheckTutorStep() >= 3)
    //    {
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
                                    second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isNewHero = true;
                                    char_Controller.CheckForNewHeroes();
                                    displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].HeroReward);
                                    break;
                                case Quest.RewardType.Gold:
                                    Gold.AddGold(second_Line_quest[m_currentSecondLineQuestindex].GoldReward);
                                    break;
                                case Quest.RewardType.Boost:
                                    boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                                    displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                                    break;
                                case Quest.RewardType.Location:
                                    second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                                    second_Line_quest[m_currentSecondLineQuestindex].Location.isNewZone = true;
                                    checkAttentionIcon.CheckAttention();
                                    displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].Location);
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
                        if (second_Line_quest[m_currentSecondLineQuestindex].goal.thirdItem != null)
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
                                second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isNewHero = true;
                                char_Controller.CheckForNewHeroes();
                                displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].HeroReward);
                                break;
                            case Quest.RewardType.Gold:
                                Gold.AddGold(second_Line_quest[m_currentSecondLineQuestindex].GoldReward);
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                                displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                                second_Line_quest[m_currentSecondLineQuestindex].Location.isNewZone = true;
                                checkAttentionIcon.CheckAttention();
                                displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].Location);
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
                        second_Line_quest[m_currentSecondLineQuestindex].HeroReward.isNewHero = true;
                        char_Controller.CheckForNewHeroes();
                        displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].HeroReward);
                        break;
                    case Quest.RewardType.Boost:
                        boost_Controll.OpenCard(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                        displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].BoostCard);
                        break;
                    case Quest.RewardType.Location:
                        second_Line_quest[m_currentSecondLineQuestindex].Location.isOpened = true;
                        second_Line_quest[m_currentSecondLineQuestindex].Location.isNewZone = true;
                        checkAttentionIcon.CheckAttention();
                        displayReward.Initialise(second_Line_quest[m_currentSecondLineQuestindex].Location);
                        break;
                }
                m_currentSecondLineQuestindex++;
                Second_Line_Quest_Initialise();
            }
      //      GlovalEventSystem.TutorialSteps(4);
      //  }
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
        AttentionIcon();
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
                                    third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isNewHero = true;
                                    char_Controller.CheckForNewHeroes();
                                    displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].HeroReward);
                                    break;
                                case Quest.RewardType.Boost:
                                    boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                    displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                    break;
                                case Quest.RewardType.Location:
                                    third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                                    third_Line_quest[m_currentThitrdLineQuestindex].Location.isNewZone = true;
                                    checkAttentionIcon.CheckAttention();
                                    displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].Location);
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
                                third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isNewHero = true;
                                char_Controller.CheckForNewHeroes();
                                displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].HeroReward);
                                break;
                            case Quest.RewardType.Boost:
                                boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                                break;
                            case Quest.RewardType.Location:
                                third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                                third_Line_quest[m_currentThitrdLineQuestindex].Location.isNewZone = true;
                                checkAttentionIcon.CheckAttention();
                                displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].Location);
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
                        third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isNewHero = true;
                        char_Controller.CheckForNewHeroes();
                        displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].HeroReward);
                        break;
                    case Quest.RewardType.Boost:
                        boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                        displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
                        break;
                    case Quest.RewardType.Location:
                        third_Line_quest[m_currentThitrdLineQuestindex].Location.isOpened = true;
                        third_Line_quest[m_currentThitrdLineQuestindex].Location.isNewZone = true;
                        checkAttentionIcon.CheckAttention();
                        displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].Location);
                        break;
                }
                m_currentThitrdLineQuestindex++;
                Third_Line_Quest_Initialise();
            }
        }
        else if(m_currentThitrdLineQuestindex == 0)
        {
            Debug.Log("Boost activate");
            Boost.SetActive(true);
            Boostimg.SetActive(true);
            boost_Controll.OpenCard(third_Line_quest[m_currentThitrdLineQuestindex].BoostCard);
            switch (third_Line_quest[m_currentThitrdLineQuestindex].rewardType)
            {
                case Quest.RewardType.Hero:
                    third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isOpened = true;
                    third_Line_quest[m_currentThitrdLineQuestindex].HeroReward.isNewHero = true;
                    char_Controller.CheckForNewHeroes();
                    displayReward.Initialise(third_Line_quest[m_currentThitrdLineQuestindex].HeroReward);
                    break;
            }

            m_currentThitrdLineQuestindex++;
            Third_Line_Quest_Initialise();
          
         //   GlovalEventSystem.TutorialStepsThirdPart(17);
        }
    }
}