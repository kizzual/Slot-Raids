using System;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    ///////////////////////////// PATH ////////////////////////////////
    private const string heroSaverPath = "HeroSave";                ///
    private const string inventorySaverPath = "InventorySave";      ///
    private const string zoneSaverPath = "ZoneSave";                ///
    /// ///////////////////////////////////////////////////////////////
    [SerializeField] private List<Hero> heroes; 
    [SerializeField] private Inventory_controll inventory_Controll;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private SwitchLocation switchLocation;


    
    private List<HeroSaver> m_heroSaver = new List<HeroSaver>();
    private InventorySaver m_inventorySavers;
    private ZoneSaver m_zoneSaver;

    private void Awake()
    {
        FullLoad();
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
        m_zoneSaver = null;
        m_zoneSaver = new ZoneSaver(CurrentZone.Current_Zone);
        FileHandler.SaveToJSON<ZoneSaver>(m_zoneSaver, zoneSaverPath);
    }
    public void FullLoad()
    {
        m_heroSaver = FileHandler.ReadListFromJSON<HeroSaver>(heroSaverPath);
        m_inventorySavers = FileHandler.ReadFromJSON<InventorySaver>(inventorySaverPath);
        m_zoneSaver = FileHandler.ReadFromJSON<ZoneSaver>(zoneSaverPath);

        //////////// загрузка героев ///////////////
        //  если герои будут открываться по очереди этот цикл
        if (m_heroSaver != null)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].LoadHero(m_heroSaver[i]);

                if (heroes[i].currentRaidSlot != 0)
                {
                    for (int j = 0; j < raid_control.CheckWinPrize().Count; j++)
                    {
                        if(heroes[i].currentRaidSlot - 1 == j)
                        {
                            raid_control.CheckWinPrize()[j].Initialise(heroes[i]);
                            break;
                        }
                    }
                }
            }
        }

        //      если герои будут открываться в разнобой то этот цикл
     /*   if (m_heroSaver != null)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                for (int j = 0; j < m_heroSaver.Count; j++)
                {
                    if(heroes[i].Id == m_heroSaver[j].Id)
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
        }*/
     //////////// загрузка инвентаря ///////////////
        inventory_Controll.LoadInventory(m_inventorySavers);

     //////////// загрузка текущей карты ///////////
        CurrentZone.SetZone(m_zoneSaver.zone);
        raid_control.Switchlocation(m_zoneSaver.zone);
        switch (m_zoneSaver.zone.typeElement)
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
    }
}
[Serializable]
public class HeroSaver
{
    public int Level;
    public int CurrentSlot;
    public int Id;
    public bool IsOpened;
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
    public Zone zone;
    public ZoneSaver (Zone zone)
    {
        this.zone = zone;
    }
}
