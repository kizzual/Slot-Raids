using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public Type__Element typeElement;
    public int Rank;
    public int Luck;
    public int UnLuck;
    public List<Item> ItemsOnZone;

    private int m_luckBoost = 0;
    private int m_unLuckBoost = 0;
    public void SwitchLocation(Zone zone)
    {
        CurrentZone.SetZone(zone);
        GlovalEventSystem.SwitchLocation(zone);
    }
    public void AddBust(int luck, int unluck)
    {
        m_luckBoost = luck;
        m_unLuckBoost = UnLuck;
        Luck += m_luckBoost;
        UnLuck += m_unLuckBoost;
    }
    public void RemoveBoost()
    {
        Luck -= m_luckBoost;
        UnLuck -= m_unLuckBoost;
        m_luckBoost = 0;
        m_unLuckBoost = 0;
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


