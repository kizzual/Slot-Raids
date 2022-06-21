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



    public Hero(HeroSO heroSo)
    {
        ID = heroSo.ID;
        Name = heroSo.Name;
        imageRank_1 = heroSo.imageRank_1;
        imageRank_2 = heroSo.imageRank_2;
        imageRank_3 = heroSo.imageRank_3;
        elementType = (ElementType)heroSo.elementType;
        Level = heroSo.Level;
        ProfitPercent = heroSo.ProfitPercent;
        LuckPercent = heroSo.LuckPercent;
        ProtectPercent = heroSo.ProtectPercent;
        ComboPercent = heroSo.ComboPercent;
    }
}
