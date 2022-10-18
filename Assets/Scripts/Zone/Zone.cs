using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite ZoneSprite_closed;
    public Sprite elementLogo;
    public Sprite logo;
    public bool isOpened;
    [Space]
    [Header("UI")]
    [SerializeField] private GameObject IsOpenedPanel;
    [SerializeField] private GameObject IscloseddPanel;
    [SerializeField] private GameObject currentZoneCheck;
    [SerializeField] private Text name_Location;
    [SerializeField] private Text Luck_value;
    [SerializeField] private Text UnLuck_value;
    [SerializeField] private List<Image> itemIcons;
    [SerializeField] private Image element;
    [SerializeField] private Image OpenBG;
    [SerializeField] private Image CloseBG;
    public int RaidsCount { get; set; } = 0;
    private int m_luckBoost { get; set; } = 0;
    private int m_unLuckBoost { get; set; } = 0;
    private int m_goldBoost { get; set; } = 0;
    private int m_itemBoost { get; set; } = 0;
    [SerializeField] private GameObject AttentionIcon;
    [SerializeField] private SwitchTabs switchTabs;
    [SerializeField] private SwitchLocation switchLocation;
    public bool isNewZone { get; set; }  = false;
    public void SwitchLocation(Zone zone)
    {
        isNewZone = false;
        AttentionIcon.SetActive(false);
        CurrentZone.SetZone(zone);
        switchLocation.SwitchRaidLocation(zone);
        switchTabs.GoToRaid(zone);
    }
    public void Initialise()
    {
        Luck_value.text = Luck.ToString() + "%";
        UnLuck_value.text = UnLuck.ToString() + "%";
        OpenBG.sprite = ZoneSprite;
        CloseBG.sprite = ZoneSprite_closed;
        name_Location.text = nameLocation;
        if (ItemsOnZone[0] != null)
            itemIcons[0].sprite = ItemsOnZone[0].Icon;
        if (ItemsOnZone[1] != null)
            itemIcons[1].sprite = ItemsOnZone[1].Icon;
        element.sprite = elementLogo;
        if (isOpened)
        {
            IsOpenedPanel.SetActive(true);
            IscloseddPanel.SetActive(false);
        }
        else
        {
            IsOpenedPanel.SetActive(false);
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
            if(CurrentZone.Current_Zone == this)
            {
                currentZoneCheck.SetActive(true);
            }
            else
            {
                currentZoneCheck.SetActive(false);
            }
            IsOpenedPanel.SetActive(true);
            IscloseddPanel.SetActive(false);
        }
        else
        {
            currentZoneCheck.SetActive(false);
            IsOpenedPanel.SetActive(false);
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


