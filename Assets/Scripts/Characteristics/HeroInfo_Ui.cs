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
    [SerializeField] private List<Text> gold_to_grade;
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

    [SerializeField] private GameObject free_button;
    [SerializeField] private GameObject busy_button;
    [SerializeField] private Text timeToEndRaid;
    [SerializeField] private List<Cube_ui> dices;
    [SerializeField] private List<GameObject> NeutralSpriteList;
    [SerializeField] private List<GameObject> UndeadSpriteList;
    [SerializeField] private List<GameObject> OrderSpriteList;
    [SerializeField] private List<GameObject> DemonSpriteList;
    [SerializeField] private Text DicesCount;
    [SerializeField] private GameObject canGrade;
    [SerializeField] private GameObject cannotGrade;
    private Hero m_currentHero;
    public bool raid_is_active = false;

    public void InitialiseHero(Hero hero)
    {

        CloseZoneBonus();
        ShowHeroSprite(hero);

        m_currentHero = hero;
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
        DicesCount.text = "D " + hero.cube.edgesNumber;
        hero_name.text = hero.HeroName;
        hero_lvl.text = hero.Level.ToString();
        hero_rank.text = hero.Rank.ToString();
        average_Profit.text = ConvertText.FormatNumb(hero.GetGoldProfit());
        multiplier.text = "x" + hero.Multiplier.ToString();
        comfo_factor.text = hero.GetCombo().ToString();
        hero_luck.text = "%" + hero.GetLuckProfit().ToString();
        hero_unluck.text = "%" + hero.GetUnLuckProfit().ToString();
        foreach (var item in gold_to_grade)
        {
            item.text = ConvertText.FormatNumb(hero.GoldToGrade);
        }
        if (hero.currentRaidSlot != 0)
        {
            if(raid_is_active)
            {
                free_button.SetActive(false);
                busy_button.SetActive(true);
            }
            else
            {
                free_button.SetActive(true);
                busy_button.SetActive(false);
            }
        }
           
        else
        {
            busy_button.SetActive(false);
            free_button.SetActive(false);
        }
        foreach (var item in dices)
        {
            item.gameObject.SetActive(false);
        }
        hero.DisplayCubeInfo();
        for (int i = 0; i < hero.cube.edgesNumber; i++)
        {
            dices[i].gameObject.SetActive(true);
            if (hero.cube.edges[i].edgeType == EdgeScript.EdgeType.Neutral)
                dices[i].MakeGrey();
            else if (hero.cube.edges[i].edgeType == EdgeScript.EdgeType.Luck)
                dices[i].MakeGreen();
            else if (hero.cube.edges[i].edgeType == EdgeScript.EdgeType.Unluck)
                dices[i].MakeRed();
        }
        if (Gold.GetCurrentGold() >= hero.GoldToGrade)
        {
            canGrade.SetActive(true);
            cannotGrade.SetActive(false);
        }
        else
        {
            canGrade.SetActive(false);
            cannotGrade.SetActive(true);
        }
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
    public void ShowHeroSprite(Hero hero)
    {
        foreach (var item in NeutralSpriteList)
        {
            item.SetActive(false);
        }
        foreach (var item in UndeadSpriteList)
        {
            item.SetActive(false);
        }
        foreach (var item in OrderSpriteList)
        {
            item.SetActive(false);
        }
        foreach (var item in DemonSpriteList)
        {
            item.SetActive(false);
        }
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                if (hero.Id == 1)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[0].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[1].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[2].SetActive(true);
                }
                if (hero.Id == 2)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[3].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[4].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[5].SetActive(true);
                }
                if (hero.Id == 3)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[6].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[7].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[8].SetActive(true);
                }
                if (hero.Id == 4)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[9].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[10].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[11].SetActive(true);
                }
                if (hero.Id == 5)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[12].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[13].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[14].SetActive(true);
                }
                if (hero.Id == 6)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[15].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[16].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[17].SetActive(true);
                }
                if (hero.Id == 7)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[18].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[19].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[20].SetActive(true);
                }
                if (hero.Id == 8)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[21].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[22].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[23].SetActive(true);
                }
                if (hero.Id == 9)
                {
                    if (hero.Rank == 1)
                        NeutralSpriteList[24].SetActive(true);
                    else if (hero.Rank == 2)
                        NeutralSpriteList[25].SetActive(true);
                    else if (hero.Rank == 3)
                        NeutralSpriteList[26].SetActive(true);
                }
                break;
            case TypeElement.Undead:
                if (hero.Id == 10)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[0].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[1].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[2].SetActive(true);
                }
                if (hero.Id == 11)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[3].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[4].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[5].SetActive(true);
                }
                if (hero.Id == 12)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[6].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[7].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[8].SetActive(true);
                }
                if (hero.Id == 13)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[9].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[10].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[11].SetActive(true);
                }
                if (hero.Id == 14)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[12].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[13].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[14].SetActive(true);
                }
                if (hero.Id == 15)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[15].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[16].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[17].SetActive(true);
                }
                if (hero.Id == 16)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[18].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[19].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[20].SetActive(true);
                }
                if (hero.Id == 17)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[21].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[22].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[23].SetActive(true);
                }
                if (hero.Id == 18)
                {
                    if (hero.Rank == 1)
                        UndeadSpriteList[24].SetActive(true);
                    else if (hero.Rank == 2)
                        UndeadSpriteList[25].SetActive(true);
                    else if (hero.Rank == 3)
                        UndeadSpriteList[26].SetActive(true);
                }

                break;
            case TypeElement.Order:
                if (hero.Id == 19)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[0].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[1].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[2].SetActive(true);
                }
                if (hero.Id == 20)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[3].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[4].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[5].SetActive(true);
                }
                if (hero.Id == 21)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[6].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[7].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[8].SetActive(true);
                }
                if (hero.Id == 22)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[9].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[10].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[11].SetActive(true);
                }
                if (hero.Id == 23)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[12].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[13].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[14].SetActive(true);
                }
                if (hero.Id == 24)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[15].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[16].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[17].SetActive(true);
                }
                if (hero.Id == 25)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[18].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[19].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[20].SetActive(true);
                }
                if (hero.Id == 26)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[21].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[22].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[23].SetActive(true);
                }
                if (hero.Id == 27)
                {
                    if (hero.Rank == 1)
                        OrderSpriteList[24].SetActive(true);
                    else if (hero.Rank == 2)
                        OrderSpriteList[25].SetActive(true);
                    else if (hero.Rank == 3)
                        OrderSpriteList[26].SetActive(true);
                }
                break;
            case TypeElement.Demon:
                if (hero.Id == 28)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[0].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[1].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[2].SetActive(true);
                }
                if (hero.Id == 29)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[3].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[4].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[5].SetActive(true);
                }
                if (hero.Id == 30)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[6].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[7].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[8].SetActive(true);
                }
                if (hero.Id == 31)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[9].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[10].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[11].SetActive(true);
                }
                if (hero.Id == 32)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[12].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[13].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[14].SetActive(true);
                }
                if (hero.Id == 33)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[15].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[16].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[17].SetActive(true);
                }
                if (hero.Id == 34)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[18].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[19].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[20].SetActive(true);
                }
                if (hero.Id == 35)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[21].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[22].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[23].SetActive(true);
                }
                if (hero.Id == 36)
                {
                    if (hero.Rank == 1)
                        DemonSpriteList[24].SetActive(true);
                    else if (hero.Rank == 2)
                        DemonSpriteList[25].SetActive(true);
                    else if (hero.Rank == 3)
                        DemonSpriteList[26].SetActive(true);
                }
                break;

        }
    }

    public void CheckActiveRaid(bool raidIsActive)
    {
        if (m_currentHero != null)
        {
            if (m_currentHero.currentRaidSlot != 0)
            {
                if(raidIsActive)
                {
                    busy_button.SetActive(true);
                    free_button.SetActive(false);
                }
                else
                {
                    busy_button.SetActive(false);
                    free_button.SetActive(true);
                }
            }
            else
            {
                busy_button.SetActive(false);
                free_button.SetActive(false);
            }
        }
    }
    public void CheckRaidTime(float time) => timeToEndRaid.text = ((int)time).ToString();

}
