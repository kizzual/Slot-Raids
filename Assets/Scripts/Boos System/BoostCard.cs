using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCard : MonoBehaviour
{
    public CardBoostType cardBoostType;
    public BoostElement boostElement;
    public bool isActive;
    public float TimeDuration;

    public int GoldProfit;
    public int Luck;
    public int UnLuck;
    public int Combo;
    public int ItemProfit;
    public int UpgradeHeroDiscount;
    public bool isOpened;
}
public enum CardBoostType
{
    GoldProfit,
    GoldProfit_byElement,
    GoldProfit_byHeroes,

    itemProfit,
    itemProfit_byElement,
    itemProfit_byHeroes,

    LuckProfit,
    LuckProfit_byElement,
    LuckProfit_byHero,

    UnLuckProfit,
    UnLuckProfit_byElement,  
    UnLuckProfit_byHero,

    Combo,
    Combo_byElement,
    Combo_byHeroe,

    Discount,
    Discout_byHero
}
