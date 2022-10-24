using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttentionIcon : MonoBehaviour
{
    [SerializeField] private List<Zone> zones;
    [SerializeField] private GameObject panelAttention;
    [SerializeField] private List<GameObject> ZoneAttention;



    public void CheckAttention()
    {
        bool check = false;
        for (int i = 0; i < ZoneAttention.Count; i++)
        {
            ZoneAttention[i].SetActive(false);
        }
        for (int i = 0; i < zones.Count ; i++)
        {
            if(zones[i].isOpened && zones[i].isNewZone)
            {
                switch (zones[i].typeElement)
                {
                    case Type__Element.Neutral:
                        ZoneAttention[0].SetActive(true);
                        check = true;
                        break;
                    case Type__Element.Undead:
                        ZoneAttention[1].SetActive(true);
                        check = true;
                        break;
                    case Type__Element.Order:
                        ZoneAttention[2].SetActive(true);
                        check = true;
                        break;
                    case Type__Element.Demon:
                        ZoneAttention[3].SetActive(true);
                        check = true;
                        break;
                }
            }
        }
    
      
        if (check)
            panelAttention.SetActive(true);
        else
            panelAttention.SetActive(false);
    }

}
