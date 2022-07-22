using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    [SerializeField] private List<Char_panel> char_Panels; 

    public void ActivateEvent()
    {
        GlovalEventSystem.OnHeroUpgrade += ChangeHeroStats;
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

}
