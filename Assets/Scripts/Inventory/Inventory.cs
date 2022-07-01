using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string _name;
   public int _eggs_count;
 public int _swords_1_count;
 public int _swords_2_count;
  public int _swords_3_count;
 public int _shield_1_count;
 public int _shield_2_count;
 public int _shield_3_count;
 public int _amulet_1_count;
 public int _amulet_2_count;
 public int _amulet_3_count;

    [SerializeField] private Image egg_image;
    [SerializeField] private Text egg_text;
    [SerializeField] private Image sword_1_image;
    [SerializeField] private Text sword_1_text;
    [SerializeField] private Image sword_2_image;
    [SerializeField] private Text sword_2_text;
    [SerializeField] private Image sword_3_image;
    [SerializeField] private Text sword_3_text;
    [SerializeField] private Image shield_1_image;
    [SerializeField] private Text shield_1_text;
    [SerializeField] private Image shield_2_image;
    [SerializeField] private Text shield_2_text;
    [SerializeField] private Image shield_3_image;
    [SerializeField] private Text shield_3_text;
    [SerializeField] private Image amulet_1_image;
    [SerializeField] private Text amulet_1_text;
    [SerializeField] private Image amulet_2_image;
    [SerializeField] private Text amulet_2_text;
    [SerializeField] private Image amulet_3_image;
    [SerializeField] private Text amulet_3_text;

    [SerializeField] private Text SellingGold;
    public Sprite elementLogo;
    public void SellAllItems()
    {
        _eggs_count = 0;
        _swords_1_count = 0;
        _swords_2_count = 0;
        _swords_3_count = 0;
        _shield_1_count = 0;
        _shield_2_count = 0;
        _shield_3_count = 0;
        _amulet_1_count = 0;
        _amulet_2_count = 0;
        _amulet_3_count = 0;
        SellingGold.text = "0";
        Initialise();
    }
    #region Initialise
    public void DisplaySellingGold(int gold)
    {
        SellingGold.text = ConvertText.FormatNumb(gold);
    }
    public void Initialise()
    {
        if(_eggs_count > 0)
            egg_image.gameObject.SetActive(true);
        else
            egg_image.gameObject.SetActive(false);

        if (_swords_1_count > 0)
            sword_1_image.gameObject.SetActive(true);
        else
            sword_1_image.gameObject.SetActive(false);

        if (_swords_2_count > 0)
            sword_2_image.gameObject.SetActive(true);
        else
            sword_2_image.gameObject.SetActive(false);

        if (_swords_3_count > 0)
            sword_3_image.gameObject.SetActive(true);
        else
            sword_3_image.gameObject.SetActive(false);

        if (_shield_1_count > 0)
            shield_1_image.gameObject.SetActive(true);
        else
            shield_1_image.gameObject.SetActive(false);

        if (_shield_2_count > 0)
            shield_2_image.gameObject.SetActive(true);
        else
            shield_2_image.gameObject.SetActive(false);

        if (_shield_3_count > 0)
            shield_3_image.gameObject.SetActive(true);
        else
            shield_3_image.gameObject.SetActive(false);

        if (_amulet_1_count > 0)
            amulet_1_image.gameObject.SetActive(true);
        else
            amulet_1_image.gameObject.SetActive(false);

        if (_amulet_2_count > 0)
            amulet_2_image.gameObject.SetActive(true);
        else
            amulet_2_image.gameObject.SetActive(false);

        if (_amulet_3_count > 0)
            amulet_3_image.gameObject.SetActive(true);
        else
            amulet_3_image.gameObject.SetActive(false);
    }
    public void CountInitialise()
    {
        egg_text.text = _eggs_count.ToString();
        sword_1_text.text = _swords_1_count.ToString();
        sword_2_text.text = _swords_2_count.ToString();
        sword_3_text.text = _swords_3_count.ToString();
        shield_1_text.text = _shield_1_count.ToString();
        shield_2_text.text = _shield_2_count.ToString();
        shield_3_text.text = _shield_3_count.ToString();
        amulet_1_text.text = _amulet_1_count.ToString();
        amulet_2_text.text = _amulet_2_count.ToString();
        amulet_3_text.text = _amulet_3_count.ToString();
    }
    #endregion
    #region Open Inventory
    public void OpenFullInventory()
    {
        CountInitialise();
        Initialise();
    }
    public void OpenOnly_Eggs()
    {
        CountInitialise();
        if (_eggs_count > 0)
        {
            egg_image.gameObject.SetActive(true);
        }
        else
        {
            egg_image.gameObject.SetActive(false);
        }
        sword_1_image.gameObject.SetActive(false);
        sword_2_image.gameObject.SetActive(false);
        sword_3_image.gameObject.SetActive(false);
        shield_1_image.gameObject.SetActive(false);
        shield_2_image.gameObject.SetActive(false);
        shield_3_image.gameObject.SetActive(false);
        amulet_1_image.gameObject.SetActive(false);
        amulet_2_image.gameObject.SetActive(false);
        amulet_3_image.gameObject.SetActive(false);
    }
    public void OpenOnly_Swords(int heroLvl)
    {
        CountInitialise();
        switch (heroLvl)
        {
            case 1:
                {
                    if(_swords_1_count > 0)
                    {
                        sword_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_1_image.gameObject.SetActive(false);
                    }
                    sword_2_image.gameObject.SetActive(false);
                    sword_3_image.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (_swords_1_count > 0)
                    {
                        sword_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_1_image.gameObject.SetActive(false);
                    }
                    if (_swords_2_count > 0)
                    {
                        sword_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_2_image.gameObject.SetActive(false);
                    }
                    sword_3_image.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (_swords_1_count > 0)
                    {
                        sword_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_1_image.gameObject.SetActive(false);
                    }
                    if (_swords_2_count > 0)
                    {
                        sword_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_2_image.gameObject.SetActive(false);
                    }
                    if (_swords_3_count > 0)
                    {
                        sword_3_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        sword_3_image.gameObject.SetActive(false);
                    }
                    break;
                }
        }
        egg_image.gameObject.SetActive(false);
        shield_1_image.gameObject.SetActive(false);
        shield_2_image.gameObject.SetActive(false);
        shield_3_image.gameObject.SetActive(false);
        amulet_1_image.gameObject.SetActive(false);
        amulet_2_image.gameObject.SetActive(false);
        amulet_3_image.gameObject.SetActive(false);
    }
    public void OpenOnly_Shields(int heroLvl)
    {
        CountInitialise();
        switch (heroLvl)
        {
            case 1:
                {
                    if (_shield_1_count > 0)
                    {
                        shield_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_1_image.gameObject.SetActive(false);
                    }
                    shield_2_image.gameObject.SetActive(false);
                    shield_3_image.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (_shield_1_count > 0)
                    {
                        shield_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_1_image.gameObject.SetActive(false);
                    }
                    if (_shield_2_count > 0)
                    {
                        shield_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_2_image.gameObject.SetActive(false);
                    }
                    shield_3_image.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (_shield_1_count > 0)
                    {
                        shield_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_1_image.gameObject.SetActive(false);
                    }
                    if (_shield_2_count > 0)
                    {
                        shield_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_2_image.gameObject.SetActive(false);
                    }
                    if (_shield_3_count > 0)
                    {
                        shield_3_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        shield_3_image.gameObject.SetActive(false);
                    }
                    break;
                }
        }
        egg_image.gameObject.SetActive(false);
        sword_1_image.gameObject.SetActive(false);
        sword_2_image.gameObject.SetActive(false);
        sword_3_image.gameObject.SetActive(false);
        amulet_1_image.gameObject.SetActive(false);
        amulet_2_image.gameObject.SetActive(false);
        amulet_3_image.gameObject.SetActive(false);
    }
    public void OpenOnly_Amulets(int heroLvl)
    {
        CountInitialise();
        switch (heroLvl)
        {
            case 1:
                {
                    if (_amulet_1_count > 0)
                    {
                        amulet_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_1_image.gameObject.SetActive(false);
                    }
                    amulet_2_image.gameObject.SetActive(false);
                    amulet_3_image.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (_amulet_1_count > 0)
                    {
                        amulet_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_1_image.gameObject.SetActive(false);
                    }
                    if (_amulet_2_count > 0)
                    {
                        amulet_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_2_image.gameObject.SetActive(false);
                    }
                    amulet_3_image.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (_amulet_1_count > 0)
                    {
                        amulet_1_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_1_image.gameObject.SetActive(false);
                    }
                    if (_amulet_2_count > 0)
                    {
                        amulet_2_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_3_image.gameObject.SetActive(false);
                    }
                    if (_amulet_3_count > 0)
                    {
                        amulet_3_image.gameObject.SetActive(true);
                    }
                    else
                    {
                        amulet_3_image.gameObject.SetActive(false);
                    }
                    break;
                }
        }
        egg_image.gameObject.SetActive(false);
        sword_1_image.gameObject.SetActive(false);
        sword_2_image.gameObject.SetActive(false);
        sword_3_image.gameObject.SetActive(false);
        shield_1_image.gameObject.SetActive(false);
        shield_2_image.gameObject.SetActive(false);
        shield_3_image.gameObject.SetActive(false);

    }
    #endregion
    #region Load / Save
    public void SetSaveInfo(SavedInvetory loadInv)
    {
        _eggs_count = loadInv._eggs_count;
        _swords_1_count = loadInv._swords_1_count;
        _swords_2_count = loadInv._swords_2_count;
        _swords_3_count = loadInv._swords_3_count;
        _shield_1_count = loadInv._shield_1_count;
        _shield_2_count = loadInv._shield_2_count;
        _shield_3_count = loadInv._shield_3_count;
        _amulet_1_count = loadInv._amulet_1_count;
        _amulet_2_count = loadInv._amulet_2_count;
        _amulet_3_count = loadInv._amulet_3_count;

        CountInitialise();
        Initialise();
    }
    public void GetSaveInfo(out string name,out int eggs, out int sword_1, out int sword_2, out int sword_3, out int shield_1, out int shield_2, out int shield_3, out int amulet_1, out int amulet_2, out int amulet_3)
    {
        name = _name;
        eggs = _eggs_count;
        sword_1 = _swords_1_count;
        sword_2 = _swords_2_count;
        sword_3 = _swords_3_count;
        shield_1 = _shield_1_count;
        shield_2 = _shield_2_count;
        shield_3 = _shield_3_count;
        amulet_1 = _amulet_1_count;
        amulet_2 = _amulet_2_count;
        amulet_3 = _amulet_3_count;
    }
    #endregion


}
