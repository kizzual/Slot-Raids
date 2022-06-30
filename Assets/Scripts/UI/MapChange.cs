using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    [SerializeField] private GameObject GreenZone;
    [SerializeField] private GameObject BlueZone;
    [SerializeField] private GameObject YellowZone;
    [SerializeField] private GameObject RedZone;
 
    [SerializeField] private ScrollingController scrollingController;
 
    public void SwitchMap(Zone zone)
    {
        if (!zone.IsClosed)
        {
            if (zone.ZoneElement == Zone.zoneElement.Neutral)
            {
                GreenZone.SetActive(true);
                BlueZone.SetActive(false);
                YellowZone.SetActive(false);
                RedZone.SetActive(false);
            }
            else if (zone.ZoneElement == Zone.zoneElement.Undead)
            {
                GreenZone.SetActive(false);
                BlueZone.SetActive(true);
                YellowZone.SetActive(false);
                RedZone.SetActive(false);
            }
            else if (zone.ZoneElement == Zone.zoneElement.Order)
            {
                GreenZone.SetActive(false);
                BlueZone.SetActive(false);
                YellowZone.SetActive(true);
                RedZone.SetActive(false);
            }
            else if (zone.ZoneElement == Zone.zoneElement.Demon)
            {
                GreenZone.SetActive(false);
                BlueZone.SetActive(false);
                YellowZone.SetActive(false);
                RedZone.SetActive(true);
            }
            scrollingController.SwitchCurrentZone(zone);
        }

    }

}
