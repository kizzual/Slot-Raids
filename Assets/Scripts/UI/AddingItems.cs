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

    [SerializeField] private Image sword_image;
    [SerializeField] private Image shield_image;
    [SerializeField] private Image amulet_image;

    [SerializeField] private GameObject frontPanel;
    private Hero currentHero;
    private Inventory currentInventory;
    private GameObject characterCharacteristics_panel;
    [SerializeField] private CharacterCharacteristics Characteristics;
    enum CurrentItem
    {
        Sword,
        Shield,
        Amulet
    }
    CurrentItem currentItem;
    public void OpenSwordItem(Hero hero, GameObject panel)
    {
        Characteristics = panel.GetComponent<CharacterCharacteristics>();
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

        itemName.text = "SWORD";
        if(currentInventory._swords_1_count > 0)
        {
            panel_rank1.SetActive(true);
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_1_image.sprite = _neutralItems_so.sword_1.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_1_image.sprite = _undeadItems_so.sword_1.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_1_image.sprite = _orderItems_so.sword_1.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_1_image.sprite = _demonItems_so.sword_1.sprite;
                    break;
            }
            item_1_count.text = currentInventory._swords_1_count.ToString();
        }
        else
        {
            panel_rank1.SetActive(false);
        }
        if (currentInventory._swords_2_count > 0 && hero.rank == 2)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_2_image.sprite = _neutralItems_so.sword_2.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_2_image.sprite = _undeadItems_so.sword_2.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_2_image.sprite = _orderItems_so.sword_2.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_2_image.sprite = _demonItems_so.sword_2.sprite;
                    break;
            }
            panel_rank2.SetActive(true);
            item_2_count.text = currentInventory._swords_2_count.ToString();
        }
        else
        {
            panel_rank2.SetActive(false);
        }
        if (currentInventory._swords_3_count > 0 && hero.rank == 3 )
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_3_image.sprite = _neutralItems_so.sword_3.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_3_image.sprite = _undeadItems_so.sword_3.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_3_image.sprite = _orderItems_so.sword_3.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_3_image.sprite = _demonItems_so.sword_3.sprite;
                    break;
            }
            panel_rank3.SetActive(true);
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

        itemName.text = "SHIELD";
        if (currentInventory._shield_1_count > 0)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_1_image.sprite = _neutralItems_so.shield_1.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_1_image.sprite = _undeadItems_so.shield_1.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_1_image.sprite = _orderItems_so.shield_1.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_1_image.sprite = _demonItems_so.shield_1.sprite;
                    break;
            }
            panel_rank1.SetActive(true);
            item_1_count.text = currentInventory._shield_1_count.ToString();
        }
        else
        {
            panel_rank1.SetActive(false);
        }
        if (currentInventory._shield_2_count > 0 && hero.rank == 2)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_2_image.sprite = _neutralItems_so.shield_2.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_2_image.sprite = _undeadItems_so.shield_2.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_2_image.sprite = _orderItems_so.shield_2.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_2_image.sprite = _demonItems_so.shield_2.sprite;
                    break;
            }
            panel_rank2.SetActive(true);
            item_2_count.text = currentInventory._shield_2_count.ToString();
        }
        else
        {
            panel_rank2.SetActive(false);
        }
        if (currentInventory._shield_3_count > 0 && hero.rank == 3)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_3_image.sprite = _neutralItems_so.shield_3.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_3_image.sprite = _undeadItems_so.shield_3.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_3_image.sprite = _orderItems_so.shield_3.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_3_image.sprite = _demonItems_so.shield_3.sprite;
                    break;
            }
            panel_rank3.SetActive(true);
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
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_1_image.sprite = _neutralItems_so.Amulet_1.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_1_image.sprite = _undeadItems_so.Amulet_1.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_1_image.sprite = _orderItems_so.Amulet_1.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_1_image.sprite = _demonItems_so.Amulet_1.sprite;
                    break;
            }
            panel_rank1.SetActive(true);
            item_1_count.text = currentInventory._amulet_1_count.ToString();
        }
        else
        {
            panel_rank1.SetActive(false);
        }
        if (currentInventory._amulet_2_count > 0 && hero.rank == 2)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_2_image.sprite = _neutralItems_so.Amulet_2.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_2_image.sprite = _undeadItems_so.Amulet_2.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_2_image.sprite = _orderItems_so.Amulet_2.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_2_image.sprite = _demonItems_so.Amulet_2.sprite;
                    break;
            }
            panel_rank2.SetActive(true);
            item_2_count.text = currentInventory._amulet_2_count.ToString();
        }
        else
        {
            panel_rank2.SetActive(false);
        }
        if (currentInventory._amulet_3_count > 0 && hero.rank == 3)
        {
            switch (hero.elementType)
            {
                case Hero.ElementType.Neutral:
                    Items_3_image.sprite = _neutralItems_so.Amulet_3.sprite;
                    break;
                case Hero.ElementType.Undead:
                    Items_3_image.sprite = _undeadItems_so.Amulet_3.sprite;
                    break;
                case Hero.ElementType.Order:
                    Items_3_image.sprite = _orderItems_so.Amulet_3.sprite;
                    break;
                case Hero.ElementType.Demon:
                    Items_3_image.sprite = _demonItems_so.Amulet_3.sprite;
                    break;
            }
            panel_rank3.SetActive(true);
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
        else
        {
            checkCurrent_1.SetActive(false);
            checkCurrent_2.SetActive(false);
            checkCurrent_3.SetActive(false);
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
        else
        {
            checkCurrent_1.SetActive(false);
            checkCurrent_2.SetActive(false);
            checkCurrent_3.SetActive(false);
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
        else
        {
            checkCurrent_1.SetActive(false);
            checkCurrent_2.SetActive(false);
            checkCurrent_3.SetActive(false);
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
                sword_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_1);
                    sword_image.sprite = _neutralItems_so.sword_1.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_1);
                    sword_image.sprite = _undeadItems_so.sword_1.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_1);
                    sword_image.sprite = _orderItems_so.sword_1.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_1);
                    sword_image.sprite = _demonItems_so.sword_1.sprite;
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                shield_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_1);
                    shield_image.sprite = _neutralItems_so.shield_1.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_1);
                    shield_image.sprite = _undeadItems_so.shield_1.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_1);
                    shield_image.sprite = _orderItems_so.shield_1.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_1);
                    shield_image.sprite = _demonItems_so.shield_1.sprite;
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                amulet_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_1);
                    amulet_image.sprite = _undeadItems_so.Amulet_1.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_1);
                    amulet_image.sprite = _undeadItems_so.Amulet_1.sprite;
                }
                else if (currentInventory == orderInventory)
                {

                    currentHero.TakeItem(_orderItems_so.Amulet_1);
                    amulet_image.sprite = _orderItems_so.Amulet_1.sprite;
                }
                else if (currentInventory == demonInventory)
                {

                    currentHero.TakeItem(_demonItems_so.Amulet_1);
                    amulet_image.sprite = _demonItems_so.Amulet_1.sprite;
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
                sword_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_2);
                    sword_image.sprite = _neutralItems_so.sword_2.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_2);
                    sword_image.sprite = _undeadItems_so.sword_2.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_2);
                    sword_image.sprite = _orderItems_so.sword_2.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_2);
                    sword_image.sprite = _demonItems_so.sword_2.sprite;
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                shield_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_2);
                    shield_image.sprite = _neutralItems_so.shield_2.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_2);
                    shield_image.sprite = _undeadItems_so.shield_2.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_2);
                    shield_image.sprite = _orderItems_so.shield_2.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_2);
                    shield_image.sprite = _demonItems_so.shield_2.sprite;
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                amulet_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_2);
                    amulet_image.sprite = _neutralItems_so.Amulet_2.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_2);
                    amulet_image.sprite = _undeadItems_so.Amulet_1.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.Amulet_2);
                    amulet_image.sprite = _orderItems_so.Amulet_1.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.Amulet_2);
                    amulet_image.sprite = _demonItems_so.Amulet_1.sprite;
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
                sword_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.sword_3);
                    sword_image.sprite = _neutralItems_so.sword_3.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.sword_3);
                    sword_image.sprite = _undeadItems_so.sword_3.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.sword_3);
                    sword_image.sprite = _orderItems_so.sword_3.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.sword_3);
                    sword_image.sprite = _demonItems_so.sword_3.sprite;
                }
            }
            else if (currentItem == CurrentItem.Shield)
            {
                shield_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.shield_3);
                    shield_image.sprite = _neutralItems_so.shield_3.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.shield_3);
                    shield_image.sprite = _undeadItems_so.shield_3.sprite;
                }
                else if (currentInventory == orderInventory)
                {
                    currentHero.TakeItem(_orderItems_so.shield_3);
                    shield_image.sprite = _orderItems_so.shield_3.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.shield_3);
                    shield_image.sprite = _demonItems_so.shield_3.sprite;
                }
            }
            else if (currentItem == CurrentItem.Amulet)
            {
                amulet_image.enabled = true;
                if (currentInventory == neutralInventory)
                {
                    currentHero.TakeItem(_neutralItems_so.Amulet_3);
                    amulet_image.sprite = _neutralItems_so.Amulet_3.sprite;
                }
                else if (currentInventory == undeadInventory)
                {
                    currentHero.TakeItem(_undeadItems_so.Amulet_3);
                    amulet_image.sprite = _undeadItems_so.Amulet_3.sprite;
                }
                else if (currentInventory == orderInventory)
                {

                    currentHero.TakeItem(_orderItems_so.Amulet_3);
                    amulet_image.sprite = _orderItems_so.Amulet_3.sprite;
                }
                else if (currentInventory == demonInventory)
                {
                    currentHero.TakeItem(_demonItems_so.Amulet_3);
                    amulet_image.sprite = _demonItems_so.Amulet_3.sprite;
                }

            }
        }
    }
    public void ClosePanel()
    {
 //       Characteristics.DisplayInfo();
        gameObject.SetActive(false);
        characterCharacteristics_panel.SetActive(true);
    }
}
