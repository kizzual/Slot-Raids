using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool IsClosed;
    public int ItemPercent = 30 ;
    public int DeathPercent =  20 ;
    public int NumberOfElements = 1;
    public int zoneRank;
    public enum zoneElement
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public zoneElement ZoneElement;
    public enum additionalElement
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public additionalElement AdditionalElement;

    public NeutralItemsSO neutralItems;
    public UndeadItemsSO undeadItems;
    public OrderItemsSO orderItems;
    public DemonItemsSO demonItems;

}
