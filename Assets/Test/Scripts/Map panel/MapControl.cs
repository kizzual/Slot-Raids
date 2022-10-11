using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    [SerializeField] private List<Zone> Zones;
    void Start()
    {
        for (int i = 0; i < Zones.Count; i++)
        {
            Zones[i].Initialise();
        }
    }



}
