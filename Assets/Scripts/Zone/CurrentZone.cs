using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentZone : MonoBehaviour
{
    public static Zone Current_Zone;
    public Zone zone;
    public static void SetZone(Zone zone)
    {
        Current_Zone = zone;
        Debug.Log(zone.name);
    }


    private void Awake()
    {
        SetZone(zone);
        Debug.Log(zone.name);
    }
}
