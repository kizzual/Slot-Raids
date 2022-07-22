using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private HeroInfo_Ui hero_Ui;
    [SerializeField] private GameObject front_panel;

    private Hero m_currentHero;

    public void ActivateEvent()
    {
        GlovalEventSystem.OnHOpenHeroStats += OpenHeroStats;
        GlovalEventSystem.OnHeroUpgrade += UpgradeHeroStats;
    }
    public void OpenHeroStats(Hero hero)
    {
        front_panel.SetActive(true);
        gameObject.SetActive(true);
        m_currentHero = hero;
        hero_Ui.InitialiseHero(hero);
    }
    private void UpgradeHeroStats(Hero hero) => hero_Ui.InitialiseHero(hero);
    public void UpgradeHero()
    {
        if (m_currentHero != null)
        {
            if (Gold.GetCurrentGold() >= m_currentHero.GoldToGrade)
            {
                Gold.SpendGold(m_currentHero.GoldToGrade);
                m_currentHero.LevelUp();
                hero_Ui.InitialiseHero(m_currentHero);
                GlovalEventSystem.HeroUpgrade(m_currentHero);
            }
        }
    }
    public void ClosePanel()
    {
        front_panel.SetActive(false);
        gameObject.SetActive(false);
    }
    public void AddItem(int itemIndex)
    {
        if (itemIndex == 1)
            GlovalEventSystem.Adding_sword(m_currentHero);
        else if (itemIndex == 2)
            GlovalEventSystem.Adding_shield(m_currentHero);
        else if (itemIndex == 3)
            GlovalEventSystem.Adding_amulet(m_currentHero);

    }
    public void RemoveHero()
    {
        GlovalEventSystem.RemoveFromSlot(m_currentHero.currentRaidSlot);
        m_currentHero.currentRaidSlot = 0;
        OpenHeroStats(m_currentHero);
    }
}
