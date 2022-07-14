using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfo_Ui : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite neutral_logo;
    [SerializeField] private Sprite undead_logo;
    [SerializeField] private Sprite order_logo;
    [SerializeField] private Sprite demon_logo;


    [SerializeField] private Image Element_image;
    [SerializeField] private Text hero_name;
    [SerializeField] private Text hero_lvl;
    [SerializeField] private Text hero_rank;
    [SerializeField] private Text average_Profit;
    [SerializeField] private Text multiplier;
    [SerializeField] private Text comfo_factor;
    [SerializeField] private Text hero_luck;
    [SerializeField] private Text hero_unluck;
    [SerializeField] private Text gold_to_grade;
    //cube
    [SerializeField] private Text item_sword_profit;
    [SerializeField] private Text item_shield_protect;
    [SerializeField] private Text item_amulet_luck;

    [SerializeField] private Image sword_image;
    [SerializeField] private Image shield_image;
    [SerializeField] private Image amulet_image;


    [SerializeField] private GameObject zone_bonus_neutral;
    [SerializeField] private GameObject zone_bonus_undead;
    [SerializeField] private GameObject zone_bonus_order;
    [SerializeField] private GameObject zone_bonus_demon;

    [SerializeField] private GameObject hero_bonus_gold;
    [SerializeField] private GameObject hero_bonus_luck;
    [SerializeField] private GameObject hero_bonus_protect;
    [SerializeField] private GameObject hero_bonus_combo;

    public void InitialiseHero(Hero hero)
    {

        CloseZoneBonus();
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                Element_image.sprite = neutral_logo;
                zone_bonus_neutral.SetActive(true);
                switch (hero.typeBonus)
                {
                    case TypeBonus.GoldProfit_Percent:
                        hero_bonus_gold.SetActive(true);
                        break;
                    case TypeBonus.Luck_percent:
                        hero_bonus_luck.SetActive(true);
                        break;
                    case TypeBonus.Protect_percent:
                        hero_bonus_protect.SetActive(true);
                        break;
                    case TypeBonus.Combo_percent:
                        hero_bonus_combo.SetActive(true);
                        break;
                }
                break;
            case TypeElement.Undead:
                Element_image.sprite = undead_logo;
                zone_bonus_undead.SetActive(true);
                switch (hero.typeBonus)
                {
                    case TypeBonus.GoldProfit_Percent:
                        hero_bonus_gold.SetActive(true);
                        break;
                    case TypeBonus.Luck_percent:
                        hero_bonus_luck.SetActive(true);
                        break;
                    case TypeBonus.Protect_percent:
                        hero_bonus_protect.SetActive(true);
                        break;
                    case TypeBonus.Combo_percent:
                        hero_bonus_combo.SetActive(true);
                        break;
                }
                break;
            case TypeElement.Order:
                Element_image.sprite = order_logo;
                zone_bonus_order.SetActive(true);
                switch (hero.typeBonus)
                {
                    case TypeBonus.GoldProfit_Percent:
                        hero_bonus_gold.SetActive(true);
                        break;
                    case TypeBonus.Luck_percent:
                        hero_bonus_luck.SetActive(true);
                        break;
                    case TypeBonus.Protect_percent:
                        hero_bonus_protect.SetActive(true);
                        break;
                    case TypeBonus.Combo_percent:
                        hero_bonus_combo.SetActive(true);
                        break;
                }

                break;
            case TypeElement.Demon:
                Element_image.sprite = demon_logo;
                zone_bonus_demon.SetActive(true);
                switch (hero.typeBonus)
                {
                    case TypeBonus.GoldProfit_Percent:
                        hero_bonus_gold.SetActive(true);
                        break;
                    case TypeBonus.Luck_percent:
                        hero_bonus_luck.SetActive(true);
                        break;
                    case TypeBonus.Protect_percent:
                        hero_bonus_protect.SetActive(true);
                        break;
                    case TypeBonus.Combo_percent:
                        hero_bonus_combo.SetActive(true);
                        break;
                }
                break;

        }
        if(hero.GetItem_Sword() != null)
        {
            sword_image.gameObject.SetActive(true);
            sword_image.sprite = hero.GetItem_Sword().GetComponent<Image>().sprite;
            item_sword_profit.text = hero.GetItem_Sword().Gold_profit.ToString() + "%";
        }
        else
        {
            sword_image.gameObject.SetActive(false);
            item_sword_profit.text = "0%";
        }
        if (hero.GetItem_Shield() != null)
        {
            shield_image.gameObject.SetActive(true);
            shield_image.sprite = hero.GetItem_Shield().GetComponent<Image>().sprite;
            item_shield_protect.text = hero.GetItem_Shield().Protect_profit.ToString() + "%";
        }
        else
        {
            shield_image.gameObject.SetActive(false);
            item_shield_protect.text = "0%";
        }
        if (hero.GetItem_Amulet() != null)
        {
            amulet_image.gameObject.SetActive(true);
            amulet_image.sprite = hero.GetItem_Amulet().GetComponent<Image>().sprite;
            item_amulet_luck.text = hero.GetItem_Amulet().Luck_profit.ToString() + "%";
        }
        else
        {
            amulet_image.gameObject.SetActive(false);
            item_amulet_luck.text = "0%";
        }
        hero_lvl.text = hero.Level.ToString();
        hero_rank.text = hero.Rank.ToString();
        average_Profit.text = hero.GetGoldProfit().ToString();
        multiplier.text = "x" + hero.Multiplier.ToString();
        comfo_factor.text = hero.GetCombo().ToString();
        hero_luck.text = "%" + hero.GetLuckProfit().ToString();
        hero_unluck.text = "%" + hero.GetUnLuckProfit().ToString();
        gold_to_grade.text = hero.GoldToGrade.ToString();
    }
    private void CloseZoneBonus()
    {
        zone_bonus_neutral.SetActive(false);
        zone_bonus_undead.SetActive(false);
        zone_bonus_order.SetActive(false);
        zone_bonus_demon.SetActive(false);

        hero_bonus_gold.SetActive(false);
        hero_bonus_luck.SetActive(false);
        hero_bonus_protect.SetActive(false);
        hero_bonus_combo.SetActive(false);
    }

}
