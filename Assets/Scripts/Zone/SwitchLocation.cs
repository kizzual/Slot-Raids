using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    [SerializeField] private GameObject[] _raidLocation;
    [SerializeField] private Raid_control raid_Control;
    public void SwitchRaidLocation(Zone zone)
    {
        for (int i = 0; i < _raidLocation.Length; i++)
        {
            _raidLocation[i].SetActive(false);
        }
        switch (zone.typeElement)
        {
            case Type__Element.Neutral:
                _raidLocation[0].SetActive(true);
                break;
            case Type__Element.Undead:
                _raidLocation[1].SetActive(true);
                break;
            case Type__Element.Order:
                _raidLocation[2].SetActive(true);
                break;
            case Type__Element.Demon:
                _raidLocation[3].SetActive(true);
                break;

        }
        raid_Control.Switchlocation(zone);
    }


}
