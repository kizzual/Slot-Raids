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
    public float m_timer;
    public int m_currentRaid;
    [SerializeField] private List<GameObject> AttentionIcon;
    [SerializeField] private GameObject TowerButton;
    [SerializeField] private Image mana_Img;
    public List<BoostCard> RandomCards = new List<BoostCard>();
    public List<ParticleSystem> actiateBoost;
    public List<GameObject> ActivePanel;

    private void FixedUpdate()
    { 
        if (CurrentBoost != null)
        {
            if (CurrentBoost.isActive)
            {
                if(boostUI.gameObject.activeSelf)
                {
                    boostUI.ShowActiveBoost(m_timer, CurrentBoost);
                }
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
        if (CurrentBoost != null)
        {
            if (m_currentRaid >= RaidToActivateBoost_required)
            {
                m_timer = 0;
                m_currentRaid = 0;
                CurrentBoost.isActive = true;
                boostUI.SwitchCurrentCardImage(CurrentBoost);
                if (m_currentRaid >= RaidToActivateBoost_required)
                    GlovalEventSystem.BoostIsReady();
                else
                    GlovalEventSystem.BoostIsNotReady();
                float tmp = ((float)m_currentRaid / (float)RaidToActivateBoost_required);
                foreach (var item in manaImg)
                {
                    item.fillAmount = tmp;
                }
                mana_Img.fillAmount = tmp;
                CheckBoostType();
                SoundControl._instance.ActivateBoost();
                foreach (var item in actiateBoost)
                {
                    item.Play();
                }
                GlovalEventSystem.TutorialStepsThirdPart(20);
                foreach (var item in ActivePanel)
                {
                    item.SetActive(true);
                }
            }
        }
    }
    public void LoadBoost(BoostSaver card)
    {
        FullCardList = card.FullCardList;
        activeCard = card.activeCard;
        m_currentRaid = card.CurrentRaids;
        if(card.currentCard != null)
        {
            CurrentBoost = card.currentCard;
            if(card.isActive)
            {
                CurrentBoost.isActive = true;
                m_timer = card.timer;
                boostUI.SwitchCurrentCardImage(CurrentBoost);
                if (m_currentRaid >= RaidToActivateBoost_required)
                    GlovalEventSystem.BoostIsReady();
                else
                    GlovalEventSystem.BoostIsNotReady();
                float tmp = ((float)m_currentRaid / (float)RaidToActivateBoost_required);
                foreach (var item in manaImg)
                {
                    item.fillAmount = tmp;
                }
                mana_Img.fillAmount = tmp;
                CheckBoostType();
                foreach (var item in ActivePanel)
                {
                    item.SetActive(true);
                }

            }
            else
            {
                CurrentBoost.isActive = false;
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
        CurrentBoost.isActive = false;
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
        CurrentBoost.isActive = false;
        SoundControl._instance.DeActivateBoost();
        CurrentBoost = null;
        RandomizeCard();
        foreach (var item in ActivePanel)
        {
            item.SetActive(false);
        }
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
            GlovalEventSystem.BoostIsReady();
        else
            GlovalEventSystem.BoostIsNotReady();
       
    }
    public void OpenBoostPanel()
    {
        boostUI.gameObject.SetActive(true);
        TowerButton.transform.GetChild(1).gameObject.SetActive(false);
        TowerButton.transform.GetChild(2).gameObject.SetActive(true);
        GlovalEventSystem.TutorialStepsThirdPart(19);
        if (CurrentBoost != null)
        {
            if(CurrentBoost.isActive)
            {
                boostUI.ShowActiveBoost(m_timer, CurrentBoost);
            }
            else
            {
                RandomizeCard();
                return;
            }
        }
        else
        {
            RandomizeCard();
            return;
        }
       
    }
    public void OpenCard(BoostCard card)
    {
        activeCard.Add(card);
        FullCardList.Remove(card);
    }
    public void RandomizeCard()
    {
        if (activeCard.Count > 0)
        {
            RandomCards.Clear();
            if (activeCard.Count <= 3)
            {
                for (int i = 0; i < activeCard.Count; i++)
                {
                    RandomCards.Add(activeCard[i]);
                }
            }
            else
            {
                int check = 0;
                while (activeCard.Count < 3 || check < 20)
                {
                    check++;
                    int rng = UnityEngine.Random.Range(0, activeCard.Count);
                    if (activeCard.Count == 0)
                    {
                        RandomCards.Add(activeCard[rng]);
                    }
                    else
                    {
                        bool isEmptyCard = true;
                        foreach (var item in RandomCards)
                        {
                            if (activeCard[rng] == item)
                                isEmptyCard = false;
                        }
                        if (isEmptyCard)
                            RandomCards.Add(activeCard[rng]);
                    }
                }
            }
        }
        boostUI.ShowCard(RandomCards);
    }

    public void ChooseBoostCard(int index)
    {
        CurrentBoost = RandomCards[index];
        ActivateBoost();

    }
}

