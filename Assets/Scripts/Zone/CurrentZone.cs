using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CurrentZone : MonoBehaviour
{

    public static Zone Current_Zone;
    public Zone zone;

    public static void SetZone(Zone zone)
    {  
        Current_Zone = zone;
   
        PlayerPrefs.SetInt("CurrentZone", Current_Zone.ID);
        Debug.Log("Current zone after =  " + Current_Zone.nameLocation);
    }


/*    private void Start()
    {
        if (!PlayerPrefs.HasKey("Zone"))
        {
                SetZone(zone);
                Debug.Log("CCCCCCHEEECK");
        }
           
  
    }*/
}

 