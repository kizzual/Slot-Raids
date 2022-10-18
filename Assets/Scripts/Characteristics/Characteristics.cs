using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private HeroInfo_Ui hero_Ui;
    [SerializeField] private GameObject front_panel;
    [SerializeField] private ParticleSystem _upgradeParticle;
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private AddingItem addingItem;

    private Hero m_currentHero;

    public void OpenHeroStats(Hero hero)
    {
        front_panel.SetActive(true);
        gameObject.SetActive(true);
        m_currentHero = hero;
        hero.isNewHero = false;
        char_Controller.CheckForNewHeroes();
        hero_Ui.InitialiseHero(hero);
    }
    public void UpgradeHeroStats(Hero hero) => hero_Ui.InitialiseHero(hero);
    public void UpgradeHero()
    {
        if (m_currentHero != null)

        {
            if (Gold.GetCurrentGold() >= m_currentHero.GoldToGrade)
            {
                Gold.SpendGold(m_currentHero.GoldToGrade);
                m_currentHero.LevelUp();
                hero_Ui.InitialiseHero(m_currentHero);
                raid_control.UpdateHeroStats(m_currentHero);
                char_Controller.ChangeHeroStats(m_currentHero);
                UpgradeHeroStats(m_currentHero);
                SoundControl._instance.UpgradeHero();
                _upgradeParticle.Play();
            }
            else
            {
                SoundControl._instance.NoMoney();
            }
        }
    }
    public void CheckActiveRaid(bool RaidIsActive) => hero_Ui.CheckActiveRaid(RaidIsActive);
 
    public void CheckRaidTimer(float time) => hero_Ui.CheckRaidTime(time);
    public void ClosePanel()
    {
        front_panel.SetActive(false);
        gameObject.SetActive(false);
    }
    public void AddItem(int itemIndex)
    {
        if (itemIndex == 1)
            addingItem.OpenPanel_Sword(m_currentHero);
        else if (itemIndex == 2)
            addingItem.OpenPanel_Shield(m_currentHero);
        else if (itemIndex == 3)
            addingItem.OpenPanel_Amulet(m_currentHero);

    }
    public void RemoveHero()
    {
        raid_control.RemoveHero(m_currentHero.currentRaidSlot);
        m_currentHero.currentRaidSlot = 0;
        OpenHeroStats(m_currentHero);
    }
}
