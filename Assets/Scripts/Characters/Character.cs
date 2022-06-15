using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<Hero> heroes;




    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddHero()
    {
        var hero = new Hero(1, 10, 12, 6, 1);
        heroes.Add(hero);
    }


}
[Serializable]
public class Hero
{
    public int ID;
    public int Level;
    public int ProfitPercent;
    public int LuckPercent;
    public int ProtectPercent;
    public int ComboPercent;

    public int ItemProfit;
    public int ItemProtect;
    public int iemLuck;
    
    public Hero (int id, int profit, int luck, int protect, int combo)
    {
        ID = id;
        Level = 1;
        ProfitPercent = profit ;
        LuckPercent = luck;
        ProtectPercent = protect;
        ComboPercent = combo;
    }
    
    
}
