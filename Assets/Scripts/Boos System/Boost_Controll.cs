using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Controll : MonoBehaviour
{
    public List<BoostCard> FullCardList;
    public List<BoostCard> activeCard;
    public BoostUI boostUI;
    public List<Hero> Heroes;
    public List<Zone> Zones;
    public int RaidToActivateBoost_required;
    public BoostCard CurrentBoost;
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
    public void ActivateBoost()
    {
        if (!CurrentBoost.isActive && m_currentRaid >= RaidToActivateBoost_required)
        {
            m_timer = 0;
            m_currentRaid = 0;
            CheckBoostType();
            CurrentBoost.isActive = true;
        }

    }
    private void CheckBoostType()
    {
        if (CurrentBoost.cardBoostType == CardBoostType.GoldProfit)
        {
            GlovalEventSystem.GoldBoostActivate(CurrentBoost.GoldProfit);
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.GoldProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                   item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                   item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                   item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, CurrentBoost.GoldProfit, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.GoldProfit_byHeroes)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, 0, CurrentBoost.GoldProfit, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.itemProfit)
        {
            GlovalEventSystem.ItemBoostActivate(CurrentBoost.ItemProfit);
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.itemProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                   item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                   item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                   item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, 0, CurrentBoost.ItemProfit);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.itemProfit_byHeroes)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, 0, 0, CurrentBoost.ItemProfit);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.LuckProfit)
        {
            foreach (var item in Heroes)
            {
                item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0, 0);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.LuckProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                  item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                  item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                  item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.LuckProfit_byHero)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.UnLuckProfit)
        {
            foreach (var item in Heroes)
            {
                item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0, 0);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.UnLuckProfit_byElement)
        {
            foreach (var item in Zones)
            {
                if (item.typeElement == Type__Element.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                  item.typeElement == Type__Element.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                  item.typeElement == Type__Element.Order && CurrentBoost.boostElement.element == Element.Order ||
                  item.typeElement == Type__Element.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.UnLuckProfit_byHero)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(CurrentBoost.Luck, CurrentBoost.UnLuck, 0, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.Combo)
        {
            foreach (var item in Heroes)
            {
                item.AddBust(0, 0, CurrentBoost.Combo, 0, 0);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.Combo_byHeroe)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddBust(0, 0, CurrentBoost.Combo, 0, 0);
                }
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.Discount)
        {
            foreach (var item in Heroes)
            {
                item.AddDiscountBoost(CurrentBoost.UpgradeHeroDiscount);
            }
        }
        else if (CurrentBoost.cardBoostType == CardBoostType.Discout_byHero)
        {
            foreach (var item in Heroes)
            {
                if (item.typeElement == TypeElement.Neutral && CurrentBoost.boostElement.element == Element.Neutral ||
                    item.typeElement == TypeElement.Undead && CurrentBoost.boostElement.element == Element.Undead ||
                    item.typeElement == TypeElement.Order && CurrentBoost.boostElement.element == Element.Order ||
                    item.typeElement == TypeElement.Demon && CurrentBoost.boostElement.element == Element.Demon)
                {
                    item.AddDiscountBoost(CurrentBoost.UpgradeHeroDiscount);
                }
            }
        }

    }
    public void RemoveBoost()
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

    public void OpenBoostPanel()
    {
        boostUI.ActiveteBoostButton(m_currentRaid, RaidToActivateBoost_required);
        boostUI.gameObject.SetActive(true);
    }
    public void OpenCard(BoostCard card)
    {
        activeCard.Add(card);
        FullCardList.Remove(card);
    }
    public void RandomizeCard()
    {
        int rng = Random.Range(0, activeCard.Count);
        CurrentBoost = activeCard[rng];
        boostUI.ShowCard(activeCard[rng]);
    }
}

