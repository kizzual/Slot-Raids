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
    private ScrollingController _scrollingController;
    private ScrollingObjects _currentSlot;
    public  Hero currentHero;
    private bool isFree;
    private bool isEmpty;

    public void Initialise(Hero hero, bool isFree, ScrollingController scrollingController, ScrollingObjects currentSlot)
    {
        _scrollingController = scrollingController;
        _currentSlot = currentSlot;
        currentHeroImage.sprite = hero.imageRank_1;
        isEmpty = false;
        currentHero = hero;
        currentLvl.text = hero.Level.ToString();

        HeroPanel.SetActive(true);
        EggPanel.SetActive(false);
        freePanel.SetActive(false);
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



}
