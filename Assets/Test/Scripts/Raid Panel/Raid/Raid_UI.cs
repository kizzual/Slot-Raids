using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_UI : MonoBehaviour
{
    [Header("Border type")]
    [SerializeField] private List<GameObject> borders_type;
    [SerializeField] private List<GameObject> active_borders;
    [SerializeField] private List<GameObject> inActive_borders;

    [Space]
    [Header("Panels")]
    [SerializeField] private GameObject hero_panel;
    [SerializeField] private GameObject empty_panel;
    [SerializeField] private GameObject unraid_panel;
    [SerializeField] private List<GameObject> backGrounds;
    [SerializeField] private ParticleSystem _upgradeParticle;


    [SerializeField] private GameObject canGrade;
    [SerializeField] private GameObject cannotGrade;
    [Space]
    [Header("UI elements")]
    [SerializeField] private Text Rank;
    [SerializeField] private Text lvl;
    [SerializeField] private Text combo;
    [SerializeField] private Text goldToGrade;
    [SerializeField] private Image heroIcon;
    [SerializeField] private List<Image> diceBackGround;

    [SerializeField] private DiceControll diceControll;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private Characteristics characteristics;
    [SerializeField] private Adding_Hero_to_slot adding_Hero_to_slot;


    public Hero m_currentHero;
    public bool isOpened { get; set; }
    public int SlotNumber;
    public void Initialise(Hero hero)
    {
        ActivePanel_Hero();
        m_currentHero = hero;
        m_currentHero.currentRaidSlot = SlotNumber;
        Rank.text = "D" + hero.cube.edgesNumber.ToString();
        lvl.text = hero.Level.ToString();
        combo.text = ConvertText.FormatNumb(hero.GetGoldProfit());
        goldToGrade.text = ConvertText.FormatNumb(hero.GoldToGrade);
        heroIcon.sprite = hero.Icon;
     
        SwitchBorder_andArrows();
        diceControll.OpenCurrentDice(hero);
        if(Gold.GetCurrentGold() >= hero.GoldToGrade)
        {
            canGrade.SetActive(true);
            cannotGrade.SetActive(false);
        }
        else
        {
            canGrade.SetActive(false);
            cannotGrade.SetActive(true);
        }
    }
    public void SwitchBorder_andArrows()
    {

        foreach (var item in backGrounds)
        {
            item.SetActive(false);
        }
        foreach (var item in borders_type)
        {
            item.SetActive(false);
        }
        foreach (var item in inActive_borders)
        {
            item.SetActive(false);
        }
        foreach (var item in active_borders)
        {
            item.SetActive(false);
        }
        foreach (var item in diceBackGround)
        {
            item.gameObject.SetActive(false);
        }
        switch (CurrentZone.Current_Zone.typeElement)
        {
            case Type__Element.Neutral:
                backGrounds[0].SetActive(true);
                borders_type[0].SetActive(true);
                diceBackGround[0].gameObject.SetActive(true);
                if (m_currentHero != null)
                {
                    if (m_currentHero.typeElement == TypeElement.Neutral)
                    {
                        active_borders[0].SetActive(true);
                    }
                    else
                        inActive_borders[0].SetActive(true);
                }
                break;
            case Type__Element.Undead:
                backGrounds[1].SetActive(true);
                borders_type[1].SetActive(true);
                diceBackGround[2].gameObject.SetActive(true);
                if (m_currentHero != null)
                {
                    if (m_currentHero.typeElement == TypeElement.Undead)
                    {
                        active_borders[1].SetActive(true);
                    }
                    else
                        inActive_borders[1].SetActive(true);

                }
                break;
            case Type__Element.Order:
                backGrounds[2].SetActive(true);
                borders_type[2].SetActive(true);
                diceBackGround[2].gameObject.SetActive(true);
                if (m_currentHero != null)
                {
                    if (m_currentHero.typeElement == TypeElement.Order)
                    {
                            active_borders[2].SetActive(true);
                    }
                    else
                        inActive_borders[2].SetActive(true);
                }
                break;
            case Type__Element.Demon:
                backGrounds[3].SetActive(true);
                borders_type[3].SetActive(true);
                diceBackGround[3].gameObject.SetActive(true);
                if (m_currentHero != null)
                {
                    if (m_currentHero.typeElement == TypeElement.Demon)
                    {
                            active_borders[3].SetActive(true);
                    }
                    else
                        inActive_borders[3].SetActive(true);
                }
                break;
        }
    }
    private void ActivePanel_Empty()
    {
        hero_panel.SetActive(false);
        empty_panel.SetActive(true);
    }
    private void ActivePanel_Hero()
    {
        hero_panel.SetActive(true);
        empty_panel.SetActive(false);
    }
    public void CloseDice()
    {
        if (SlotNumber != 10)
        {
            if (m_currentHero != null)
            {
                ActivePanel_Hero();
            }
            else
                ActivePanel_Empty();
        }
        else
        {
            if (m_currentHero != null)
            {
                ActivePanel_Hero();
            }
            else
                ActivePanel_Empty();
        }
        if (Gold.GetCurrentGold() >= m_currentHero.GoldToGrade)
        {
            canGrade.SetActive(true);
            cannotGrade.SetActive(false);
        }
        else
        {
            canGrade.SetActive(false);
            cannotGrade.SetActive(true);
        }
    }
    public void CheckSlot()
    {
        if (SlotNumber != 10)
        {
                if (m_currentHero != null)
                {
                    ActivePanel_Hero();
                    Initialise(m_currentHero);
                }
                else
                    ActivePanel_Empty();
        }
        else
        {
            if (m_currentHero != null)
            {
                ActivePanel_Hero();
                Initialise(m_currentHero);
            }
            else
                ActivePanel_Empty();
        }
    }
    public void UpgradeHero()
    {
        if (Gold.GetCurrentGold() >= m_currentHero.GoldToGrade)
        {
            Gold.SpendGold(m_currentHero.GoldToGrade);
            m_currentHero.LevelUp();

            //    DisplayHeroInfirmation();
            raid_control.UpdateHeroStats(m_currentHero);
            char_Controller.ChangeHeroStats(m_currentHero);
            characteristics.UpgradeHeroStats(m_currentHero);
            SoundControl._instance.UpgradeHero();
            _upgradeParticle.Play();
            if (Gold.GetCurrentGold() >= m_currentHero.GoldToGrade)
            {
                canGrade.SetActive(true);
                cannotGrade.SetActive(false);
            }
            else
            {
                canGrade.SetActive(false);
                cannotGrade.SetActive(true);
            }
            //       if (Tutorial.CheckTutorStep() == 12)
            //          GlovalEventSystem.TutorialStepsSecondPart(12);
        }
        else
        {
            SoundControl._instance.NoMoney();
        }
    }

    public void RemoveHero()
    {
        m_currentHero = null;
        CheckSlot();
    }
    public DiceControll GetDice() => diceControll;
    public void AddHero() => adding_Hero_to_slot.OpenHeroPanel(this);


    public void OpenStats() => characteristics.OpenHeroStats(m_currentHero);
    public void CloseUnraidPanel() => unraid_panel.SetActive(false);
    public void OpenUnraidPanel() => unraid_panel.SetActive(true);
}
