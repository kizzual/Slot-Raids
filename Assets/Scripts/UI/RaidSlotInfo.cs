using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaidSlotInfo : MonoBehaviour
{
    [SerializeField] private Text Rank;
    [SerializeField] private Text lvl;
    [SerializeField] private Text combo;
    [SerializeField] private Text goldToGrade;

    [SerializeField] private Image heroIcon;
    [SerializeField] private Image elementIcon;

    [SerializeField] private Sprite neutralIcon;
    [SerializeField] private Sprite undeadIcon;
    [SerializeField] private Sprite orderIcon;
    [SerializeField] private Sprite demonIcon;


    [SerializeField] private GameObject HeroPanel;
    [SerializeField] private GameObject EmptyPanel;
    [SerializeField] private GameObject ClosedPanel;
    //   [SerializeField] private Sprite demonIcon;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void InitialiseHero(Hero hero)
    {
        ActiveHero();
        Rank.text = hero.rank.ToString();
        lvl.text = hero.Level.ToString();
        goldToGrade.text = hero.goldToGrade.ToString();
        heroIcon.sprite = hero.heroIcon;
        Debug.Log(hero.heroIcon);
        switch (hero.elementType)
        {
            case Hero.ElementType.Neutral:
                elementIcon.sprite = neutralIcon;
                break;
            case Hero.ElementType.Undead:
                elementIcon.sprite = undeadIcon;
                break;
            case Hero.ElementType.Order:
                elementIcon.sprite = orderIcon;
                break;
            case Hero.ElementType.Demon:
                elementIcon.sprite = demonIcon;
                break;
            default:
                break;
        }
    }

    public void ActiveHero()
    {
        HeroPanel.SetActive(true);
        EmptyPanel.SetActive(false);
        ClosedPanel.SetActive(false);
    }
    public void ActiveEmpty()
    {
        HeroPanel.SetActive(false);
        EmptyPanel.SetActive(true);
        ClosedPanel.SetActive(false);
    }
    public void ActiveClosed()
    {
        HeroPanel.SetActive(false);
        EmptyPanel.SetActive(false);
        ClosedPanel.SetActive(true);
    }

}
