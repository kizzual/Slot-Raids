using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttentionIcon : MonoBehaviour
{
    [SerializeField] private List<Zone> zones;
    [SerializeField] private GameObject ZoneAttention;



    public void CheckAttention()
    {
       /* bool check = false;
        foreach (var item in zones)
        {
            if (item.isOpened && item.isNewZone)
            {
                check = true;
             //   item.AttentionIcon.SetActive(true);
            }
            else
            {
             //   item.AttentionIcon.SetActive(false);
            }
        }
        if (check)
            ZoneAttention.SetActive(true);
        else
            ZoneAttention.SetActive(false);*/
    }
    private void test(Zone zone)
    {
        CheckAttention();
    }
}
