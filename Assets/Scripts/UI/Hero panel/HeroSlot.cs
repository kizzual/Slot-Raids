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
        
   //     heroIcon.sprite = hero.image;
     //   heroLvl_text.text = hero.Level.ToString();
    }
    public void AddEgg()
    {
        HeroPanel.SetActive(false);
        EggPanel.SetActive(true);
        FreePanel.SetActive(false);
    }
    public void FreeSloActive()
    {
        HeroPanel.SetActive(false);
        EggPanel.SetActive(false);
        FreePanel.SetActive(true);
    }

}
