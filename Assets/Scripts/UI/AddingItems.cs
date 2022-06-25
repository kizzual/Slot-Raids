using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingItems : MonoBehaviour
{
    [SerializeField] private Sprite neutral_image;
    [SerializeField] private Sprite undead_image;
    [SerializeField] private Sprite order_image;
    [SerializeField] private Sprite demon_image;

    [SerializeField] private Image elementImage;
    [SerializeField] private Image Items_1_image;
    [SerializeField] private Image Items_2_image;
    [SerializeField] private Image Items_3_image;

    [SerializeField] private Text itemName;
    [SerializeField] private Text item_1_count;
    [SerializeField] private Text item_2_count;
    [SerializeField] private Text item_3_count;

    [SerializeField] Inventory neutralInventory;
    [SerializeField] Inventory undeadInventory;
    [SerializeField] Inventory orderInventory;
    [SerializeField] Inventory demonInventory;

    [SerializeField] private GameObject panel_rank1;
    [SerializeField] private GameObject panel_rank2;
    [SerializeField] private GameObject panel_rank3;

    [SerializeField] private GameObject checkCurrent_1;
    [SerializeField] private GameObject checkCurrent_2;
    [SerializeField] private GameObject checkCurrent_3;

    [SerializeField] private NeutralItemsSO _neutralItems_so;
    [SerializeField] private UndeadItemsSO _undeadItems_so;
    [SerializeField] private OrderItemsSO _orderItems_so;
    [SerializeField] private DemonItemsSO _demonItems_so;

    [SerializeField] private GameObject frontPanel;
    private Hero currentHero;
    private Inventory currentInventory;
    private GameObject characterCharacteristics_panel;
    enum CurrentItem
    {
        Sword,
        Shield,
        Amulet
    }
    CurrentItem currentItem;
    public void OpenSwordItem(Hero hero, GameObject panel)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        panel.SetActive(false);

        currentHero = hero;
        currentItem = CurrentItem.Sword;
        characterCharacteristics_panel = panel;
        switch (hero.elementType)
        {
            case Hero.ElementType.Neutral:
                elementImage.sprite = neutral_image;
                currentInventory = neutralInventory;
                break;
            case Hero.ElementType.Undead:
                elementImage.sprite = undead_image;
                currentInventory = undeadInventory;
                break;
            case Hero.ElementType.Order:
                elementImage.sprite = order_image; 
                currentInventory = orderInventory;
                break;
            case Hero.ElementType.Demon:
                elementImage.sprite = demon_image;
                currentInventory = demonInventory;
                break;
            default:
                break;
        }

        Debug.Log("current element = " + hero.elementType);
        Debug.Log("current rank = " + hero.rank);
        Debug.Log("swords_1 count  = " + currentInventory._swords_1_count);
        Debug.Log("swords_2 count  = " + currentInventory._swords_2_count);
        Debug.Log("swords_3 count  = " + currentInventory._swords_3_count);
        itemName.text = "SWORD";
        if(currentInventory._swords_1_count > 0)
        {
            Debug.Log("Enter_sword 1");
            panel_rank1.SetActive(true);
            Items_1_image.sprite = _neutralItems_so.sword_1.sprite;
            item_1_count.text = currentInventory._swords_1_count.ToString();
        }
        else
        {
            Debug.Log("Exit_sword1");

            panel_rank1.SetActive(false);
        }
        if (currentInventory._swords_2_count > 0 && hero.rank == 2)
        {
            Debug.Log("Enter_sword 2");
            panel_rank2.SetActive(true);
            Items_2_image.sprite = _neutralItems_so.sword_2.sprite;
            item_2_count.text = currentInventory._swords_2_count.ToString();
        }
        else
        {
            Debug.Log("EXXIT 2");
            panel_rank2.SetActive(false);
        }
        if (currentInventory._swords_3_count > 0 && hero.rank == 3 )
        {
            Debug.Log("Enter_sword 3");
            panel_rank3.SetActive(true);
            Items_3_image.sprite = _neutralItems_so.sword_3.sprite;
            item_3_count.text = currentInventory._swords_3_count.ToString();
        }
        else
        {
            Debug.Log("EXXIT 3");
            panel_rank3.SetActive(false);
        }
        
        CheckButtonSword(hero.Sword);
    }
    public void OpenShieldItem(Hero hero, GameObject panel)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentHero = hero;
        currentItem = CurrentItem.Shield;
        characterCharacteristics_panel = panel;
        panel.SetActive(false);

        switch (hero.elementType)
        {
            case Hero.ElementType.Neutral:
                elementImage.sprite = neutral_image;
                currentInventory = neutralInventory;
                break;
            case Hero.ElementType.Undead:
                elementImage.sprite = undead_image;
                currentInventory = undeadInventory;
                break;
            case Hero.ElementType.Order:
                elementImage.sprite = order_image;
                currentInventory = orderInventory;
                break;
            case Hero.ElementType.Demon:
                elementImage.sprite = demon_image;
                currentInventory = demonInventory;
                break;
            default:
                break;
        }

        Debug.Log("Shield 1 count  = " + currentInventory._shield_1_count);
        Debug.Log("shield 2 count  = " + currentInventory._shield_2_count);
        Debug.Log("shield 3 count  = " + currentInventory._shield_3_count);

        itemName.text = "SHIELD";
        if (currentInventory._shield_1_count > 0)
        {
            panel_rank1.SetActive(true);
            Items_1_image.sprite = _neutralItems_so.shield_1.sprite;
            item_1_count.text = currentInventory._shield_1_count.ToString();
        }
        else
        {
            panel_rank1.SetActive(false);
        }
        if (currentInventory._shield_2_count > 0 && hero.rank == 2)
        {
            panel_rank2.SetActive(true);
            Items_2_image.sprite = _neutralItems_so.shield_2.sprite;
            item_2_count.text = currentInventory._shield_2_count.ToString();
        }
        else
        {
            panel_rank2.SetActive(false);
        }
        if (currentInventory._shield_3_count > 0 && hero.rank == 3)
        {
            panel_rank3.SetActive(true);
            Items_3_image.sprite = _neutralItems_so.shield_3.sprite;
            item_3_count.text = currentInventory._shield_3_count.ToString();
        }
        else
        {
            panel_rank3.SetActive(false);
        }
        CheckButtonShield(hero.Shield);
    }

    public void OpenAmulettem(Hero hero, GameObject panel)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        currentHero = hero;
        currentItem = CurrentItem.Amulet;
        characterCharacteristics_panel = panel;
        panel.SetActive(false);

        switch (hero.elementType)
        {
            case Hero.ElementType.Neutral:
                elementImage.sprite = neutral_image;
                currentInventory = neutralInventory;
                break;
            case Hero.ElementType.Undead:
                elementImage.sprite = undead_image;
                currentInventory = undeadInventory;
                break;
            case Hero.ElementType.Order:
                elementImage.sprite = order_image;
                currentInventory = orderInventory;
                break;
            case Hero.ElementType.Demon:
                elementImage.sprite = demon_image;
                currentInventory = demonInventory;
                break;
            default:
                break;
        }
        itemName.text = "AMULET";
        if (currentInventory._amulet_1_count > 0)
        {
            panel_rank1.SetActive(true);
            Items_1_image.sprite = _neutralItems_so.Amulet_1.sprite;
            item_1_count.text = currentInventory._amulet_1_count.ToString();
        }
        else
        {
            panel_rank1.SetActive(false);
        }
        if (currentInventory._amulet_2_count > 0 && hero.rank == 2)
        {
            panel_rank2.SetActive(true);
            Items_2_image.sprite = _neutralItems_so.Amulet_2.sprite;
            item_2_count.text = currentInventory._amulet_2_count.ToString();
        }
        else
        {
            panel_rank2.SetActive(false);
        }
        if (currentInventory._amulet_3_count > 0 && hero.rank == 3)
        {
            panel_rank3.SetActive(true);
            Items_3_image.sprite = _neutralItems_so.Amulet_3.sprite;
            item_3_count.text = currentInventory._amulet_3_count.ToString();
        }
        else
        {
            panel_rank3.SetActive(false);
        }
        CheckButtonAmulet(hero.Shield);
    }
    private void CheckButtonSword(Prize prize)
    {
        if (prize != null)
        {
            if (prize._Type == Type.item_sword_1)
            {
                checkCurrent_1.SetActive(true);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(false);
            }
            else if(prize._Type == Type.item_sword_2)
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(true);
                checkCurrent_3.SetActive(false);
            }
            else
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(true);
            }
        }
    }
    private void CheckButtonShield(Prize prize)
    {
        if (prize != null)
        {
            if (prize._Type == Type.item_shield_1)
            {
                checkCurrent_1.SetActive(true);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(false);
            }
            else if (prize._Type == Type.item_shield_2)
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(true);
                checkCurrent_3.SetActive(false);
            }
            else
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(true);
            }
        }
    }

    private void CheckButtonAmulet(Prize prize)
    {
        if (prize != null)
        {
            if (prize._Type == Type.item_amulet_1)
            {
                checkCurrent_1.SetActive(true);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(false);
            }
            else if (prize._Type == Type.item_amulet_2)
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(true);
                checkCurrent_3.SetActive(false);
            }
            else
            {
                checkCurrent_1.SetActive(false);
                checkCurrent_2.SetActive(false);
                checkCurrent_3.SetActive(true);
            }
        }
    }


    public void ChooseItem(int index)
    {
        if(index == 1)
        {
            checkCurrent_1.SetActive(true);
            checkCurrent_2.SetActive(false);
            checkCurrent_3.SetActive(false);
            if(currentItem == CurrentItem.Sword)
            {
                if(currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_1);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_1);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_1);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_1);
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_1);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_1);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_1);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_1);
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_1);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_1);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.Amulet_1);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.Amulet_1);
                }
            }

        }
        else if (index == 2)
        {
            checkCurrent_1.SetActive(false);
            checkCurrent_2.SetActive(true);
            checkCurrent_3.SetActive(false);
            if (currentItem == CurrentItem.Sword)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_2);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_2);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_2);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_2);
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_2);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_2);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_2);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_2);
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_2);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_2);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.Amulet_2);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.Amulet_2);
                }
            }
        }
        else if (index == 3)
        {
            checkCurrent_1.SetActive(false);
            checkCurrent_2.SetActive(false);
            checkCurrent_3.SetActive(true);
            if (currentItem == CurrentItem.Sword)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_3);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_3);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_3);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_3);
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_3);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_3);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_3);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_3);
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_3);
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_3);
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.Amulet_3);
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.Amulet_3);
                }

            }
        }
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        characterCharacteristics_panel.SetActive(true);
    }
}
