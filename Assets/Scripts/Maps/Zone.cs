using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public int ItemPercent = 30 ;
    public int DeathPercent =  20 ;
    public int NumberOfElements = 1;
    public enum zoneElement
    {
        Green,
        Purple,
        Yellow,
        Red
    }
    public zoneElement ZoneElement;
    public enum additionalElement
    {
        Green,
        Purple,
        Yellow,
        Red
    }
    public additionalElement AdditionalElement;

    public NeutralItemsSO items;

}
