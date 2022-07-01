using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroSlot : MonoBehaviour
{

    public bool isEpmty = true;
    [SerializeField] private GameObject HeroPanel;
    [SerializeField] private GameObject EggPanel;
    [SerializeField] private GameObject FreePanel;
    [SerializeField] private GameObject ClosedPanel;
    [SerializeField] private GameObject SkipEggPanel;
    [SerializeField] private GameObject OpenEggPanel;
    [SerializeField] private Button OpenEggButton;
    [SerializeField] private Text timeToOpenEgg;

    [SerializeField] private Image heroIcon;
    [SerializeField] private Text heroRank_text;
    [SerializeField] private Text heroLevel_text;
    [SerializeField] private Text heroGoldProfit_text;
    [SerializeField] private Text heroGoldToLevelUp_text;
    [SerializeField] private Image EggImage;

    [SerializeField] private HeroPanel heroPanel;
    [SerializeField] private GameController gameController;
  
    private float timer;
    public Hero currentHero;   // панель для отображения


    private void Update()
    {
        timer += Time.deltaTime;

    }
    public void AddEgg(Sprite img)
    {
        //запустить таймер
        gameController.StartEggOpening(this);

        isEpmty = false;
        EggImage.sprite = img;
        HeroPanel.SetActive(false);
        EggPanel.SetActive(true);
        FreePanel.SetActive(false);
    }
    public void DisplayHEroInfo()
    {
        if (currentHero != null)
        {
            heroRank_text.text = currentHero.rank.ToString();
            heroLevel_text.text = currentHero.Level.ToString();
            heroGoldProfit_text.text = ConvertText.FormatNumb(currentHero.ProfitPercent);
            heroGoldToLevelUp_text.text = ConvertText.FormatNumb(currentHero.goldToGrade);
        }
    }
    private void OnEnable()
    {
        DisplayHEroInfo();
    }
    public void AddHero(Hero hero)      // добавить анимацию открытия 
    {
        currentHero.Initialise(hero);
        HeroPanel.SetActive(true);
        EggPanel.SetActive(false);
        FreePanel.SetActive(false);


        heroIcon.sprite = hero.heroIcon;
        DisplayHEroInfo();
    }
    public void DisplayTimer(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(86400 - time);

        timeToOpenEgg.text = ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();

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
    public void SkipEgg()
    {
        //условия времени открытия
        SkipEggPanel.SetActive(false);
        OpenEggPanel.SetActive(true);
        OpenEggButton.enabled = true;
        timeToOpenEgg.enabled = false;
    }
    public void FreeSloActive()
    {
        HeroPanel.SetActive(false);
        EggPanel.SetActive(false);
        FreePanel.SetActive(true);
    }
    public void ActivateFreePanel()
    {
        FreePanel.SetActive(true);
        ClosedPanel.SetActive(false);
    }

    public void UpgradeHero()
    {
        if(Gold.GetCurrentGold() >= currentHero.goldToGrade)
        {
            Gold.SpendGold(currentHero.goldToGrade);
            currentHero.LelelUp();
            DisplayHEroInfo();
        }

    }
}
