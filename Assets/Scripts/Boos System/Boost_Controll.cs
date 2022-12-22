using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public TowerUpgrade towerUpgrade;
    public List<Image> manaImg;
    public float m_timer;
    public int m_currentRaid;
    [SerializeField] private List<GameObject> AttentionIcon;
    [SerializeField] private GameObject TowerButton;
    [SerializeField] private Image mana_Img;
    public List<BoostCard> RandomCards = new List<BoostCard>();
    public List<ParticleSystem> actiateBoost;
    public List<GameObject> ActivePanel;
    public Raid_control raid_Control;
    public int m_currentBottles;
    [SerializeField] private TextMeshProUGUI bottles_count_green;
    [SerializeField] private TextMeshProUGUI bottles_count_Blue;
    [SerializeField] private TextMeshProUGUI bottles_count_Yellow;
    [SerializeField] private TextMeshProUGUI bottles_count_Red;
    [SerializeField] private List<GameObject> bottles_image;
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
        /*        if (m_currentRaid >= RaidToActivateBoost_required)
                   // буст готов (аттеншин)
                else
                            // буст не готов (аттеншин)*/
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
           //     GlovalEventSystem.TutorialStepsThirdPart(20);
                foreach (var item in ActivePanel)
                {
                    item.SetActive(true);
                }
                raid_Control.ActivateBoost();
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
                /*        if (m_currentRaid >= RaidToActivateBoost_required)
                    // буст готов (аттеншин)
                 else
                             // буст не готов (аттеншин)*/
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
        towerUpgrade.CheckBoostParticle();
        m_currentBottles = card.currentBottles;
        DisplayCurrentBottles();
        if (m_currentBottles > 0 )
        {
            foreach (var item in bottles_image)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (var item in bottles_image)
            {
                item.SetActive(false);
            }
        }

    }
    private void CheckBoostType()
    {
        if (CurrentBoost.cardBoostType == CardBoostType.GoldProfit)
        {
            raid_Control.GoldBoostActivate(CurrentBoost.GoldProfit);
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
            raid_Control.ItemBoostActivate(CurrentBoost.ItemProfit);
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
        raid_Control.GoldBoostDeActivate();
        raid_Control.ItemBoostDeActivate();
        CurrentBoost.isActive = false;
        SoundControl._instance.DeActivateBoost();
        CurrentBoost = null;
        ShowBaseCards();
        foreach (var item in ActivePanel)
        {
            item.SetActive(false);
        }
        foreach (var item in actiateBoost)
        {
            item.Stop();
        }
    }
    public void RaidComplete()
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

        /*        if (m_currentRaid >= RaidToActivateBoost_required)
                      // буст готов (аттеншин)
                   else
                               // буст не готов (аттеншин)*/

    }
    public void AddBottles(int value)
    {
        m_currentBottles += value;
    }
    public int getBottlesCount() => m_currentBottles;
    public void BuyBottles(int value) 
    {
        Debug.Log("Start buy bottle (boost control)");
        try
        {
            m_currentBottles += value;
            Debug.Log("Bottles added  (boost control)  =    " + m_currentBottles);
        }
        catch
        {
            Debug.Log("Bottles not added  (boost control)");
        }

        try
        {
            DisplayCurrentBottles();
            Debug.Log("Text bottle diplayed  (boost control)");
        }
        catch
        {
            Debug.Log("Text bottle NOT diplayed  (boost control)");
        }

        try
        {
            if (m_currentBottles > 0)
            {
                foreach (var item in bottles_image)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                foreach (var item in bottles_image)
                {
                    item.SetActive(false);
                }
            }
            Debug.Log("Image diplayed (boost control)");
        }
        catch
        {
            Debug.Log("Image NOT diplayed (boost control)");
        }



    }
    private void DisplayCurrentBottles()
    {
        try
        {
            if(bottles_count_green.gameObject != null)
            {
                bottles_count_green.text = m_currentBottles.ToString();
            }
            else
            {
                Debug.Log("bottles_count_green  = NULL (boost control)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_green  NOT displayed (boost control)");
        }
        try
        {
            if (bottles_count_Blue.gameObject != null)
            {
                bottles_count_Blue.text = m_currentBottles.ToString();
            }
            else
            {
                Debug.Log("bottles_count_Blue  = NULL (boost control)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_Blue  NOT displayed (boost control)");
        }
        try
        {
            if (bottles_count_Yellow.gameObject != null)
            {
                bottles_count_Yellow.text = m_currentBottles.ToString();
            }
            else
            {
                Debug.Log("bottles_count_Yellow  = NULL (boost control)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_Yellow  NOT displayed (boost control)");
        }
        try
        {
            if (bottles_count_Red.gameObject != null)
            {
                bottles_count_Red.text = m_currentBottles.ToString();
            }
            else
            {
                Debug.Log("bottles_count_Red  = NULL (boost control)");
            }
        }
        catch
        {
            Debug.Log("bottles_count_Red  NOT displayed (boost control)");
        }
       
    }
    public void FillMana( )
    {
        if(m_currentBottles > 0)
        {
            m_currentBottles--;
               m_currentRaid = RaidToActivateBoost_required;

            float tmp = ((float)m_currentRaid / (float)RaidToActivateBoost_required);
            foreach (var item in manaImg)
            {
                item.fillAmount = tmp;
            }
            mana_Img.fillAmount = tmp;
           DisplayCurrentBottles();
            if (m_currentBottles > 0)
            {
                foreach (var item in bottles_image)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                foreach (var item in bottles_image)
                {
                    item.SetActive(false);
                }
            }
        }


        /*        if (m_currentRaid >= RaidToActivateBoost_required)
                    // буст готов (аттеншин)
                 else
                             // буст не готов (аттеншин)*/
    }
    public void OpenBoostPanel()
    {
        boostUI.gameObject.SetActive(true);
        TowerButton.transform.GetChild(1).gameObject.SetActive(false);
        TowerButton.transform.GetChild(2).gameObject.SetActive(true);
     //   GlovalEventSystem.TutorialStepsThirdPart(19);
        if (CurrentBoost != null)
        {
            if(CurrentBoost.isActive)
            {
                boostUI.ShowActiveBoost(m_timer, CurrentBoost);
                foreach (var item in actiateBoost)
                {
                    item.Play();
                }
            }
            else
            {
                ShowBaseCards();
                return;
            }
        }
        else
        {
            ShowBaseCards();
            return;
        }
       
    }
    public void OpenCard(BoostCard card)
    {
        activeCard.Add(card);
        FullCardList.Remove(card);
    }
    private void ShowBaseCards()
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
            for (int i = 0; i < 3; i++)
            {
                RandomCards.Add(activeCard[i]);
            }
        }
        boostUI.ShowCard(RandomCards);
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
    private void Awake()
    {
        DisplayCurrentBottles();
        if (m_currentBottles > 0)
        {
            foreach (var item in bottles_image)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (var item in bottles_image)
            {
                item.SetActive(false);
            }
        }
    }
    public void ChooseBoostCard(int index)
    {
        CurrentBoost = RandomCards[index];
        ActivateBoost();

    }
}

