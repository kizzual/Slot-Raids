using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    ///////////////////////////// PATH ////////////////////////////////
    private const string heroSaverPath = "HeroSave9";                ///
    private const string inventorySaverPath = "InventorySave9";      ///
    private const string zoneSaverPath = "ZoneSave9";                ///
    private const string allZoneSaverPath = "AllZoneSave9";          ///
    private const string QuestSaverPath = "QuestSave9";              ///
    private const string BoostSaverPath = "BoostSave9";              ///
    ///////////////////////////////////////////////////////////////////
   
    [SerializeField] private List<Hero> heroes; 
    [SerializeField] private QuestControll quests;
    [SerializeField] private List<Zone> zones;
    [SerializeField] private Inventory_controll inventory_Controll;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private SwitchLocation switchLocation;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private TowerUpgrade upgradeTower;
    [SerializeField] private CheckCombo checkCombo;
    [SerializeField] private GameController EventController;



    
    private List<HeroSaver> m_heroSaver = new List<HeroSaver>();
    private List<QuestSaver> m_questSaver = new List<QuestSaver>();
    private List<AllZonesSaver> allZonesSaver;
    private InventorySaver m_inventorySavers;
    public List<ZoneSaver> m_zoneSaver;
    private BoostSaver m_boostSaver;
    private bool m_FastQuit = false;
    private void Awake()
    {
        EventController.ActivateEvents();

    }
    private void Start()
    {
      
        FullLoad();
        checkCombo.CheckOfflinePrize();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Utils.SetLastTime("LastSession");
            raid_control.StopRaid();
            EventController.DeactivateEvents();
            FullSave();
        }
        else
        {
            EventController.ActivateEvents();
            checkCombo.CheckOfflinePrize();
        }
    }

    public void FullSave()
    {

        //  сохранения героев
        m_heroSaver.Clear();
        for (int i = 0; i < heroes.Count; i++)
        {
            m_heroSaver.Add(new HeroSaver(heroes[i]));
        }
        FileHandler.SaveToJSON<HeroSaver>(m_heroSaver, heroSaverPath);

        //   сохранения инвенторя
        m_inventorySavers = null;
        m_inventorySavers = new InventorySaver(inventory_Controll);
        FileHandler.SaveToJSON<InventorySaver>(m_inventorySavers, inventorySaverPath);

        //  сохранения текущей карты
        //   m_zoneSaver.Add( new ZoneSaver(CurrentZone.Current_Zone));
        //   FileHandler.SaveToJSON<ZoneSaver>(m_zoneSaver, zoneSaverPath);

        //  сохранения всех карт 
        allZonesSaver.Clear();
        for (int i = 0; i < zones.Count; i++)
        {
            allZonesSaver.Add(new AllZonesSaver(zones[i]));
        }
        FileHandler.SaveToJSON<AllZonesSaver>(allZonesSaver, allZoneSaverPath);

        //  сохранения квестов
        m_questSaver.Clear();
        List<QuestPanel> panels = new List<QuestPanel>();
        panels = quests.GetQuestPanels();
        for (int i = 0; i < panels.Count; i++)
        {
            m_questSaver.Add(new QuestSaver(panels[i]));
        }
        FileHandler.SaveToJSON<QuestSaver>(m_questSaver, QuestSaverPath);

        //  сохранения бустов
        m_boostSaver = null;
        m_boostSaver = new BoostSaver(boost_Controll);
        FileHandler.SaveToJSON<BoostSaver>(m_boostSaver, BoostSaverPath);

    }
    public void FullLoad()
    { 
     //   m_zoneSaver = FileHandler.ReadListFromJSON<ZoneSaver>(zoneSaverPath);
        m_heroSaver = FileHandler.ReadListFromJSON<HeroSaver>(heroSaverPath); 
        m_inventorySavers = FileHandler.ReadFromJSON<InventorySaver>(inventorySaverPath);
        m_questSaver = FileHandler.ReadListFromJSON<QuestSaver>(QuestSaverPath);
        allZonesSaver = FileHandler.ReadListFromJSON<AllZonesSaver>(allZoneSaverPath);
        m_boostSaver = FileHandler.ReadFromJSON<BoostSaver>(BoostSaverPath);

        //////////  загрузка башни    ////////
        upgradeTower.Initialise();
        ////////// загрузка характеристик карт ////////
        if (allZonesSaver != null)
        {
            for (int i = 0; i < allZonesSaver.Count; i++)
            {
                zones[i].RaidsCount = allZonesSaver[i].raidCount;
                zones[i].isOpened = allZonesSaver[i].isOpened;
            }
        }

        //////////// загрузка инвентаря ///////////////
        if (m_inventorySavers != null)
            inventory_Controll.LoadInventory(m_inventorySavers);

        //////////// загрузка текущей карты ///////////

        if (PlayerPrefs.HasKey("CurrentZone"))
        {
            Debug.Log("Current zone ID =  " + PlayerPrefs.HasKey("CurrentZone"));
            foreach (var item in zones)
            {
                if (item.ID == PlayerPrefs.GetInt("CurrentZone"))
                {
                    CurrentZone.SetZone(item);
                    Debug.Log("Current zone name  =  " + item.nameLocation);
                    break;
                }
            }
            switchLocation.SwitchRaidLocation(CurrentZone.Current_Zone);

        }
        else if (!PlayerPrefs.HasKey("CurrentZone"))
        {
            CurrentZone.SetZone(zones[0]);
            switchLocation.SwitchRaidLocation(CurrentZone.Current_Zone);
        }



        //////////// загрузка героев ///////////////
        if (m_heroSaver.Count > 0)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                for (int j = 0; j < m_heroSaver.Count; j++)
                {
                    if (heroes[i].Id == m_heroSaver[j].Id)
                    {
                        heroes[i].LoadHero(m_heroSaver[j]);

                        if (heroes[i].currentRaidSlot != 0)
                        {
                            for (int k = 0; k < raid_control.CheckWinPrize().Count; k++)
                            {
                                if (heroes[i].currentRaidSlot - 1 == k)
                                {
                                    raid_control.CheckWinPrize()[k].Initialise(heroes[i]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Debug.Log("Heroes loaded");
        }

        /////////////// загрузка квестов ////////////// *******
        List<QuestPanel> panels = new List<QuestPanel>();
        panels = quests.GetQuestPanels();
        if (m_questSaver.Count > 0 )
        {
            for (int i = 0; i < m_questSaver.Count; i++)
            {
                panels[i].m_currentFirstLineQuestindex = m_questSaver[i].firstIndex;
                panels[i].m_currentSecondLineQuestindex = m_questSaver[i].secondIndex;
                panels[i].m_currentThitrdLineQuestindex = m_questSaver[i].thirdIndex;
                panels[i].GetFirstLineQuest()[panels[i].m_currentFirstLineQuestindex].goal = m_questSaver[i].first_Line;
                panels[i].GetSecondLineQuest()[panels[i].m_currentSecondLineQuestindex].goal = m_questSaver[i].second_Line;
                panels[i].GetThirdLineQuest()[panels[i].m_currentThitrdLineQuestindex].goal = m_questSaver[i].third_Line;

            }
            quests.m_currentRaid = m_questSaver[0].currentRaid;
            quests.m_currentGold = m_questSaver[0].currentGold;
        }

        /////////////// загрузка бустов ////////////////
        if (m_boostSaver != null)
        {
            boost_Controll.LoadBoost(m_boostSaver);
        }

        /////////////// загрузка призов ////////////////

        Debug.Log("Rewards coplete");

    }
    public void ActivateAllEvents()
    {

    }
    public void DeleteAllSaves()
    {
        m_heroSaver = FileHandler.ReadListFromJSON<HeroSaver>(heroSaverPath);
        m_inventorySavers = FileHandler.ReadFromJSON<InventorySaver>(inventorySaverPath);
        m_questSaver = FileHandler.ReadListFromJSON<QuestSaver>(QuestSaverPath);
        allZonesSaver = FileHandler.ReadListFromJSON<AllZonesSaver>(allZoneSaverPath);
        m_boostSaver = FileHandler.ReadFromJSON<BoostSaver>(BoostSaverPath);
        m_heroSaver.Clear();
        m_inventorySavers = null;
        m_zoneSaver = null;
        m_questSaver.Clear();
        allZonesSaver.Clear();
        m_boostSaver = null;
        FileHandler.SaveToJSON<HeroSaver>(m_heroSaver, heroSaverPath);
        FileHandler.SaveToJSON<InventorySaver>(m_inventorySavers, inventorySaverPath);
        FileHandler.SaveToJSON<AllZonesSaver>(allZonesSaver, allZoneSaverPath);
        FileHandler.SaveToJSON<QuestSaver>(m_questSaver, QuestSaverPath);
        FileHandler.SaveToJSON<BoostSaver>(m_boostSaver, BoostSaverPath);

        /*        foreach (var item in heroes)
                {
                    item.isOpened = false;
                }
                inventory_Controll.m_Sword_1.Clear();
                inventory_Controll.m_Sword_2.Clear();
                inventory_Controll.m_Sword_3.Clear();
                inventory_Controll.m_Shield_1.Clear();
                inventory_Controll.m_Shield_2.Clear();
                inventory_Controll.m_Shield_3.Clear();
                inventory_Controll.m_Amuulet_1.Clear();
                inventory_Controll.m_Amuulet_2.Clear();
                inventory_Controll.m_Amuulet_3.Clear();
                foreach (var item in zones)
                {
                    item.isOpened = false;
                }
                zones[0].isOpened = true;
        */
        Debug.Log("QUIT");
        m_FastQuit = true;
        Application.Quit();
    }
 
}
[Serializable]
public class HeroSaver
{
    public int Level;
    public int CurrentSlot;
    public int Id;
    public bool IsOpened;
    public int raidsCount;
    public long goldToGrade;
    public Item Sword;
    public Item Shield;
    public Item Amulet;
    public HeroSaver (Hero hero)
    {
        this.Level = hero.Level;
        this.CurrentSlot = hero.currentRaidSlot;
        this.IsOpened = hero.isOpened;
        this.Sword = hero.GetItem_Sword();
        this.Shield = hero.GetItem_Shield();
        this.Amulet = hero.GetItem_Amulet();
        this.Id = hero.Id;
        this.raidsCount = hero.raidsCount;
        this.goldToGrade = hero.GoldToGrade;
    }
}
[Serializable]
public class InventorySaver
{
    public List<Item> m_Sword_1 = new List<Item>();
    public List<Item> m_Sword_2 = new List<Item>();
    public List<Item> m_Sword_3 = new List<Item>();
    public List<Item> m_Shield_1 = new List<Item>();
    public List<Item> m_Shield_2 = new List<Item>();
    public List<Item> m_Shield_3 = new List<Item>();
    public List<Item> m_Amuulet_1 = new List<Item>();
    public List<Item> m_Amuulet_2 = new List<Item>();
    public List<Item> m_Amuulet_3 = new List<Item>();

    public InventorySaver(Inventory_controll inventory)
    {
        this.m_Sword_1 = inventory.m_Sword_1;
        this.m_Sword_2 = inventory.m_Sword_2;
        this.m_Sword_3 = inventory.m_Sword_3;
        this.m_Shield_1 = inventory.m_Shield_1;
        this.m_Shield_2 = inventory.m_Shield_2;
        this.m_Shield_3 = inventory.m_Shield_3;
        this.m_Amuulet_1 = inventory.m_Amuulet_1;
        this.m_Amuulet_2 = inventory.m_Amuulet_2;
        this.m_Amuulet_3 = inventory.m_Amuulet_3;
    }
}
[Serializable]
public class ZoneSaver
{
    public int zoneIndex;
    public Zone currentZone;
    public ZoneSaver (Zone zone)
    {
        this.zoneIndex = zone.ID;
        this.currentZone = zone;
    }
}
[Serializable]
public class AllZonesSaver
{
    public int raidCount;
    public bool isOpened;
    
    public AllZonesSaver(Zone zone)
    {
        this.raidCount = zone.RaidsCount;
        this.isOpened = zone.isOpened;
    }
}
[Serializable]
public class QuestSaver
{
    public int firstIndex;
    public int secondIndex;
    public int thirdIndex;
    public Goal first_Line;
    public Goal second_Line;
    public Goal third_Line;
    public int currentRaid;
    public long currentGold;

    public QuestSaver(QuestPanel quesLine)
    {
        firstIndex = quesLine.m_currentFirstLineQuestindex;
        secondIndex = quesLine.m_currentSecondLineQuestindex;
        thirdIndex = quesLine.m_currentThitrdLineQuestindex;
        first_Line = quesLine.GetFirstLineQuest()[quesLine.m_currentFirstLineQuestindex].goal;
        second_Line = quesLine.GetSecondLineQuest()[quesLine.m_currentSecondLineQuestindex].goal;
        third_Line = quesLine.GetThirdLineQuest()[quesLine.m_currentThitrdLineQuestindex].goal;
        currentRaid = quesLine.raidsCount;
        currentGold = quesLine.goldsCount;
    }
}
[Serializable]
public class BoostSaver
{
    public List<BoostCard> FullCardList;
    public List<BoostCard> activeCard;
    public bool isActive;
    public int CurrentRaids;
    public BoostCard currentCard;
    public float timer;
    public BoostSaver(Boost_Controll boost_Controll)
    {
        FullCardList = boost_Controll.FullCardList;
        activeCard = boost_Controll.activeCard;
        if(boost_Controll.CurrentBoost != null)
        {
            currentCard = boost_Controll.CurrentBoost;
            if (boost_Controll.CurrentBoost.isActive)
                this.isActive = true;
            else
                this.isActive = false;
        }
        this.CurrentRaids = boost_Controll.m_currentRaid;
        this.timer = boost_Controll.m_timer;
    }
}
