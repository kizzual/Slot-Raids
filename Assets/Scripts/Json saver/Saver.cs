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
    [SerializeField] private List<Tower_quest> quests;
    [SerializeField] private List<Zone> zones;
    [SerializeField] private Inventory_controll inventory_Controll;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private SwitchLocation switchLocation;
    [SerializeField] private Boost_Controll boost_Controll;



    
    private List<HeroSaver> m_heroSaver = new List<HeroSaver>();
    private List<QuestSaver> m_questSaver = new List<QuestSaver>();
    private List<AllZonesSaver> allZonesSaver;
    private InventorySaver m_inventorySavers;
    public List<ZoneSaver> m_zoneSaver;
    private BoostSaver m_boostSaver;
    private bool m_FastQuit = false;
    private void Awake()
    {
    //    StartCoroutine(LoadAll());
        FullLoad();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause && !m_FastQuit)
            FullSave();
    }
/*    private void OnApplicationQuit()
    {
        if(!m_FastQuit)
            FullSave();
    }*/
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
        for (int i = 0; i < quests.Count; i++)
        {
            m_questSaver.Add(new QuestSaver(quests[i]));
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

        /////////////// загрузка квестов //////////////
        if (m_questSaver.Count > 0 )
        {
            for (int i = 0; i < m_questSaver.Count; i++)
            {
                quests[i].m_currentFirstLineQuestindex = m_questSaver[i].firstIndex;
                quests[i].m_currentSecondLineQuestindex = m_questSaver[i].secondIndex;
                quests[i].m_currentThitrdLineQuestindex = m_questSaver[i].thirdIndex;
                quests[i].first_Line_quest[quests[i].m_currentFirstLineQuestindex].goal = m_questSaver[i].first_Line;
                quests[i].second_Line_quest[quests[i].m_currentSecondLineQuestindex].goal = m_questSaver[i].second_Line;
                quests[i].third_Line_quest[quests[i].m_currentThitrdLineQuestindex].goal = m_questSaver[i].third_Line;
                quests[i].m_currentRaid = m_questSaver[i].currentRaid;
                quests[i].m_currentGold = m_questSaver[i].currentGold;

            }
        }

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
            switch (CurrentZone.Current_Zone.typeElement)
            {
                case Type__Element.Neutral:
                    switchLocation.SwitchRaidLocation(0);
                    break;
                case Type__Element.Undead:
                    switchLocation.SwitchRaidLocation(1);
                    break;
                case Type__Element.Order:
                    switchLocation.SwitchRaidLocation(2);
                    break;
                case Type__Element.Demon:
                    switchLocation.SwitchRaidLocation(3);
                    break;
            }
            raid_control.Switchlocation(CurrentZone.Current_Zone);
        }
        else if(!PlayerPrefs.HasKey("CurrentZone"))
        {
            CurrentZone.SetZone(zones[0]);
            switch (CurrentZone.Current_Zone.typeElement)
            {
                case Type__Element.Neutral:
                    switchLocation.SwitchRaidLocation(0);
                    break;
                case Type__Element.Undead:
                    switchLocation.SwitchRaidLocation(1);
                    break;
                case Type__Element.Order:
                    switchLocation.SwitchRaidLocation(2);
                    break;
                case Type__Element.Demon:
                    switchLocation.SwitchRaidLocation(3);
                    break;
            }
            raid_control.Switchlocation(CurrentZone.Current_Zone);
        }

        /*  if (m_zoneSaver.Count > 0)
          {
              CurrentZone.SetZone(m_zoneSaver[m_zoneSaver.Count - 1].currentZone);
              *//* for (int i = 0; i < zones.Count; i++)
               {
                   if(m_zoneSaver.zoneIndex == zones[i].ID)
                   {
                       CurrentZone.SetZone(zones[i]);
                       break;
                   }
               }*//*
              switch (CurrentZone.Current_Zone.typeElement)
              {
                  case Type__Element.Neutral:
                      switchLocation.SwitchRaidLocation(0);
                      break;
                  case Type__Element.Undead:
                      switchLocation.SwitchRaidLocation(1);
                      break;
                  case Type__Element.Order:
                      switchLocation.SwitchRaidLocation(2);
                      break;
                  case Type__Element.Demon:
                      switchLocation.SwitchRaidLocation(3);
                      break;
              }
              raid_control.Switchlocation(CurrentZone.Current_Zone);
          }*/

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


        /////////////// загрузка бустов ////////////////
        if (m_boostSaver != null)
        {
            boost_Controll.FullCardList = m_boostSaver.FullCardList;
            boost_Controll.activeCard = m_boostSaver.activeCard;
        }


    }
    public void DeleteAllSaves()
    {
        m_heroSaver = FileHandler.ReadListFromJSON<HeroSaver>(heroSaverPath);
        m_inventorySavers = FileHandler.ReadFromJSON<InventorySaver>(inventorySaverPath);
        m_zoneSaver = FileHandler.ReadListFromJSON<ZoneSaver>(zoneSaverPath);
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
        FileHandler.SaveToJSON<ZoneSaver>(m_zoneSaver, zoneSaverPath);
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
    public QuestGoal first_Line;
    public QuestGoal second_Line;
    public QuestGoal third_Line;
    public int currentRaid;
    public long currentGold;

    public QuestSaver(Tower_quest quesLine)
    {
        firstIndex = quesLine.m_currentFirstLineQuestindex;
        secondIndex = quesLine.m_currentSecondLineQuestindex;
        thirdIndex = quesLine.m_currentThitrdLineQuestindex;
        first_Line = quesLine.first_Line_quest[quesLine.m_currentFirstLineQuestindex].goal;
        second_Line = quesLine.second_Line_quest[quesLine.m_currentSecondLineQuestindex].goal;
        third_Line = quesLine.third_Line_quest[quesLine.m_currentThitrdLineQuestindex].goal;
        currentRaid = quesLine.m_currentRaid;
        currentGold = quesLine.m_currentGold;
    }
}
[Serializable]
public class BoostSaver
{
    public List<BoostCard> FullCardList;
    public List<BoostCard> activeCard;

    public BoostSaver(Boost_Controll boost_Controll)
    {
        FullCardList = boost_Controll.FullCardList;
        activeCard = boost_Controll.activeCard;
    }
}
