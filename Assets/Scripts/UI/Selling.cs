using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selling : MonoBehaviour
{
    [SerializeField] private Image item_image;
    [SerializeField] private Image element_image;
    [SerializeField] private Text itemName_text;
    [SerializeField] private Text itemRank_text;
    [SerializeField] private Text itemCountInInvetory_text;
    [SerializeField] private Text currentItemsCount_text;
    [SerializeField] private Text currentGoldSelling_text;
    [SerializeField] private GameObject frontPanel;

    public Inventory _currentInventory;
    private string _itemName;
    private int _currentCountInInventory;
    private int _currentCountForSelling;
    private int _currentRank;
    private int testGold = 0;
    private int _totalGold;
    public Prize _prize;
    public void TakeAllInfo(Prize prize, Inventory Inventory)
    {
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        _prize = prize;
        _currentInventory = Inventory;
        _currentCountInInventory = CheckElementType(prize);
        DisplayInfo(prize);
    }
    /*    private void CheckElementinventory(Prize prize, InventoryControl inventoryControl)
        {
            // сверяем стихии что понять какой из 4х инвентарей нам нужен
            // 1- neutral 2- undead 3- order 4- demon
            switch (prize._ElementType)
            {
                case ElementType.Neutral:
                    {
                        _currentInventory = inventoryControl.Inventories[0];
                        break;
                    }
                case ElementType.Undead:
                    {
                        _currentInventory = inventoryControl.Inventories[1];
                        break;
                    }
                case ElementType.Order:
                    {
                        _currentInventory = inventoryControl.Inventories[2];
                        break;
                    }
                case ElementType.Demon:
                    {
                        _currentInventory = inventoryControl.Inventories[3];
                        break;
                    }
            }
        }*/
    private int CheckElementType(Prize prize)
    {
        
        switch (prize._Type)
        {
            case Type.item_sword_1:
                {
                    _itemName = "SWORD";
                    _currentRank = 1;
                    return  _currentInventory._swords_1_count;
                }
            case Type.item_sword_2:
                {
                    _itemName = "SWORD";
                    _currentRank = 2;
                    return _currentInventory._swords_2_count;
                }
            case Type.item_sword_3:
                {
                    _itemName = "SWORD";
                    _currentRank = 3;
                    return _currentInventory._swords_3_count;
                }
            case Type.item_shield_1:
                {
                    _itemName = "SHIELD";
                    _currentRank = 1;
                    return _currentInventory._shield_1_count;
                }
            case Type.item_shield_2:
                {
                    _itemName = "SHIELD";
                    _currentRank = 2;
                    return _currentInventory._shield_2_count;
                }
            case Type.item_shield_3:
                {
                    _itemName = "SHIELD";
                    _currentRank = 3;
                    return _currentInventory._shield_3_count;
                }
            case Type.item_amulet_1:
                {
                    _itemName = "AMULET";
                    _currentRank = 1;
                    return _currentInventory._amulet_1_count;
                }
            case Type.item_amulet_2:
                {
                    _itemName = "AMULET";
                    _currentRank = 2;
                    return  _currentInventory._amulet_2_count;
                }
            case Type.item_amulet_3:
                {
                    _itemName = "AMULET";
                    _currentRank = 3;
                    return _currentInventory._amulet_3_count;
                }
            case Type.item_egg_neutral:
                {
                    _itemName = "EGG";
                    _currentRank = -1;
                    return _currentInventory._eggs_count;
                }
            case Type.item_egg_undead:
                {
                    _itemName = "EGG";
                    _currentRank = -1;
                    return _currentInventory._eggs_count;
                }
            case Type.item_egg_order:
                {
                    _itemName = "EGG";
                    _currentRank = -1;
                    return _currentInventory._eggs_count;
                }
            case Type.item_egg_demons:
                {
                    _itemName = "EGG";
                    _currentRank = -1;
                    return _currentInventory._eggs_count;
                }
        }
        return -1;
    }
    private void DisplayInfo(Prize prize)
    {
        if(_currentCountInInventory != -1)
        {
            item_image.sprite = prize.sprite;
            element_image.sprite = _currentInventory.elementLogo;
            itemName_text.text = _itemName;
            if (_currentRank != -1)
                itemRank_text.text = "RANK" + " " + _currentRank;
            else
                itemRank_text.text = " ";

            itemCountInInvetory_text.text = _currentCountInInventory.ToString();
            if(_currentCountInInventory > 0)
                _currentCountForSelling = 1;
            else
                _currentCountForSelling = 0;

            currentItemsCount_text.text = _currentCountForSelling.ToString();
            currentGoldSelling_text.text = ConvertText.FormatNumb(((prize.sellingPrice + testGold) * _currentCountForSelling));
        }
    }
    public void AddItemForSelling()
    {
        if (_currentCountForSelling < _currentCountInInventory)
        {
            _currentCountForSelling += 1;
            currentItemsCount_text.text = _currentCountForSelling.ToString();
            currentGoldSelling_text.text = ConvertText.FormatNumb(((_prize.sellingPrice + testGold) * _currentCountForSelling));
        }
    }
    public void ReduceItemForSelling()
    {
        if (_currentCountForSelling > 0)
        {
            _currentCountForSelling -= 1;
            currentItemsCount_text.text = _currentCountForSelling.ToString();
            currentGoldSelling_text.text = ConvertText.FormatNumb(((_prize.sellingPrice + testGold) * _currentCountForSelling));
        }
    }
    public void MaxItemForSelling()
    {
        _currentCountForSelling = _currentCountInInventory;
        currentItemsCount_text.text = _currentCountForSelling.ToString();
        currentGoldSelling_text.text = ConvertText.FormatNumb(((_prize.sellingPrice + testGold) * _currentCountForSelling));
    }
    public void SellingItem()
    {
        _totalGold = 0;
        _totalGold = _prize.sellingPrice * _currentCountForSelling;
        _currentCountInInventory -= _currentCountForSelling;
        switch (_prize._Type)
        { 
            case Type.item_sword_1:
                _currentInventory._swords_1_count = _currentCountInInventory;
                break;
            case Type.item_sword_2:
                _currentInventory._swords_2_count = _currentCountInInventory;
                break;
            case Type.item_sword_3:
                _currentInventory._swords_3_count = _currentCountInInventory;
                break;
            case Type.item_shield_1:
                _currentInventory._shield_1_count = _currentCountInInventory;
                break;
            case Type.item_shield_2:
                _currentInventory._shield_2_count = _currentCountInInventory;
                break;
            case Type.item_shield_3:
                _currentInventory._shield_3_count = _currentCountInInventory;
                break;
            case Type.item_amulet_1:
                _currentInventory._amulet_1_count = _currentCountInInventory;
                break;
            case Type.item_amulet_2:
                _currentInventory._amulet_2_count = _currentCountInInventory;
                break;
            case Type.item_amulet_3:
                _currentInventory._amulet_3_count = _currentCountInInventory;
                break;

/*            case Type.item_egg_neutral:
                break;
            case Type.item_egg_undead:
                break;
            case Type.item_egg_order:
                break;
            case Type.item_egg_demons:
                break;
*/
        }



         
        _currentInventory.CountInitialise();
        _currentInventory.Initialise();
        Gold.AddGold(_totalGold);
        frontPanel.SetActive(false);
        gameObject.SetActive(false);
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        frontPanel.SetActive(false);
    }
}
