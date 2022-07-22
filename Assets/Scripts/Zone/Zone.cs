using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public Type__Element typeElement;
    public int Rank;
    public List<Item> ItemsOnZone;
    public void SwitchLocation(Zone zone)
    {
        CurrentZone.SetZone(zone);
        GlovalEventSystem.SwitchLocation(zone);
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


