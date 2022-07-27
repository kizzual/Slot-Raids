using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public Type__Element typeElement;
    public int Rank;
    public int Luck;
    public int UnLuck;
    public int goldProfit { get; set; } = 1;
    public int itemProfit { get; set; } = 1;
    public List<Item> ItemsOnZone;

    private int m_luckBoost = 0;
    private int m_unLuckBoost = 0;
    private int m_goldBoost = 0;
    private int m_itemBoost = 0;
    public void SwitchLocation(Zone zone)
    {
        CurrentZone.SetZone(zone);
        GlovalEventSystem.SwitchLocation(zone);
    }
    public void AddBust(int luck, int unluck, int goldProfit, int itemProfit)
    {
        m_luckBoost = luck;
        m_unLuckBoost = unluck;
        m_goldBoost = goldProfit;
        m_itemBoost = itemProfit;
        Luck += m_luckBoost;
        UnLuck += m_unLuckBoost;
        this.goldProfit += m_goldBoost;
        this.itemProfit += m_itemBoost;
    }
    public void RemoveBoost()
    {
        Luck -= m_luckBoost;
        UnLuck -= m_unLuckBoost;
        goldProfit -= m_goldBoost;
        itemProfit -= m_itemBoost;
        m_luckBoost = 0;
        m_unLuckBoost = 0;
        m_goldBoost = 1;
        m_itemBoost = 1;
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


