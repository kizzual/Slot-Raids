using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
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



    public void Initialise(Hero heroSo)
    {
        ID = heroSo.ID;
        Name = heroSo.Name;
        heroIcon = heroSo.heroIcon;
        imageRank_1 = heroSo.imageRank_1;
        imageRank_2 = heroSo.imageRank_2;
        imageRank_3 = heroSo.imageRank_3;
        elementType = heroSo.elementType;
        Level = heroSo.Level;
        ProfitPercent = heroSo.ProfitPercent;
        LuckPercent = heroSo.LuckPercent;
        ProtectPercent = heroSo.ProtectPercent;
        ComboPercent = heroSo.ComboPercent;
    }

    public void GetInfo(out int _ID, out string _name, out Sprite _heroIcon, out Sprite rank_1, out Sprite rank_2, out Sprite rank_3,
        out int _Level, out int _rank, out float _goldToGrade, out int _ProfitPercent, out int _LuckPercent, out int _ProtectPercent, out int _ComboPercent,
        out Prize _Sword, out Prize _Shield, out Prize _Amulet)
    {
        _ID = ID;
        _name = Name;
        _heroIcon = heroIcon;
        rank_1 = imageRank_1;
        rank_2 = imageRank_2;
        rank_3 = imageRank_3;
        _Level = Level;
        _rank = rank;
        _goldToGrade = goldToGrade;
        _ProfitPercent = ProfitPercent;
        _LuckPercent = LuckPercent;
        _ProtectPercent = ProtectPercent;
        _ComboPercent = ComboPercent;
        _Sword = Sword;
        _Shield = Shield;
        _Amulet = Amulet;
    }

    public void SetInfo(SavedHero savedHero)
    {
        ID = savedHero.ID;
        Name = savedHero.Name;
        heroIcon = savedHero.heroIcon;
        imageRank_1 = savedHero.imageRank_1;
        imageRank_2 = savedHero.imageRank_2;
        imageRank_3 = savedHero.imageRank_3;
        Level = savedHero.Level;
        rank = savedHero.rank;
        goldToGrade = savedHero.goldToGrade;
        ProfitPercent = savedHero.ProfitPercent;
        LuckPercent = savedHero.LuckPercent;
        ProtectPercent = savedHero.ProtectPercent;
        ComboPercent = savedHero.ComboPercent;
        if(savedHero.Sword != null)
        {
            ItemProfit += savedHero.Sword.profitPercent;
            Sword = savedHero.Sword;
        }
        if(savedHero.Sword != null)
        {
            ItemProtect += savedHero.Shield.defencePercent;
            Shield = savedHero.Shield;
        }
        if(savedHero.Amulet != null)
        {
            iemLuck += savedHero.Amulet.luckPercent;
            Amulet = savedHero.Amulet;
        }
    }
    public void SetInfo(Hero savedHero)
    {
        ID = savedHero.ID;
        Name = savedHero.Name;
        heroIcon = savedHero.heroIcon;
        imageRank_1 = savedHero.imageRank_1;
        imageRank_2 = savedHero.imageRank_2;
        imageRank_3 = savedHero.imageRank_3;
        Level = savedHero.Level;
        rank = savedHero.rank;
        goldToGrade = savedHero.goldToGrade;
        ProfitPercent = savedHero.ProfitPercent;
        LuckPercent = savedHero.LuckPercent;
        ProtectPercent = savedHero.ProtectPercent;
        ComboPercent = savedHero.ComboPercent;
        if (savedHero.Sword != null)
        {
            ItemProfit += savedHero.Sword.profitPercent;
            Sword = savedHero.Sword;
        }
        if (savedHero.Sword != null)
        {
            ItemProtect += savedHero.Shield.defencePercent;
            Shield = savedHero.Shield;
        }
        if (savedHero.Amulet != null)
        {
            iemLuck += savedHero.Amulet.luckPercent;
            Amulet = savedHero.Amulet;
        }
    }
}
