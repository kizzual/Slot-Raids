using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Controll : MonoBehaviour
{
    public List<BoostCard> FullCardList;
    public List<BoostCard> activeCard;
    public BoostCard CurrentBoost;
    public List<Hero> Heroes;
    public List<Zone> Zones;
    public int RaidToActivateBoost_required;
    private float m_timer;
    private int m_currentRaid;
    private void FixedUpdate()
    {
        if (CurrentBoost != null)
        {
            if (CurrentBoost.isActive)
            {
                m_timer += Time.fixedDeltaTime;

                if (m_timer >= CurrentBoost.TimeDuration)
                {
                    CurrentBoost.isActive = false;
                    RemoveBoost();
                }
            }
        }
    }
    public void ActivateEvent()
    {
        GlovalEventSystem.OnWinItems += RaidComplete;
    }
    public void ActivateBoost(BoostCard card)
    {
        if (!card.isActive && m_currentRaid >= RaidToActivateBoost_required)
        {
            m_timer = 0;
            CurrentBoost = card;
            m_currentRaid = 0;
            CheckBoostType();
            card.isActive = true;
        }

    }
    private void CheckBoostType()
    {
      /*  if (CurrentBoost.cardBoostType == CardBoostType.GoldProfit)
        {
            GlovalEventSystem.GoldBoostActivate(CurrentBoost.GoldProfit);
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.HeroCombo)
        {
            foreach (var item in Heroes)
            {
                item.AddBust(0, 0, CurrentBoost.Combo);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.LuckZoneProfit)
        {
            foreach (var item in Zones)
            {
                item.AddBust(CurrentBoost.Luck, 0);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.UnLuckZoneProfit)
        {
            foreach (var item in Zones)
            {
                item.AddBust(0, CurrentBoost.UnLuck);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.UnLuckZoneProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, CurrentBoost.UnLuck);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.LuckZoneProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.HerLuck_byElement)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.HeroUnLuck_byElement)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, CurrentBoost.UnLuck, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.HeroCombo_byElement)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, CurrentBoost.Combo);
                }
            }
        }*/

    }
    private void RemoveBoost()
    {
        foreach (var item in Heroes)
        {
            item.RemoveBoost();
        }
        foreach (var item in Zones)
        {
            item.RemoveBoost();
        }
        GlovalEventSystem.GoldBoostDeActivate();
    }
    private void RaidComplete(List<Item> items)
    {
        if (m_currentRaid < RaidToActivateBoost_required)
        {
            m_currentRaid++;
        }
    }
}

