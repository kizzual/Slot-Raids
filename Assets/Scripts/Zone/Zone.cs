using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public Type__Element typeElement;
    public int ID;
    public int Rank;
    public int Luck;
    public int UnLuck;
    public int goldProfit { get; set; } = 1;
    public int itemProfit { get; set; } = 1;
    public List<Item> ItemsOnZone;
    public Sprite ZoneSprite;
    public bool isOpened;
    public string nameLocation;
    
    public Button button;
    public GameObject IsOpenedPanel;
    public GameObject IscloseddPanel;
    public GameObject currentZoneCheck;
    public int RaidsCount  = 0;
    private int m_luckBoost = 0;
    private int m_unLuckBoost = 0;
    private int m_goldBoost = 0;
    private int m_itemBoost = 0;
    public GameObject AttentionIcon;
    public bool isNewZone  = false;
    public Sprite logo;
    public void SwitchLocation(Zone zone)
    {
        isNewZone = false;
        AttentionIcon.SetActive(false);
        CurrentZone.SetZone(zone);
        GlovalEventSystem.SwitchLocation(zone);
    }
    public void GoToRaid()
    {
        Debug.Log("Go Zone RAid");
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
            button.enabled = true;
        }
        else
        {
            currentZoneCheck.SetActive(false);
            IsOpenedPanel.SetActive(false);
            IscloseddPanel.SetActive(true);
            button.enabled = false;
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


