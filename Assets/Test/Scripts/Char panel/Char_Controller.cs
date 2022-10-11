using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    [SerializeField] private List<Char_panel> char_Panels; 
    [SerializeField] private GameObject attentioinIcon; 

    public void ActivateEvent()
    {
        GlovalEventSystem.OnHeroUpgrade += ChangeHeroStats;
    }
    public void DeActivateEvent()
    {
        GlovalEventSystem.OnHeroUpgrade -= ChangeHeroStats;
    }
    public void ChangeHeroStats(Hero hero)
    {
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                char_Panels[0].ChangeHeroStats(hero);
                break;
            case TypeElement.Undead:
                char_Panels[1].ChangeHeroStats(hero);
                break;
            case TypeElement.Order:
                char_Panels[2].ChangeHeroStats(hero);
                break;
            case TypeElement.Demon:
                char_Panels[3].ChangeHeroStats(hero);
                break;
            default:
                break;
        }
    }
    public void CheckForNewHeroes()
    {
        bool HasNewHeroes = false;
        bool tmp  = false;
        for (int j = 0; j < char_Panels[0]._charSlots.Count; j++)
        {
            if (char_Panels[0]._charSlots[j].m_CurrentHero.isNewHero && char_Panels[0]._charSlots[j].m_CurrentHero.isOpened)
            {
                HasNewHeroes = true;
                tmp = true;
                char_Panels[0].AttentionIcon.SetActive(true);
            }
        }
        if (HasNewHeroes)
        {
            attentioinIcon.SetActive(true);
            char_Panels[0].AttentionIcon.SetActive(true);
        }
        else
        {
            attentioinIcon.SetActive(false);
            char_Panels[0].AttentionIcon.SetActive(false);
        }
        HasNewHeroes = false;
        for (int j = 0; j < char_Panels[1]._charSlots.Count; j++)
        {
            if (char_Panels[1]._charSlots[j].m_CurrentHero.isNewHero && char_Panels[1]._charSlots[j].m_CurrentHero.isOpened)
            {
                HasNewHeroes = true;
                tmp = true;
                char_Panels[1].AttentionIcon.SetActive(true);
            }
        }
        if (HasNewHeroes)
        {
            attentioinIcon.SetActive(true);
            char_Panels[1].AttentionIcon.SetActive(true);
        }
        else
        {
            attentioinIcon.SetActive(false);
            char_Panels[1].AttentionIcon.SetActive(false);
        }
        HasNewHeroes = false;
        for (int j = 0; j < char_Panels[2]._charSlots.Count; j++)
        {
            if (char_Panels[2]._charSlots[j].m_CurrentHero.isNewHero && char_Panels[2]._charSlots[j].m_CurrentHero.isOpened)
            {
                HasNewHeroes = true;
                tmp = true;
                char_Panels[2].AttentionIcon.SetActive(true);
            }
        }
        if (HasNewHeroes)
        {
            attentioinIcon.SetActive(true);
            char_Panels[2].AttentionIcon.SetActive(true);
        }
        else
        {
            attentioinIcon.SetActive(false);
            char_Panels[2].AttentionIcon.SetActive(false);
        }
        HasNewHeroes = false;
        for (int j = 0; j < char_Panels[3]._charSlots.Count; j++)
        {
            if (char_Panels[3]._charSlots[j].m_CurrentHero.isNewHero && char_Panels[3]._charSlots[j].m_CurrentHero.isOpened)
            {
                HasNewHeroes = true;
                tmp = true;
                char_Panels[3].AttentionIcon.SetActive(true);
            }
        }
        if (HasNewHeroes)
            char_Panels[3].AttentionIcon.SetActive(true);
        else
            char_Panels[3].AttentionIcon.SetActive(false);
        if (tmp )
            attentioinIcon.SetActive(true);
        else
            attentioinIcon.SetActive(false);

        Debug.Log("Check atetention ");
    }
    private void OnEnable()
    {
        CheckForNewHeroes();
    }
}
