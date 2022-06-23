using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    [SerializeField] private GameObject[] _raidLocation;
    public void SwitchRaidLocation(int indexLocation)
    {
        for (int i = 0; i < _raidLocation.Length; i++)
        {
            if (i != indexLocation)
            {
                _raidLocation[i].SetActive(false);
            }
            else
            {
                _raidLocation[i].SetActive(true);
            }
        }
    }
}
