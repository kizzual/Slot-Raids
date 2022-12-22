using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ShopIAP : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles;
    [SerializeField] private List<ParticleAdaptive> particlesAdapt;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private Raid_control raidControll;
    [SerializeField] private GameObject blockImg;
    [SerializeField] private IAPManager IAPManager;
    public void TryBuy10mCoins() => IAPManager.Buy10mCoins();
    public void TryBuy100mCoins() => IAPManager.Buy100mCoins();
    public void TryBuy10bottles() => IAPManager.Buy10bottles();
    public void TryBuy50bottles() => IAPManager.Buy50bottles();
    public void TryBuyCombo() => IAPManager.BuyCombo();

    private void Start()
    {
        for (int i = 0; i < particlesAdapt.Count; i++)
        {
            particlesAdapt[i].Initialise();
        }
    }
    private void OnEnable()
    {
        raidControll.StopRaid();
    }
    private void OnDisable()
    {
        raidControll.StartRaid();
    }
    public void Buy50k()
    {
        Gold.AddGold(50000);
        //  StartCoroutine(BlockAdsImg(0));
        particles[0].Play();
    }
    public void Buy1b()
    {
        boost_Controll.BuyBottles(1);
        particles[1].Play();
        // StartCoroutine(BlockAdsImg(1));
    }
    public void SuccessBuy10m()
    {
        try
        {
            Gold.AddGold(10000000);
            Debug.Log(" Gold Added");
        }
        catch
        {
            Debug.Log("Gold not added");
        }
        try
        {
            if (particles[2] != null)
            {
                particles[2].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[2].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[2] not found");
            }
        }
        catch
        {
            Debug.Log("particles[2] not played");
        }

        try
        {
            SoundControl._instance.PlayCash();
        }
        catch
        {
            Debug.Log("Sound not played");
        }

    }
    public void SuccessBuy100m()
    {
        Debug.Log(" Start reward 10 m Coins");
        try
        {
            Gold.AddGold(100000000);
            Debug.Log(" Gold Added");
        }
        catch
        {
            Debug.Log("Gold not added");
        }
        try
        {
            if (particles[4] != null)
            {
                particles[4].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[4].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[4] not found");
            }
        }
        catch
        {
            Debug.Log("particles[4] not played");
        }

        try
        {
            SoundControl._instance.PlayCash();
        }
        catch
        {
            Debug.Log("Sound not played");
        }

        Debug.Log(" reward complete");

    }
    public void SuccessBuy10b()
    {
        Debug.Log(" Start reward 10 BOTTLE");

        try
        {
            boost_Controll.BuyBottles(10);
            Debug.Log(" bottle Added");
        }
        catch
        {
            Debug.Log("bottle not added");
        }
        try
        {
            if (particles[3] != null)
            {
                particles[3].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[3].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[3] not found");
            }
        }
        catch
        {
            Debug.Log("particles[3] not played");
        }

        try
        {
            SoundControl._instance.PlayCash();
        }
        catch
        {
            Debug.Log("Sound not played");
        }

        Debug.Log(" reward complete");
    }
    public void SuccessBuy50b()
    {

        Debug.Log(" Start reward 50 BOTTLE");

        try
        {
            boost_Controll.BuyBottles(50);
            Debug.Log(" bottle Added");
        }
        catch
        {
            Debug.Log("bottle not added");
        }
        try
        {
            if (particles[5] != null)
            {
                particles[5].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[5].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[5] not found");
            }
        }
        catch
        {
            Debug.Log("particles[5] not played");
        }

        try
        {
            SoundControl._instance.PlayCash();
        }
        catch
        {
            Debug.Log("Sound not played");
        }

        Debug.Log(" reward complete");
    }

    public void SuccessBuyCombo()
    {
        Debug.Log(" Start reward COMBO");

        try
        {
            boost_Controll.BuyBottles(50);
            Debug.Log(" bottle Added");
        }
        catch
        {
            Debug.Log("bottle not added");
        }

        try
        {
            Gold.AddGold(100000000);
            Debug.Log(" Gold Added");
        }
        catch
        {
            Debug.Log("Gold not added");
        }
        try
        {
            if (particles[6] != null)
            {
                particles[6].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[6].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[6] not found");
            }
            if (particles[7] != null)
            {
                particles[7].Play();
                Debug.Log(" Particles played");
            }
            else
            {
                particlesAdapt[7].GetComponent<ParticleSystem>().Play();
                Debug.Log("particles[7] not found");
            }
        }
        catch
        {
            Debug.Log("particles[6] not played");
            Debug.Log("particles[7] not played");
        }

        try
        {
            SoundControl._instance.PlayCash();
        }
        catch
        {
            Debug.Log("Sound not played");
        }

        Debug.Log(" reward complete");

    }
    IEnumerator BlockAdsImg(int particleIndex)
    {  
        blockImg.SetActive(true);
        particles[0].GetComponent<ParticleAdaptive>().Initialise();
        yield return new WaitForSeconds(2f);
        particles[particleIndex].Play();
        SoundControl._instance.PlayCash();
        blockImg.SetActive(false);
    }
    
}
