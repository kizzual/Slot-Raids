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
    [SerializeField] private ScrollingController scrollController;

    [SerializeField] private List<GameObject> neutral_main_image;
    [SerializeField] private List<GameObject> undead_main_image;
    [SerializeField] private List<GameObject> order_main_image;
    [SerializeField] private List<GameObject> demon_main_image;

    [SerializeField] private List<HeroPanel> heroPnels;
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
            foreach (var item in heroPnels)
            {
                foreach (var tmp in item.heroSlots)
                {
                    tmp.DisplayHEroInfo();
                }
            }
            scrollController.DisplayInfo();
        }
      
        //Изменить изменения героя
    }
    public void ClosePanel()
    {
        front_panel.SetActive(false);
        gameObject.SetActive(false);
     //   scrollController.FormingSlots();

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
    public void DisplayInfo()
    {
        if (currentHero != null)
        {
            front_panel.SetActive(true);
            gameObject.SetActive(true);
            if (currentHero.rank == 1)
            {
                heroImg.sprite = currentHero.imageRank_1;
            }
            else if (currentHero.rank == 2)
            {
                heroImg.sprite = currentHero.imageRank_2;
            }
            else
            {
                heroImg.sprite = currentHero.imageRank_3;
            }
            currentLevel.text = currentHero.Level.ToString();
            currentRank.text = currentHero.rank.ToString();
            gold_profit.text = ConvertText.FormatNumb(currentHero.ProfitPercent) ;
            luck_profit.text = currentHero.LuckPercent.ToString() + "%";
            defence_profit.text = currentHero.ProtectPercent.ToString() + "%";
            combo_profit.text = "X" + currentHero.ComboPercent.ToString();
            goldToGrade.text = ConvertText.FormatNumb(currentHero.goldToGrade);
            Debug.Log("luck =   " + currentHero.LuckPercent);
            Debug.Log("profit =   " + currentHero.ProfitPercent);
            Debug.Log("defence =   " + currentHero.ProtectPercent);
            if (currentHero.Sword != null)
            {
                swordImage.enabled = true;
                swordImage.sprite = currentHero.Sword.sprite;
                sword_profit.text = "PROFIT +" + currentHero.ItemProfit.ToString() + "%";
            }
            else
            {
                swordImage.enabled = false;

                sword_profit.text = "PROFIT +0%";
            }
            if (currentHero.Shield != null)
            {
                shieldImage.enabled = true;
                shieldImage.sprite = currentHero.Shield.sprite;

                shield_profit.text = "PROFIT +" + currentHero.ItemProtect.ToString() + "%";
            }
            else
            {
                shieldImage.enabled = false;
                shield_profit.text = "PROFIT +0%";
            }
            if (currentHero.Amulet != null)
            {
                amuletImage.enabled = true;
                amuletImage.sprite = currentHero.Amulet.sprite;

                amulet_profit.text = "PROFIT +" + currentHero.iemLuck.ToString() + "%";
            }
            else
            {
                amuletImage.enabled = false;
                amulet_profit.text = "PROFIT +0%";
            }
            foreach (var item in elementImage)
            {
                if (currentHero.elementType == Hero.ElementType.Neutral)
                {
                    item.sprite = neutralElement_Image;
                }
                else if (currentHero.elementType == Hero.ElementType.Undead)
                {
                    item.sprite = undeadElement_Image;
                }
                else if (currentHero.elementType == Hero.ElementType.Order)
                {
                    item.sprite = orderElement_Image;
                }
                else if (currentHero.elementType == Hero.ElementType.Demon)
                {
                    item.sprite = demonElement_Image;
                }
            }
        }
        DisplayMainImage();
        foreach (var item in heroPnels)
        {
            foreach (var tmp in item.heroSlots)
            {
                tmp.DisplayHEroInfo();
            }
        }
        scrollController.DisplayInfo();


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
        gold_profit.text = ConvertText.FormatNumb(hero.ProfitPercent) ;
        luck_profit.text = hero.LuckPercent.ToString() + "%";
        defence_profit.text = hero.ProtectPercent.ToString() + "%";
        combo_profit.text = "X" + hero.ComboPercent.ToString();
        goldToGrade.text = ConvertText.FormatNumb(hero.goldToGrade);
        if(hero.Sword != null)
        {
            swordImage.enabled = true;
            swordImage.sprite = hero.Sword.sprite;
            sword_profit.text = "PROFIT +" + hero.ItemProfit.ToString() + "%";
        }
        else
        {
                swordImage.enabled = false;
            
            sword_profit.text = "PROFIT +0%";
        }
        if (hero.Shield != null)
        {
            shieldImage.enabled = true;
            shieldImage.sprite = hero.Shield.sprite;
           
            shield_profit.text = "PROFIT +" + hero.ItemProtect.ToString() + "%";
        }
        else
        {
           shieldImage.enabled = false;
            shield_profit.text = "PROFIT +0%";
        }
        if (hero.Amulet != null)
        {
            amuletImage.enabled = true;
            amuletImage.sprite = hero.Amulet.sprite;
       
            amulet_profit.text = "PROFIT +" + hero.iemLuck.ToString() + "%";
        }
        else
        {
            amuletImage.enabled = false;
            amulet_profit.text = "PROFIT +0%";
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
        DisplayMainImage();
    }
    public void AddHeroToSlot()
    {
        Debug.Log("SADSADSADSAD");
        if (currentSlot != null)
        {
            currentSlot.currentHero = currentHero;
            currentSlot.isActive = true;
            gameObject.SetActive(false);
        }
    }
    private void DisplayMainImage()
    {
        foreach (var item in neutral_main_image)
        {
            item.SetActive(false);
        }
        foreach (var item in undead_main_image)
        {
            item.SetActive(false);
        }
        foreach (var item in order_main_image)
        {
            item.SetActive(false);
        }
        foreach (var item in demon_main_image)
        {
            item.SetActive(false);
        }
        if(currentHero.elementType == Hero.ElementType.Neutral)
        {
            if(currentHero.rank == 1)
            {
                if(currentHero.ID == 1)
                {
                    neutral_main_image[0] .SetActive(true);
                }
                else if(currentHero.ID == 2)
                {
                    neutral_main_image[3].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    neutral_main_image[6].SetActive(true);
                } 
                else if (currentHero.ID == 4)
                {
                    neutral_main_image[9].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    neutral_main_image[12].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    neutral_main_image[15].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    neutral_main_image[18].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    neutral_main_image[21].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    neutral_main_image[24].SetActive(true);
                }
            }
            else if(currentHero.rank == 2)
            {
                if (currentHero.ID == 1)
                {
                    neutral_main_image[1].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    neutral_main_image[4].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    neutral_main_image[7].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    neutral_main_image[10].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    neutral_main_image[13].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    neutral_main_image[16].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    neutral_main_image[19].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    neutral_main_image[22].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    neutral_main_image[25].SetActive(true);
                }

            }
            else if (currentHero.rank == 3)
            {
                if (currentHero.ID == 1)
                {
                    neutral_main_image[2].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    neutral_main_image[5].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    neutral_main_image[8].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    neutral_main_image[11].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    neutral_main_image[14].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    neutral_main_image[17].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    neutral_main_image[20].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    neutral_main_image[23].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    neutral_main_image[26].SetActive(true);
                }

            }
        }
        if (currentHero.elementType == Hero.ElementType.Undead)
        {
            if (currentHero.rank == 1)
            {
                if (currentHero.ID == 1)
                {
                    undead_main_image[0].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    undead_main_image[3].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    undead_main_image[6].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    undead_main_image[9].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    undead_main_image[12].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    undead_main_image[15].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    undead_main_image[18].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    undead_main_image[21].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    undead_main_image[24].SetActive(true);
                }
            }
            else if (currentHero.rank == 2)
            {
                if (currentHero.ID == 1)
                {
                    undead_main_image[1].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    undead_main_image[4].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    undead_main_image[7].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    undead_main_image[10].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    undead_main_image[13].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    undead_main_image[16].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    undead_main_image[19].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    undead_main_image[22].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    undead_main_image[25].SetActive(true);
                }

            }
            else if (currentHero.rank == 3)
            {
                if (currentHero.ID == 1)
                {
                    undead_main_image[2].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    undead_main_image[5].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    undead_main_image[8].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    undead_main_image[11].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    undead_main_image[14].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    undead_main_image[17].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    undead_main_image[20].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    undead_main_image[23].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    undead_main_image[26].SetActive(true);
                }

            }
        }
        if (currentHero.elementType == Hero.ElementType.Order)
        {
            if (currentHero.rank == 1)
            {
                if (currentHero.ID == 1)
                {
                    order_main_image[0].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    order_main_image[3].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    order_main_image[6].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    order_main_image[9].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    order_main_image[12].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    order_main_image[15].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    order_main_image[18].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    order_main_image[21].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    order_main_image[24].SetActive(true);
                }
            }
            else if (currentHero.rank == 2)
            {
                if (currentHero.ID == 1)
                {
                    order_main_image[1].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    order_main_image[4].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    order_main_image[7].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    order_main_image[10].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    order_main_image[13].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    order_main_image[16].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    order_main_image[19].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    order_main_image[22].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    order_main_image[25].SetActive(true);
                }

            }
            else if (currentHero.rank == 3)
            {
                if (currentHero.ID == 1)
                {
                    order_main_image[2].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    order_main_image[5].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    order_main_image[8].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    order_main_image[11].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    order_main_image[14].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    order_main_image[17].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    order_main_image[20].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    order_main_image[23].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    order_main_image[26].SetActive(true);
                }

            }
        }
        if (currentHero.elementType == Hero.ElementType.Demon)
        {
            if (currentHero.rank == 1)
            {
                if (currentHero.ID == 1)
                {
                    demon_main_image[0].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    demon_main_image[3].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    demon_main_image[6].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    demon_main_image[9].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    demon_main_image[12].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    demon_main_image[15].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    demon_main_image[18].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    demon_main_image[21].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    demon_main_image[24].SetActive(true);
                }
            }
            else if (currentHero.rank == 2)
            {
                if (currentHero.ID == 1)
                {
                    demon_main_image[1].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    demon_main_image[4].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    demon_main_image[7].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    demon_main_image[10].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    demon_main_image[13].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    demon_main_image[16].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    demon_main_image[19].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    demon_main_image[22].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    demon_main_image[25].SetActive(true);
                }

            }
            else if (currentHero.rank == 3)
            {
                if (currentHero.ID == 1)
                {
                    demon_main_image[2].SetActive(true);
                }
                else if (currentHero.ID == 2)
                {
                    demon_main_image[5].SetActive(true);
                }
                else if (currentHero.ID == 3)
                {
                    demon_main_image[8].SetActive(true);
                }
                else if (currentHero.ID == 4)
                {
                    demon_main_image[11].SetActive(true);
                }
                else if (currentHero.ID == 5)
                {
                    demon_main_image[14].SetActive(true);
                }
                else if (currentHero.ID == 6)
                {
                    demon_main_image[17].SetActive(true);
                }
                else if (currentHero.ID == 7)
                {
                    demon_main_image[20].SetActive(true);
                }
                else if (currentHero.ID == 8)
                {
                    demon_main_image[23].SetActive(true);
                }
                else if (currentHero.ID == 9)
                {
                    demon_main_image[26].SetActive(true);
                }

            }
        }


    }
}
