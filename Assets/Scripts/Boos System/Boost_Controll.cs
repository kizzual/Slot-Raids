using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost_Controll : MonoBehaviour
{
    public List<BoostCard> FullCardList;
    public List<BoostCard> activeCard;
    public BoostUI boostUI;
    public List<Hero> Heroes;
    public List<Zone> Zones;
    public int RaidToActivateBoost_required;
    public BoostCard CurrentBoost;
    public List<Image> manaImg;
    private float m_timer;
    private int m_currentRaid;
    [SerializeField] private List<GameObject> AttentionIcon;
    [SerializeField] private GameObject TowerButton;
    [SerializeField] private Image mana_Img;
    [SerializeField] private GameObject rng_button;
    [SerializeField] private GameObject Remove_button;
    [SerializeField] private GameObject MainText;
    [SerializeField] private Text Timer;
    private void FixedUpdate()
    {
        if (CurrentBoost != null)
        {
            if (CurrentBoost.isActive)
            {
                TimeSpan ts = TimeSpan.FromSeconds(CurrentBoost.TimeDuration - m_timer);
                Timer.text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
                
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
        if (activeCard.Count > 0)
        {
            if (!CurrentBoost.isActive && m_currentRaid >= RaidToActivateBoost_required)
            {
                m_timer = 0;
                m_currentRaid = 0;
                CheckBoostType();
                CurrentBoost.isActive = true;
                if (m_currentRaid >= RaidToActivateBoost_required)
                {
                    foreach (var item in AttentionIcon)
                    {
                        item.SetActive(true);
                    }
                }
                else
                {
                    foreach (var item in AttentionIcon)
                    {
                        item.SetActive(false);
                    }
                }
                Remove_button.SetActive(true);
                rng_button.SetActive(false);
                float tmp = ((float)m_currentRaid / (float)RaidToActivateBoost_required);
                foreach (var item in manaImg)
                {
                    item.fillAmount = tmp;
                }
                mana_Img.fillAmount = tmp;
                Timer.gameObject.SetActive(true);
                MainText.gameObject.SetActive(false);
                boostUI.InActiveButton();
                Debug.Log("TEST");
                SoundControl._instance.ActivateBoost();
            }
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
        GlovalEventSystem.ItemBoostDeActivate();
        Remove_button.SetActive(false);
        rng_button.SetActive(true);
        CurrentBoost.isActive = false;
        Timer.gameObject.SetActive(false);
        MainText.gameObject.SetActive(true);
        SoundControl._instance.DeActivateBoost();

    }
    private void RaidComplete(List<Item> items)
    {
        if (m_currentRaid < RaidToActivateBoost_required)
        {
            m_currentRaid++;
            float tmp = ((float)m_currentRaid / (float)RaidToActivateBoost_required);
            foreach (var item in manaImg)
            {
                item.fillAmount = tmp;
            }
            mana_Img.fillAmount = tmp;
        }

        if (m_currentRaid >= RaidToActivateBoost_required)
        {
            foreach (var item in AttentionIcon)
            {
                item.SetActive(true);
            }
            if(CurrentBoost != null)
               boostUI.ActivaButton_b();
            if (CurrentBoost != null)
            {
                if (CurrentBoost.isActive)
                {
                    boostUI.InActiveButton();
                }
                else
                {
                    boostUI.ActivaButton_b();
                }
            }
        }
        else
        {
            foreach (var item in AttentionIcon)
            {
                item.SetActive(false);
            }

        }
       
    //    boostUI.ActiveteBoostButton(m_currentRaid, RaidToActivateBoost_required);
    }
    public void OpenBoostPanel()
    {
       // boostUI.ActiveteBoostButton(m_currentRaid, RaidToActivateBoost_required);
        boostUI.gameObject.SetActive(true);
        TowerButton.transform.GetChild(1).gameObject.SetActive(false);
        TowerButton.transform.GetChild(2).gameObject.SetActive(true);
        if (activeCard.Count > 0 && CurrentBoost == null)
        {
            Debug.Log("ASD");
            int rng = UnityEngine.Random.Range(0, activeCard.Count);
            CurrentBoost = activeCard[rng];
            boostUI.ShowCard(activeCard[rng]);
        }
        else if (CurrentBoost != null)
        {
            boostUI.ShowCard(CurrentBoost);
            if (CurrentBoost.isActive)
            {
                Remove_button.SetActive(true);
                rng_button.SetActive(false);
                Timer.gameObject.SetActive(true);
                MainText.gameObject.SetActive(false);
                boostUI.InActiveButton();
            }
            else
            {
                Remove_button.SetActive(false);
                rng_button.SetActive(true);
                Timer.gameObject.SetActive(false);
                MainText.gameObject.SetActive(true);
                boostUI.ActivaButton_b();
            }
        }
    }
    public void OpenCard(BoostCard card)
    {
        activeCard.Add(card);
        FullCardList.Remove(card);
    }
    public void RandomizeCard()
    {
        if (activeCard.Count > 1)
        {
            int rng = UnityEngine.Random.Range(0, activeCard.Count);
            CurrentBoost = activeCard[rng];
            boostUI.ShowCard(activeCard[rng]);
        }
    }
    private void OnEnable()
    {
        if (activeCard.Count > 0 && CurrentBoost == null)
        {
            Debug.Log("ASD");
            int rng = UnityEngine.Random.Range(0, activeCard.Count);
            CurrentBoost = activeCard[rng];
            boostUI.ShowCard(activeCard[rng]);
        }
        else if(CurrentBoost != null)
        {
            boostUI.ShowCard(CurrentBoost);
            if (CurrentBoost.isActive)
            {
                Remove_button.SetActive(true);
                rng_button.SetActive(false);
                Timer.gameObject.SetActive(true);
                MainText.gameObject.SetActive(false);
                boostUI.InActiveButton();
            }
            else
            {
                Remove_button.SetActive(false);
                rng_button.SetActive(true);
                Timer.gameObject.SetActive(false);
                MainText.gameObject.SetActive(true);
                boostUI.ActivaButton_b();
            }
        }

    }
}

