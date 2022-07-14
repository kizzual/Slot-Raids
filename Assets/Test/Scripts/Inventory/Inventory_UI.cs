using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _sword_1_image;
    [SerializeField] private Text _sword_1_text;
    [SerializeField] private Image _sword_2_image;
    [SerializeField] private Text _sword_2_text;
    [SerializeField] private Image _sword_3_image;
    [SerializeField] private Text _sword_3_text;
    [SerializeField] private Image _shield_1_image;
    [SerializeField] private Text _shield_1_text;
    [SerializeField] private Image _shield_2_image;
    [SerializeField] private Text _shield_2_text;
    [SerializeField] private Image _shield_3_image;
    [SerializeField] private Text _shield_3_text;
    [SerializeField] private Image _amulet_1_image;
    [SerializeField] private Text _amulet_1_text;
    [SerializeField] private Image _amulet_2_image;
    [SerializeField] private Text _amulet_2_text;
    [SerializeField] private Image _amulet_3_image;
    [SerializeField] private Text _amulet_3_text;
    [SerializeField] private Text _fullPrice;

    public long m_sellPrice_number { get; set; }
    public void DisplaySword_1(int count)
    {
        if (count > 0)
            _sword_1_image.gameObject.SetActive(true);
        else
            _sword_1_image.gameObject.SetActive(false);
        _sword_1_text.text = count.ToString();
    }
    public void DisplaySword_2(int count)
    {
        if (count > 0)
            _sword_2_image.gameObject.SetActive(true);
        else
            _sword_2_image.gameObject.SetActive(false);
        _sword_2_text.text = count.ToString();
    }
    public void DisplaySword_3(int count)
    {
        if (count > 0)
            _sword_3_image.gameObject.SetActive(true);
        else
            _sword_3_image.gameObject.SetActive(false);
        _sword_3_text.text = count.ToString();
    }
    public void DisplayShield_1(int count)
    {
        if (count > 0)
            _shield_1_image.gameObject.SetActive(true);
        else
            _shield_1_image.gameObject.SetActive(false);
        _shield_1_text.text = count.ToString();
    }
    public void DisplayShield_2(int count)
    {
        if (count > 0)
            _shield_2_image.gameObject.SetActive(true);
        else
            _shield_2_image.gameObject.SetActive(false);
        _shield_2_text.text = count.ToString();
    }
    public void DisplayShield_3(int count)
    {
        if (count > 0)
            _shield_3_image.gameObject.SetActive(true);
        else
            _shield_3_image.gameObject.SetActive(false);
        _shield_3_text.text = count.ToString();
    }
    public void DisplayAmulet_1(int count)
    {
        if (count > 0)
            _amulet_1_image.gameObject.SetActive(true);
        else
            _amulet_1_image.gameObject.SetActive(false);
        _amulet_1_text.text = count.ToString();
    }
    public void DisplayAmulet_2(int count)
    {
        if (count > 0)
            _amulet_2_image.gameObject.SetActive(true);
        else
            _amulet_2_image.gameObject.SetActive(false);
        _amulet_2_text.text = count.ToString();
    }
    public void DisplayAmulet_3(int count)
    {
        if (count > 0)
            _amulet_3_image.gameObject.SetActive(true);
        else
            _amulet_3_image.gameObject.SetActive(false);
        _amulet_3_text.text = count.ToString();
    }

    public void DisplaySellPrice(long fullPrice)
    {
        m_sellPrice_number = fullPrice;
        _fullPrice.text = m_sellPrice_number.ToString();
    }
}
