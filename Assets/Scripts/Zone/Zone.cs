using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Zone : MonoBehaviour
{
    [Header("Settings")]
    public Type__Element typeElement;
    public string nameLocation;
    public int ID;
    public int Rank;
    public int Luck;
    public int UnLuck;
    public int goldProfit { get; set; } = 1;
    public int itemProfit { get; set; } = 1;
    public List<Item> ItemsOnZone;
    public Sprite ZoneSprite;
    public Sprite logo;
    public bool isOpened;
    [Space]
    [Header("UI")]
    [SerializeField] private GameObject IscloseddPanel;
    [SerializeField] private GameObject currentZoneCheck;
    [SerializeField] private TextMeshProUGUI Luck_value;
    [SerializeField] private TextMeshProUGUI UnLuck_value;
    [SerializeField] private List<Image> itemIcons;
    [SerializeField] private Button pickButton;

    public int RaidsCount { get; set; } = 0;
    private int m_luckBoost { get; set; } = 0;
    private int m_unLuckBoost { get; set; } = 0;
    private int m_goldBoost { get; set; } = 0;
    private int m_itemBoost { get; set; } = 0;

    [SerializeField] private SwitchTabs switchTabs;
    [SerializeField] private SwitchLocation switchLocation;
    public bool isNewZone { get; set; }  = false;
    public void SwitchLocation(Zone zone)
    {
        isNewZone = false;
        CurrentZone.SetZone(zone);
        switchLocation.SwitchRaidLocation(zone);
        switchTabs.GoToRaid(zone);
    }
    public void Initialise()
    {
        Luck_value.text = Luck.ToString() + "%";
        UnLuck_value.text = UnLuck.ToString() + "%";
        if (ItemsOnZone[0] != null)
            itemIcons[0].sprite = ItemsOnZone[0].Icon;
        if (ItemsOnZone[1] != null)
            itemIcons[1].sprite = ItemsOnZone[1].Icon;
        if (isOpened)
        {
            pickButton.interactable = true;
            IscloseddPanel.SetActive(false);
        }
        else
        {
            pickButton.interactable = false;
            IscloseddPanel.SetActive(true);
        }
    }
    public void GoToRaid()
    {
     //   Debug.Log("Go Zone RAid");
        RaidsCount++;
    }
    public void AddBust(int luck, int unluck, int goldProfit, int itemProfit)
    {
        m_luckBoost = luck;
        m_unLuckBoost = unluck;
        m_goldBoost = goldProfit;
        m_itemBoost = itemProfit;
        Luck += m_luckBoost;
        UnLuck -= m_unLuckBoost;
        this.goldProfit += m_goldBoost;
        this.itemProfit += m_itemBoost;
    }
    public void RemoveBoost()
    {
        Luck -= m_luckBoost;
        UnLuck += m_unLuckBoost;
        goldProfit -= m_goldBoost;
        itemProfit -= m_itemBoost;
        m_luckBoost = 0;
        m_unLuckBoost = 0;
        m_goldBoost = 1;
        m_itemBoost = 1;
    }
    private void OnEnable()
    {
        if(isOpened)
        {
            pickButton.interactable = true;
            if (CurrentZone.Current_Zone == this)
            {
                currentZoneCheck.SetActive(true);
            }
            else
            {
                currentZoneCheck.SetActive(false);
            }
            IscloseddPanel.SetActive(false);
        }
        else
        {
            pickButton.interactable = false;
            currentZoneCheck.SetActive(false);
            IscloseddPanel.SetActive(true);
        }
    }
 
}
[System.Serializable]
public enum Type__Element
{
    Neutral,
    Undead,
    Order,
    Demon
}


