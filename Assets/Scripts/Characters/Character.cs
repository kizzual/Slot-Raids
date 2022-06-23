using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const string SaveFilename = "activeHeroes";


    [SerializeField] private List<Hero> neutralHeroes;
    [SerializeField] private List<Hero> undeadHeroes;
    [SerializeField] private List<Hero> orderHeroes;
    [SerializeField] private List<Hero> demonHeroes;

    [SerializeField] private List<HeroPanel> HeroPanels;
    [SerializeField] private CharacterController characterController;
    private List<SaveActiveHero> saveActiveHero = new List<SaveActiveHero>();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("firstTime"))
        {
            LoadInventory();
            InitialiseActiveHero();
        }
    }

    private void OnEnable()
    {
        SwitchPanels(0);
    }
    public void Add_NeutralHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, neutralHeroes.Count);
        HeroPanels[0].AddHero(neutralHeroes[indextHero], index);
        neutralHeroes.RemoveAt(indextHero);
    }
    public void Add_UndeadHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, undeadHeroes.Count);
        HeroPanels[1].AddHero(undeadHeroes[indextHero], index);
        undeadHeroes.RemoveAt(indextHero);
    }
    public void Add_OrderHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, orderHeroes.Count);
        HeroPanels[2].AddHero(orderHeroes[indextHero], index);
        orderHeroes.RemoveAt(indextHero);
    }
    public void Add_DemonHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, demonHeroes.Count);
        HeroPanels[3].AddHero(demonHeroes[indextHero], index);
        demonHeroes.RemoveAt(indextHero);
    }
 
    public void Add_EggNeutral()
    {
        HeroPanels[0].AddEgg();
    }
    public void Add_EggUndead()
    {
        HeroPanels[1].AddEgg();
    }
    public void Add_EggOrder()
    {
        HeroPanels[2].AddEgg();
    }
    public void Add_EggDemon()
    {
        HeroPanels[3].AddEgg();
    }
    public void SwitchPanels(int index)
    {
        foreach (var item in HeroPanels)
        {
            item.gameObject.SetActive(false);
        }
        HeroPanels[index].gameObject.SetActive(true);
    }



    private void InitialiseActiveHero()
    {
        LoadInventory();

        for (int i = 0; i < HeroPanels[0].heroSlots.Count; i++)
        {
            Hero hero = characterController.FindHero(saveActiveHero[i]);
            if(hero != null)
            {
                HeroPanels[0].heroSlots[i].currentHero.SetInfo(hero);
            }
        }
        for (int i = HeroPanels[0].heroSlots.Count; i < HeroPanels[0].heroSlots.Count + HeroPanels[1].heroSlots.Count; i++)
        {
            Hero hero = characterController.FindHero(saveActiveHero[i]);
            if (hero != null)
            {
                HeroPanels[0].heroSlots[i].currentHero.SetInfo(hero);
            }
        }
        for (int i = HeroPanels[0].heroSlots.Count + HeroPanels[1].heroSlots.Count; i < HeroPanels[0].heroSlots.Count + HeroPanels[1].heroSlots.Count + HeroPanels[2].heroSlots.Count; i++)
        {
            Hero hero = characterController.FindHero(saveActiveHero[i]);
            if (hero != null)
            {
                HeroPanels[0].heroSlots[i].currentHero.SetInfo(hero);
            }
        }
        for (int i = HeroPanels[0].heroSlots.Count + HeroPanels[1].heroSlots.Count + HeroPanels[2].heroSlots.Count; i < HeroPanels[0].heroSlots.Count + HeroPanels[2].heroSlots.Count + HeroPanels[3].heroSlots.Count + HeroPanels[3].heroSlots.Count; i++)
        {
            Hero hero = characterController.FindHero(saveActiveHero[i]);
            if (hero != null)
            {
                HeroPanels[0].heroSlots[i].currentHero.SetInfo(hero);
            }
        }
    }
    #region Save / Load
    public void SaveInventory()
    {
        saveActiveHero.Clear();

        for (int i = 0; i < HeroPanels[0].heroSlots.Count; i++)
        {
            saveActiveHero.Add(new SaveActiveHero(HeroPanels[0].heroSlots[i].currentHero));
        }
        for (int i = 0; i < HeroPanels[1].heroSlots.Count; i++)
        {
            saveActiveHero.Add(new SaveActiveHero(HeroPanels[0].heroSlots[i].currentHero));
        }
        for (int i = 0; i < HeroPanels[2].heroSlots.Count; i++)
        {
            saveActiveHero.Add(new SaveActiveHero(HeroPanels[0].heroSlots[i].currentHero));
        }
        for (int i = 0; i < HeroPanels[3].heroSlots.Count; i++)
        {
            saveActiveHero.Add(new SaveActiveHero(HeroPanels[0].heroSlots[i].currentHero));
        }


        FileHandler.SaveToJSON<SaveActiveHero>(saveActiveHero, SaveFilename);
    }
    private void LoadInventory()
    {
        saveActiveHero = FileHandler.ReadListFromJSON<SaveActiveHero>(SaveFilename);
    }

    #endregion
}
[Serializable]
public class SaveActiveHero
{
    public int ID;
    public string Name;
    public SaveActiveHero(Hero hero)
    {
        ID = hero.ID;
        Name = hero.Name;
    }
}

