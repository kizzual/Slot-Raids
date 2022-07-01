using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSlot : MonoBehaviour
{
    [SerializeField] private Image currentHeroImage;
    [SerializeField] private Text currentRank;
    [SerializeField] private Text currentLvl;
    [SerializeField] private Text someNumber;
    [SerializeField] private GameObject freePanel;
    [SerializeField] private GameObject choosePanel;
    [SerializeField] private GameObject HeroPanel;
    [SerializeField] private GameObject EggPanel;
    [SerializeField] private GameObject FreeSlotPanel;
    [SerializeField] private GameObject FreeSlotPanel_txt;
    private ScrollingController _scrollingController;
    private ScrollingObjects _currentSlot;
    public  Hero currentHero;
    private bool isFree;
    public bool isEmpty;

    public void Initialise(Hero hero, bool isFree, ScrollingController scrollingController, ScrollingObjects currentSlot)
    {
        _scrollingController = scrollingController;
        _currentSlot = currentSlot;
        currentHeroImage.gameObject.SetActive(true);
        currentHeroImage.sprite = hero.heroIcon;
        someNumber.text = ConvertText.FormatNumb(hero.ProfitPercent);
        isEmpty = false;
        currentHero = hero;
        currentLvl.text = hero.Level.ToString();

        HeroPanel.SetActive(true);
        EggPanel.SetActive(false);
        FreeSlotPanel.SetActive(false);
        FreeSlotPanel_txt.SetActive(false);
        if (isFree)
        {
            freePanel.SetActive(false);
            choosePanel.SetActive(true);
        }
        else
        {
            freePanel.SetActive(true);
            choosePanel.SetActive(false);
        }
    }
    public void ShowClosedPanel()
    {
        Debug.Log("3");

        HeroPanel.SetActive(false);
        EggPanel.SetActive(false);
        FreeSlotPanel.SetActive(true);
        FreeSlotPanel_txt.SetActive(false);
    }
    public void ShowClosedPanel_txt()
    {
        HeroPanel.SetActive(false);
        EggPanel.SetActive(false);
        FreeSlotPanel.SetActive(false);
        FreeSlotPanel_txt.SetActive(true);
    }



}
