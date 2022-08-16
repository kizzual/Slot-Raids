using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionIcon : MonoBehaviour
{

    [SerializeField] private GameObject Boost_icon;
    public bool isBoostReady;
    public void ActivateEvent()
    {

        GlovalEventSystem.OnBoostIsReady += BoostReady;
        GlovalEventSystem.OnBoostIsNotReady += BosstIsNotReady;
    }
    
    private void BoostReady()
    {
        isBoostReady = true;
        CheckAttention();
    }

    private void BosstIsNotReady()
    {
        isBoostReady = false;
        CheckAttention();
    }

    private void CheckAttention()
    {
        if ( isBoostReady)
        {
            gameObject.SetActive(true);
            if (isBoostReady)
                Boost_icon.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            Boost_icon.SetActive(false);
        }
    }
    public void Start()
    {
        CheckAttention();
    }

}
