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

    [SerializeField] private List<GameObject> neutralPanels;
    [SerializeField] private List<GameObject> undeadPanels;
    [SerializeField] private List<GameObject> orderPanels;
    [SerializeField] private List<GameObject> demonPanels;
    [SerializeField] private Image Border;


    [SerializeField] private List<Image> arrows;
    [SerializeField] private List<Image> elementArrow;
    //   [SerializeField] private Sprite demonIcon;

    [SerializeField] private Sprite neutralArrow;
    [SerializeField] private Sprite undeadArrow;
    [SerializeField] private Sprite orderArrow;
    [SerializeField] private Sprite demonArrow;

    [SerializeField] private List<Sprite> BorderSPrites;

    public void InitialiseHero(Hero hero)
    {
        ActiveHero();
        Rank.text = hero.rank.ToString();
        lvl.text = hero.Level.ToString();
        combo.text = "x" + hero.ComboPercent;
        goldToGrade.text = ConvertText.FormatNumb(hero.goldToGrade);
        heroIcon.sprite = hero.heroIcon;
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
        foreach (var item in arrows)
        {
            item.enabled = true;
        }
    }
    public void ActiveEmpty(Zone zone = null)
    {
        HeroPanel.SetActive(false);
        EmptyPanel.SetActive(true);
        ClosedPanel.SetActive(false);
        foreach (var item in arrows)
        {
            item.enabled = false;
        }
    }
    public void ActiveClosed(Zone zone = null)
    {

        HeroPanel.SetActive(false);
        EmptyPanel.SetActive(false);
        ClosedPanel.SetActive(true);
        foreach (var item in arrows)
        {
            item.enabled = false;
        }


    }
    public void SwitchBackground(Zone zone)
    {
        if(zone.ZoneElement == Zone.zoneElement.Neutral)
        {
            foreach (var item in neutralPanels)
            {
                item.SetActive(true);
            }
            foreach (var item in undeadPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in orderPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in demonPanels)
            {
                item.SetActive(false);
            }
            Border.sprite = Border.sprite = BorderSPrites[0];

        }
        else if(zone.ZoneElement == Zone.zoneElement.Undead)
        {
            foreach (var item in neutralPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in undeadPanels)
            {
                item.SetActive(true);
            }
            foreach (var item in orderPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in demonPanels)
            {
                item.SetActive(false);
            }
            Border.sprite = Border.sprite = BorderSPrites[2];
        }
        else if (zone.ZoneElement == Zone.zoneElement.Order)
        {
            foreach (var item in neutralPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in undeadPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in orderPanels)
            {
                item.SetActive(true);
            }
            foreach (var item in demonPanels)
            {
                item.SetActive(false);
            }
            Border.sprite = Border.sprite = BorderSPrites[4];
        }
        else if (zone.ZoneElement == Zone.zoneElement.Demon)
        {
            foreach (var item in neutralPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in undeadPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in orderPanels)
            {
                item.SetActive(false);
            }
            foreach (var item in demonPanels)
            {
                item.SetActive(true);
            }
        }
        Border.sprite = Border.sprite = BorderSPrites[6];
    }
    public void SwitchBorderImage(Hero hero, Zone zone )
    {
        if (zone.ZoneElement == Zone.zoneElement.Neutral)
        {
            if (hero != null)
            {
                if (hero.elementType == Hero.ElementType.Neutral)
                {
                    Border.sprite = BorderSPrites[1];

                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = true;
                            tmp.sprite = neutralArrow;
                        }
                    }
                }
                else
                {
                    Border.sprite = BorderSPrites[0];
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = false;
                            tmp.sprite = neutralArrow;
                        }
                    }
                }
            }
            else
            {
                Border.sprite = BorderSPrites[0];
            }
        }
        else if (zone.ZoneElement == Zone.zoneElement.Undead)
        {
            if (hero != null)
            {
                if (hero.elementType == Hero.ElementType.Undead)
                {
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = true;
                            tmp.sprite = undeadArrow;
                        }
                    }

                    Border.sprite = BorderSPrites[3];
                }
                else
                {
                    Border.sprite = BorderSPrites[2];
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = false;
                            tmp.sprite = neutralArrow;
                        }
                    }
                }
            }
            else
            {
                Border.sprite = BorderSPrites[2];
            }
        }
        else if (zone.ZoneElement == Zone.zoneElement.Order)
        {
            if (hero != null)
            {
                if (hero.elementType == Hero.ElementType.Order)
                {
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = true;
                            tmp.sprite = orderArrow;
                        }
                    }

                    Border.sprite = BorderSPrites[5];
                }
                else
                {
                    Border.sprite = BorderSPrites[4];
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = false;
                            tmp.sprite = neutralArrow;
                        }
                    }
                }
            }
            else
            {
                Border.sprite = BorderSPrites[4];
            }
        }
        else if (zone.ZoneElement == Zone.zoneElement.Demon)
        {
            if (hero != null)
            {
                if (hero.elementType == Hero.ElementType.Demon)
                {
                    Border.sprite = BorderSPrites[7];

                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = true;
                            tmp.sprite = demonArrow;
                        }
                    }
                }
                else
                {
                    Border.sprite = BorderSPrites[6];
                    foreach (var item in arrows)
                    {
                        item.enabled = true;
                        foreach (var tmp in elementArrow)
                        {
                            tmp.enabled = false;
                            tmp.sprite = neutralArrow;
                        }
                    }
                }
            }
            else
            {
                Border.sprite = BorderSPrites[6];
            }
        }
    }
}
