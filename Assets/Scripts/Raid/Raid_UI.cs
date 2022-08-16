using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_UI : MonoBehaviour
{
    [Header("Arrow Sprites")]
    [SerializeField] private Sprite neutralArrow;
    [SerializeField] private Sprite undeadArrow;
    [SerializeField] private Sprite orderArrow;
    [SerializeField] private Sprite demonArrow;

    [Space]
    [Header("Element Sprites")]
    [SerializeField] private Sprite neutralIcon;
    [SerializeField] private Sprite undeadIcon;
    [SerializeField] private Sprite orderIcon;
    [SerializeField] private Sprite demonIcon;
    [Space]
    [Header("Border Sprites")]
    [SerializeField] private List<Sprite> borderSPrites;
    [Header("Background Sprites")]
    [SerializeField] private List<Sprite> backgroundSPrites;

    [Space]
    [Header("Panels")]
    [SerializeField] private GameObject hero_panel;
    [SerializeField] private GameObject empty_panel;
    [SerializeField] private GameObject closed_panel;
    [SerializeField] private GameObject unraid_panel;
    [SerializeField] private List<GameObject> backGrounds;

    [SerializeField] private GameObject canGrade;
    [SerializeField] private GameObject cannotGrade;
    [Space]
    [Header("UI elements")]
    [SerializeField] private Text Rank;
    [SerializeField] private Text lvl;
    [SerializeField] private Text combo;
    [SerializeField] private Text goldToGrade;
    [SerializeField] private Image heroIcon;
    [SerializeField] private Image elementIcon;
    [SerializeField] private Image border;
    [SerializeField] private Image backGround;
    [SerializeField] private List<Sprite> BG;

    [SerializeField] private List<Image> arrows;
    [SerializeField] private List<Image> elementArrow;
    [SerializeField] private DiceControll diceControll;

    public Hero m_currentHero;
    public bool isOpened { get; set; }
    public int SlotNumber;
    public void Tester()
    {
        Debug.Log(m_currentHero.GoldToGrade);
    }
    public void Initialise(Hero hero)
    {
        ActivePanel_Hero();
        m_currentHero = hero;
        m_currentHero.currentRaidSlot = SlotNumber;
        Rank.text = "D " + hero.cube.edgesNumber.ToString();
        lvl.text = hero.Level.ToString();
        combo.text = "x" + hero.GetCombo().ToString();
        goldToGrade.text = ConvertText.FormatNumb(hero.GoldToGrade);
        heroIcon.sprite = hero.Icon;
        foreach (var item in elementArrow)
        {
            item.gameObject.SetActive(false);
        }
     
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
        foreach (var item in elementArrow)
        {
            item.gameObject.SetActive(false);
        }

        switch (CurrentZone.Current_Zone.typeElement)
        {
            case Type__Element.Neutral:
                backGrounds[0].SetActive(true);
                backGrounds[1].SetActive(true);
                border.sprite = borderSPrites[0];
                if (m_currentHero != null)
                {
                    backGround.sprite = BG[0];
                    if (m_currentHero.typeElement == TypeElement.Neutral)
                    {
                        
                        border.sprite = borderSPrites[1];
                        foreach (var item in elementArrow)
                        {
                            item.gameObject.SetActive(true);
                            item.sprite = neutralArrow;
                        }
                    }
                    else
                        border.sprite = borderSPrites[0];
                }
                break;
            case Type__Element.Undead:
                backGrounds[2].SetActive(true);
                backGrounds[3].SetActive(true);
                border.sprite = borderSPrites[2];
                if (m_currentHero != null)
                {
                    backGround.sprite = BG[1];
                    if (m_currentHero.typeElement == TypeElement.Undead)
                    {
                        border.sprite = borderSPrites[3];
                        foreach (var item in elementArrow)
                        {
                            item.gameObject.SetActive(true);
                            item.sprite = undeadArrow;
                        }
                    }
                    else
                        border.sprite = borderSPrites[2];
                }
                break;
            case Type__Element.Order:
                backGrounds[4].SetActive(true);
                backGrounds[5].SetActive(true);
                border.sprite = borderSPrites[4];
                if (m_currentHero != null)
                {
                    backGround.sprite = BG[2];
                    if (m_currentHero.typeElement == TypeElement.Order)
                    {
                        border.sprite = borderSPrites[5];
                        foreach (var item in elementArrow)
                        {
                            item.gameObject.SetActive(true);
                            item.sprite = orderArrow;
                        }
                    }
                    else
                        border.sprite = borderSPrites[4];
                }
                break;
            case Type__Element.Demon:
                backGrounds[6].SetActive(true);
                backGrounds[7].SetActive(true);
                border.sprite = borderSPrites[6];
                if (m_currentHero != null)
                {
                    backGround.sprite = BG[3];
                    if (m_currentHero.typeElement == TypeElement.Demon)
                    {
                        border.sprite = borderSPrites[7];
                        foreach (var item in elementArrow)
                        {
                            item.gameObject.SetActive(true);
                            item.sprite = demonArrow;
                        }
                    }
                    else
                        border.sprite = borderSPrites[6];
                }
                break;
        }
    }
    private void ActivePanel_Close()
    {
        hero_panel.SetActive(false);
        empty_panel.SetActive(false);
        closed_panel.SetActive(true);
    }
    private void ActivePanel_Empty()
    {
        hero_panel.SetActive(false);
        empty_panel.SetActive(true);
        closed_panel.SetActive(false);
    }
    private void ActivePanel_Hero()
    {
        hero_panel.SetActive(true);
        empty_panel.SetActive(false);
        closed_panel.SetActive(false);
    }
    public void CheckSlot()
    {
        if (SlotNumber != 10)
        {
            if (isOpened)
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
                ActivePanel_Close();
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
            GlovalEventSystem.HeroUpgrade(m_currentHero);
            SoundControl._instance.UpgradeHero();
            if (Tutorial.CheckTutorStep() == 12)
                GlovalEventSystem.TutorialStepsSecondPart(12);
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
    public void AddHero()
    {
        GlovalEventSystem.AddingHeroToSlot(this);
        GlovalEventSystem.TutorialSteps(6);
    }
    public void OpenStats() => GlovalEventSystem.OpenHeroStats(m_currentHero);
    public void CloseUnraidPanel() => unraid_panel.SetActive(false);
    public void OpenUnraidPanel() => unraid_panel.SetActive(true);
}
