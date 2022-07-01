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


    public long goldToGrade;
    public int gradeFactor;

    public int startGold;

    public long ProfitPercent;
    public int LuckPercent;
    public int ProtectPercent;
    public int ComboPercent;

    public int ItemProfit;
    public int ItemProtect;
    public int iemLuck;

    public Prize Sword;
    public Prize Shield;
    public Prize Amulet;

 //   [HideInInspector] public int totalGoldProfit;
    public void TakeItem(Prize prize)
    {
        if (prize._Type == Type.item_sword_1 || prize._Type == Type.item_sword_2 || prize._Type == Type.item_sword_3)
        {
            Sword = prize;
            ItemProfit = Sword.profitPercent;
            ProfitPercent = ProfitPercent + ItemProfit;
        }
        else if(prize._Type == Type.item_shield_1 || prize._Type == Type.item_shield_2 || prize._Type == Type.item_shield_3)
        {
            Shield = prize;
            ItemProtect = Shield.defencePercent;
            ProtectPercent = ProtectPercent +  ItemProtect;
        }
        else if(prize._Type == Type.item_amulet_1 || prize._Type == Type.item_amulet_2 || prize._Type == Type.item_amulet_3)
        {
            Debug.Log("ASD");
            Amulet = prize;
            iemLuck = Amulet.luckPercent;
            LuckPercent = LuckPercent +  iemLuck;
        }
        ProfitPercent = GoldProfit();
        Debug.Log("ƒобавлен айтем типа  =  " + prize._Type);
    }
    public void Initialise(Hero heroSo)
    {
        startGold = heroSo.startGold;
        ID = heroSo.ID;
        Name = heroSo.Name;
        heroIcon = heroSo.heroIcon;
        imageRank_1 = heroSo.imageRank_1;
        imageRank_2 = heroSo.imageRank_2;
        imageRank_3 = heroSo.imageRank_3;
        elementType = heroSo.elementType;
        Level = heroSo.Level;
        rank = heroSo.rank;
        goldToGrade = heroSo.GoldToGrade();
        if (heroSo.Sword != null)
        {
            Sword = heroSo.Sword;
            ItemProfit = heroSo.Sword.profitPercent;

        }
        if(heroSo.Shield != null)
        {
            Shield = heroSo.Shield;
            ItemProtect = heroSo.Sword.defencePercent;
        }
        if (heroSo.Amulet != null)
        {
            Amulet = heroSo.Amulet;
            iemLuck = heroSo.Sword.luckPercent;
        }

        ProfitPercent = heroSo.ProfitPercent;
        ProtectPercent = heroSo.ProtectPercent;
        LuckPercent = heroSo.LuckPercent;
        ComboPercent = heroSo.ComboPercent;

        ProfitPercent +=  ItemProfit;
        ProtectPercent +=  ItemProtect;
        LuckPercent +=  iemLuck;
    }
    public int GoldProfit() => startGold * Level * Level;
    public int GoldToGrade() => startGold * (Level + 1) * (Level + 1) * 100; 
    public void LelelUp()
    {
        //изменени€ значений
        if (Level < 100)
        {
            Level++;
            if (Level == 50)
            {
                rank = 2;
            }
            else if (Level == 100)
            {
                rank = 3;
            }
            goldToGrade = GoldToGrade();
            ProfitPercent = GoldProfit();
        }
    }
    public void GetInfo(out int _ID, out string _name, out Sprite _heroIcon, out Sprite rank_1, out Sprite rank_2, out Sprite rank_3,
        out int _Level, out int _rank, out long _goldToGrade, out long _ProfitPercent, out int _LuckPercent, out int _ProtectPercent, out int _ComboPercent,
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

        if (savedHero.Sword != null)
        {
            Sword = savedHero.Sword;
            ItemProfit = savedHero.Sword.profitPercent;
        }
        if (savedHero.Shield != null)
        {
            Shield = savedHero.Shield;
            ItemProtect = savedHero.Sword.defencePercent;
        }
        if (savedHero.Amulet != null)
        {
            Amulet = savedHero.Amulet;
            iemLuck = savedHero.Sword.luckPercent;
        }
        ProfitPercent = savedHero.ProfitPercent;
        ProtectPercent = savedHero.ProtectPercent;
        LuckPercent = savedHero.LuckPercent;
        ComboPercent = savedHero.ComboPercent;

        ProfitPercent += ItemProfit;
        ProtectPercent +=  ItemProtect;
        LuckPercent +=  iemLuck;



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
        startGold = savedHero.startGold;
        goldToGrade = savedHero.GoldToGrade();

        if (savedHero.Sword != null)
        {
            Sword = savedHero.Sword;
            ItemProfit = savedHero.Sword.profitPercent;
        }
        if (savedHero.Shield != null)
        {
            Shield = savedHero.Shield;
            ItemProtect = savedHero.Sword.defencePercent;
        }
        if (savedHero.Amulet != null)
        {
            Amulet = savedHero.Amulet;
            iemLuck = savedHero.Sword.luckPercent;
        }
        ProfitPercent = savedHero.ProfitPercent;
        ProtectPercent = savedHero.ProtectPercent;
        LuckPercent = savedHero.LuckPercent;
        ComboPercent = savedHero.ComboPercent;

        ProfitPercent += ItemProfit;
        ProtectPercent +=  ItemProtect;
        LuckPercent +=  iemLuck;
    }
}
