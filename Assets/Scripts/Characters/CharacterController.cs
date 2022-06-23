using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    const string SaveFilename = "Heroes";

    [SerializeField] private List<Hero> neutralHeros;
    [SerializeField] private List<Hero> undeadHeros;
    [SerializeField] private List<Hero> orderHeros;
    [SerializeField] private List<Hero> demonHeros;
    private List<SavedHero> SavedHeroes = new List<SavedHero>();
    void Awake()
    {
        if(PlayerPrefs.HasKey("firstTime"))
        {
            LoadInventory();
            InitialiseHeroes();
        }
    }
    public Hero FindHero(SaveActiveHero saveActiveHero)
    {
        foreach (var item in neutralHeros)
        {
            if(item.Name == saveActiveHero.Name && item.ID == saveActiveHero.ID)
            {
                return item;
            }
        }
        foreach (var item in undeadHeros)
        {
            if (item.Name == saveActiveHero.Name && item.ID == saveActiveHero.ID)
            {
                return item;
            }
        }
        foreach (var item in orderHeros)
        {
            if (item.Name == saveActiveHero.Name && item.ID == saveActiveHero.ID)
            {
                return item;
            }
        }
        foreach (var item in demonHeros)
        {
            if (item.Name == saveActiveHero.Name && item.ID == saveActiveHero.ID)
            {
                return item;
            }
        }
        return null;
    }
    private void InitialiseHeroes()
    {
        for (int i = 0; i < neutralHeros.Count; i++)
        {
            neutralHeros[i].SetInfo(SavedHeroes[i]);
        }
        for (int i = neutralHeros.Count; i < undeadHeros.Count + neutralHeros.Count; i++)
        {
            undeadHeros[i].SetInfo(SavedHeroes[i]);
        }
        for (int i = orderHeros.Count; i < orderHeros.Count + undeadHeros.Count + neutralHeros.Count; i++)
        {
            orderHeros[i].SetInfo(SavedHeroes[i]);
        }
        for (int i = demonHeros.Count; i < demonHeros.Count + orderHeros.Count + undeadHeros.Count + neutralHeros.Count; i++)
        {
            demonHeros[i].SetInfo(SavedHeroes[i]);
        }
    }

    #region Save / Load
    public void SaveInventory()
    {
        SavedHeroes.Clear();

        for (int i = 0; i < neutralHeros.Count; i++)
        {
            SavedHeroes.Add(new SavedHero(neutralHeros[i]));
        }
        for (int i = 0; i < undeadHeros.Count; i++)
        {
            SavedHeroes.Add(new SavedHero(undeadHeros[i]));
        }
        for (int i = 0; i < orderHeros.Count; i++)
        {
            SavedHeroes.Add(new SavedHero(orderHeros[i]));
        }
        for (int i = 0; i < demonHeros.Count; i++)
        {
            SavedHeroes.Add(new SavedHero(demonHeros[i]));
        }

        FileHandler.SaveToJSON<SavedHero>(SavedHeroes, SaveFilename);
    }
    private void LoadInventory()
    {
        SavedHeroes = FileHandler.ReadListFromJSON<SavedHero>(SaveFilename);
    }
    
    #endregion
}
[Serializable]
public class SavedHero
{
    public int ID;
    public string Name;

    public Sprite heroIcon;
    public Sprite imageRank_1;
    public Sprite imageRank_2;
    public Sprite imageRank_3;
    public enum ElementType
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public ElementType elementType;


    public int Level;
    public int rank;

    public float goldToGrade;

    public int ProfitPercent;
    public int LuckPercent;
    public int ProtectPercent;
    public int ComboPercent;

    public int ItemProfit;
    public int ItemProtect;
    public int iemLuck;

    public Prize Sword;
    public Prize Shield;
    public Prize Amulet;

    public SavedHero(Hero hero)
    {
        hero.GetInfo(out ID, out Name, out heroIcon, out imageRank_1, out imageRank_2, out imageRank_3, out Level,
            out rank, out goldToGrade, out ProfitPercent, out LuckPercent, out ProtectPercent, out ComboPercent, out Sword, out Shield, out Amulet);
    }
}
