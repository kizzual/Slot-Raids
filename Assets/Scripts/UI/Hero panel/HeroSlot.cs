using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSlot : MonoBehaviour
{
    public bool isEpmty = true;
    [SerializeField] private GameObject HeroPanel;
    [SerializeField] private GameObject EggPanel;
    [SerializeField] private GameObject FreePanel;
    
    [SerializeField] private Image heroIcon;
    [SerializeField] private Text heroRank_text;
    [SerializeField] private Text heroLevel_text;
    [SerializeField] private Text heroGoldProfit_text;
    [SerializeField] private Text heroGoldToLevelUp_text;
    [HideInInspector] public Hero currentHero;
    void Start()
    {

    }


    void Update()
    {

    }

    public void AddHero(Hero hero)
    {
        HeroPanel.SetActive(true);
        EggPanel.SetActive(false);
        FreePanel.SetActive(false);
        isEpmty = false;
        ChooseCurrentHero(hero);
        heroIcon.sprite = hero.imageRank_1;
        //  heroRank_text.text = hero.
        heroLevel_text.text = hero.Level.ToString();
        //     heroGoldProfit_text
        heroGoldToLevelUp_text.text = hero.goldToGrade.ToString();
    }
    public void AddEgg(ElementType elementType, EggOpening eggOpening)
    {
        switch (elementType)
        {
            case ElementType.Neutral:
                {
                    eggOpening.Open_NeutralEgg(this);
                    break;
                }
            case ElementType.Undead:
                {
                    eggOpening.Open_UndeadEgg(this);

                    break;
                }
            case ElementType.Order:
                {
                    eggOpening.Open_OrderEgg(this);

                    break;
                }
            case ElementType.Demon:
                {
                    eggOpening.Open_DemonEgg(this);

                    break;
                }
        }
    }
    public void FreeSloActive()
    {
        HeroPanel.SetActive(false);
        EggPanel.SetActive(false);
        FreePanel.SetActive(true);
    }
    public void ChooseCurrentHero(Hero hero)
    {
        currentHero = hero;
    }
}
