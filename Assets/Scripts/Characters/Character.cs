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
    private List<Hero> activeHeroes = new List<Hero>();

    public void Loading()
    {
        if (PlayerPrefs.HasKey("firstTime"))
        {
            LoadInventory();
            InitialiseActiveHero();
        }
    }
    public void ChangesCharacteristics()
    {
        characterController.ChangesCharacteristics(activeHeroes);
    }
    private void OnEnable()
    {
        SwitchPanels(0);
    }
    public void Add_NeutralHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, neutralHeroes.Count);
        HeroPanels[0].AddHero(neutralHeroes[indextHero], index);
        activeHeroes.Add(neutralHeroes[indextHero]);
        neutralHeroes.RemoveAt(indextHero);
    }
    public void Add_UndeadHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, undeadHeroes.Count);
        HeroPanels[1].AddHero(undeadHeroes[indextHero], index);
        Debug.Log("NAME =  " + undeadHeroes[indextHero].ID);
        activeHeroes.Add(neutralHeroes[indextHero]);
        undeadHeroes.RemoveAt(indextHero);
    }
    public void Add_OrderHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, orderHeroes.Count);
        HeroPanels[2].AddHero(orderHeroes[indextHero], index);
        activeHeroes.Add(neutralHeroes[indextHero]);
        orderHeroes.RemoveAt(indextHero);
    }
    public void Add_DemonHero(int index)
    {
        int indextHero = UnityEngine.Random.Range(0, demonHeroes.Count);
        HeroPanels[3].AddHero(demonHeroes[indextHero], index);
        activeHeroes.Add(neutralHeroes[indextHero]);
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

        for (int i = 0; i < saveActiveHero.Count; i++)
        {
            for (int j = 0; j < neutralHeroes.Count; j++)
            {
                if(saveActiveHero[i].ID == neutralHeroes[j].ID)
                {
                    HeroPanels[0].AddHero(neutralHeroes[j], HeroPanels[0].CheckFreeSlot());
                    activeHeroes.Add(neutralHeroes[j]);
                    neutralHeroes.Remove(neutralHeroes[j]);
                }
            }
            for (int j = 0; j < undeadHeroes.Count; j++)
            {
                if (saveActiveHero[i].ID == undeadHeroes[j].ID)
                {
                    HeroPanels[1].AddHero(undeadHeroes[j], HeroPanels[0].CheckFreeSlot());
                    activeHeroes.Add(undeadHeroes[j]);
                    undeadHeroes.Remove(undeadHeroes[j]);
                }
            }
            for (int j = 0; j < orderHeroes.Count; j++)
            {
                if (saveActiveHero[i].ID == orderHeroes[j].ID)
                {
                    HeroPanels[2].AddHero(orderHeroes[j], HeroPanels[0].CheckFreeSlot());
                    activeHeroes.Add(orderHeroes[j]);
                    orderHeroes.Remove(orderHeroes[j]);
                }
            }
            for (int j = 0; j < demonHeroes.Count; j++)
            {
                if (saveActiveHero[i].ID == demonHeroes[j].ID)
                {
                    HeroPanels[3].AddHero(demonHeroes[j], HeroPanels[0].CheckFreeSlot());
                    activeHeroes.Add(demonHeroes[j]);
                    demonHeroes.Remove(demonHeroes[j]);
                }
            }
        }
    }
    #region Save / Load
    public void SaveInventory()
    {
        saveActiveHero.Clear();

        for (int i = 0; i < activeHeroes.Count; i++)
        {
            saveActiveHero.Add(new SaveActiveHero(activeHeroes[i]));
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

