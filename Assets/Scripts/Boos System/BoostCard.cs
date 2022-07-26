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


}
public enum CardBoostType
{
    GoldProfit,
    LuckZoneProfit,
    UnLuckZoneProfit,
    LuckZoneProfit_byElement,
    UnLuckZoneProfit_byElement,
    HerLuck_byElement,
    HeroUnLuck_byElement,
    HeroCombo,
    HeroCombo_byElement
}
