using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int ID;
    public string Name;
    public Sprite imageRank_1;
    public Sprite imageRank_2;
    public Sprite imageRank_3;
    public enum Rare
    {
        Common,
        Unusual,
        Rare,
        Epic,
        Legendary
    }
    public Rare rare;
    public enum ElementType
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public ElementType elementType;


    public int Level;

    public float goldToGrade;

    public int ProfitPercent;
    public int LuckPercent;
    public int ProtectPercent;
    public int ComboPercent;
    
    public int ItemProfit;
    public int ItemProtect;
    public int iemLuck;



    public Hero(int id, int profit, int luck, int protect, int combo)
    {
        ID = id;
        Level = 1;
        ProfitPercent = profit;
        LuckPercent = luck;
        ProtectPercent = protect;
        ComboPercent = combo;
    }
}
