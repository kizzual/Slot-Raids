using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterCharacteristics : MonoBehaviour
{
    public Image heroImg;
    private ScrollingObjects currentSlot;
    private Hero currentHero;

    [SerializeField] private Text currentLevel;
    [SerializeField] private Text currentRank;
    [SerializeField] private Text gold_profit;
    [SerializeField] private Text luck_profit;
    [SerializeField] private Text defence_profit;
    [SerializeField] private Text combo_profit;
    [SerializeField] private Text goldToGrade;

    [SerializeField] private Text sword_profit;
    [SerializeField] private Text shield_profit;
    [SerializeField] private Text amulet_profit;

    [SerializeField] private List<Image> elementImage;

    [SerializeField] private Image swordImage;
    [SerializeField] private Image shieldImage;
    [SerializeField] private Image amuletImage;


    [SerializeField] private Sprite neutralElement_Image;
    [SerializeField] private Sprite undeadElement_Image;
    [SerializeField] private Sprite orderElement_Image;
    [SerializeField] private Sprite demonElement_Image;
    [SerializeField] private GameObject front_panel;
    [SerializeField] private AddingItems addingItem;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void GradeLevel()
    {
        if(Gold.GetCurrentGold() >= currentHero.goldToGrade)
        {
            currentHero.LelelUp();
            Gold.SpendGold(currentHero.goldToGrade);
            ShowCharacteristics(currentHero);
        }
      
        //Изменить изменения героя
    }
    public void ClosePanel()
    {
        front_panel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void AddSword()
    {
        addingItem.OpenSwordItem(currentHero,gameObject);
    }
    public void AddShield()
    {
        addingItem.OpenShieldItem(currentHero, gameObject);
    }
    public void AddAmulet()
    {
        addingItem.OpenAmulettem(currentHero, gameObject);
    }
    public void ShowCharacteristics(Hero hero)
    {
        currentHero = hero;
        front_panel.SetActive(true);
        gameObject.SetActive(true);
        if (hero.rank == 1)
        {
            heroImg.sprite = hero.imageRank_1;
        }
        else if (hero.rank == 2)
        {
            heroImg.sprite = hero.imageRank_2;
        }
        else
        {
            heroImg.sprite = hero.imageRank_3;
        }
        currentLevel.text = hero.Level.ToString();
        currentRank.text = hero.rank.ToString();
        gold_profit.text = hero.ProfitPercent.ToString();
        luck_profit.text = hero.LuckPercent.ToString();
        defence_profit.text = hero.ProtectPercent.ToString();
        combo_profit.text = hero.ComboPercent.ToString();
        goldToGrade.text = hero.goldToGrade.ToString();
        if(hero.Sword != null)
        {
            swordImage.enabled = true;
            swordImage.sprite = hero.Sword.sprite;
            sword_profit.text = hero.ItemProfit.ToString();
        }
        else
        {
        //    swordImage.enabled = false;
            sword_profit.text = "0";
        }
        if (hero.Shield != null)
        {
            shieldImage.enabled = true;
            shieldImage.sprite = hero.Shield.sprite;
            shield_profit.text = hero.ItemProtect.ToString();
        }
        else
        {
         //   shieldImage.enabled = false;
            shield_profit.text = "0";
        }
        if (hero.Amulet != null)
        {
            amuletImage.enabled = true;
            amuletImage.sprite = hero.Amulet.sprite;
            amulet_profit.text = hero.iemLuck.ToString();
        }
        else
        {
          //  amuletImage.enabled = false;
            amulet_profit.text = "0";
        }
        foreach (var item in elementImage)
        {
            if(hero.elementType == Hero.ElementType.Neutral)
            {
                item.sprite = neutralElement_Image;
            }
            else if (hero.elementType == Hero.ElementType.Undead)
            {
                item.sprite = undeadElement_Image;
            }
            else if (hero.elementType == Hero.ElementType.Order)
            {
                item.sprite = orderElement_Image;
            }
            else if (hero.elementType == Hero.ElementType.Demon)
            {
                item.sprite = demonElement_Image;
            }
        }

    }
    public void AddHeroToSlot()
    {
        if (currentSlot != null)
        {
            currentSlot.currentHero = currentHero;
            currentSlot.isActive = true;
            gameObject.SetActive(false);
        }
    }
}
