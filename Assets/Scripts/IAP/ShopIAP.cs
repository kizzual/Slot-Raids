using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopIAP : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private GameObject blockImg;
    public void TryBuy10mCoins() => IAPManager.instance.Buy10mCoins();
    public void TryBuy100mCoins() => IAPManager.instance.Buy100mCoins();
    public void TryBuy10bottles() => IAPManager.instance.Buy10bottles();
    public void TryBuy50bottles() => IAPManager.instance.Buy50bottles();
    public void TryBuyCombo() => IAPManager.instance.BuyCombo();

    public void Buy50k()
    {
        Gold.AddGold(50000);
        StartCoroutine(BlockAdsImg(0));
    }
    public void Buy1b()
    {
        boost_Controll.BuyBottles(1);
        StartCoroutine(BlockAdsImg(1));
    }
    public void SuccessBuy10m()
    {
        Gold.AddGold(10000000);
        particles[2].GetComponent<ParticleAdaptive>().Initialise();
        particles[2].Play();
        SoundControl._instance.PlayCash();
    }
    public void SuccessBuy10b()
    {
        boost_Controll.BuyBottles(10);
        particles[3].GetComponent<ParticleAdaptive>().Initialise();
        particles[3].Play();
        SoundControl._instance.PlayCash();
    }
    public void SuccessBuy100m()
    {
        Gold.AddGold(100000000);
        particles[4].GetComponent<ParticleAdaptive>().Initialise();
        particles[4].Play();
        SoundControl._instance.PlayCash();
    }
    public void SuccessBuy50b()
    {
        boost_Controll.BuyBottles(50);
        particles[5].GetComponent<ParticleAdaptive>().Initialise();
        particles[5].Play();
        SoundControl._instance.PlayCash();
    }

    public void SuccessBuyCombo()
    {
        Gold.AddGold(100000000);
        boost_Controll.BuyBottles(50);
        particles[6].GetComponent<ParticleAdaptive>().Initialise();
        particles[7].GetComponent<ParticleAdaptive>().Initialise();
        particles[6].Play(); 
        particles[7].Play();
        SoundControl._instance.PlayCash();
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
