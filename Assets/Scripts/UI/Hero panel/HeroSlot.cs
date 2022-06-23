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
    [SerializeField] private Image EggImage;

    public Hero currentHero;   // панель для отображения

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddEgg(Sprite img)
    {
        //запустить таймер
        isEpmty = false;
        EggImage.sprite = img;
        HeroPanel.SetActive(false);
        EggPanel.SetActive(true);
        FreePanel.SetActive(false);
    }
    
    public void AddHero(Hero hero)      // добавить анимацию открытия 
    {
        currentHero.Initialise(hero);
    //    _hero = hero;
        HeroPanel.SetActive(true);
        EggPanel.SetActive(false);
        FreePanel.SetActive(false);

        
        heroIcon.sprite = hero.heroIcon;
        //  heroRank_text.text = hero.
        heroLevel_text.text = hero.Level.ToString();
        //     heroGoldProfit_text
        heroGoldToLevelUp_text.text = hero.goldToGrade.ToString();
    }
    public void OpenInventoryToCheckEggs(ElementType elementType, EggOpening eggOpening)
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
   
}
