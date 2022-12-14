using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppodealRewardAds : MonoBehaviour, IRewardedVideoAdListener
{
    private string appKey = "7843deeefd75fa9c0f40a6e54abb91c1b0a9d653e87a2a3d";

    private int Ad_reload;
    private int Ad_coins;
    private int Ad_bottle;
    public bool isTesting;
    [SerializeField] private ShopIAP shopIAP;
    [SerializeField] private Boost_Controll boost_Controll;
    private enum AdsType
    {
        Money,
        Bottle,
        Reload
    }
    private AdsType m_adsType;
    private void Start()
    {
        InitialiseAds();
        Appodeal.setRewardedVideoCallbacks(this);
    }
    private void InitialiseAds()
    {
        Appodeal.setTesting(isTesting);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO);

    }
    private void ChacheReloadVideo()
    {
        Appodeal.setTesting(isTesting);
        Ad_reload =  Appodeal.REWARDED_VIDEO;
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(appKey, Ad_reload, this);
    }
    private void Chache50cVideo()
    {
        Appodeal.setTesting(isTesting);
        Ad_coins = Appodeal.REWARDED_VIDEO;
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(appKey, Ad_coins, this);
    }
    private void Chache1bVideo()
    {
        Appodeal.setTesting(isTesting);
        Ad_bottle = Appodeal.REWARDED_VIDEO;
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(appKey, Ad_bottle, this);
    }
    private void ReloadCards_reward()
    {
        Debug.Log("ReloadReward_complete");
        boost_Controll.RandomizeCard();
        ApsFlyerEvents.ADS_rewarded_event("ShuffleBoostCards");
        ChacheReloadVideo();
    }
    private void Coins_reward()
    {
        Debug.Log("CoinsReward_complete");
        shopIAP.Buy50k();
        ApsFlyerEvents.ADS_rewarded_event("Money_Reward");
        Chache50cVideo();
    }
    private void BottleReward()
    {
        Debug.Log("BottleReward_complete");
        shopIAP.Buy1b();
        ApsFlyerEvents.ADS_rewarded_event("ManaBottle_Reward");
        Chache1bVideo();
    }
    public void ShowAd_50c()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO) )
        {
            m_adsType = AdsType.Money;
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }
    public void ShowAd_1b()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            m_adsType = AdsType.Bottle;
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }
    public void ShowAd_reloadCard()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            m_adsType = AdsType.Reload;
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }

    public void onRewardedVideoLoaded(bool precache)
    {
    }

    public void onRewardedVideoFailedToLoad()
    {
    }

    public void onRewardedVideoShowFailed()
    {
    }

    public void onRewardedVideoShown()
    {
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        if (m_adsType == AdsType.Money)
            Coins_reward();
        else if (m_adsType == AdsType.Bottle)
            BottleReward();
        else if (m_adsType == AdsType.Reload)
            ReloadCards_reward();
    }

    public void onRewardedVideoClosed(bool finished)
    {
    }

    public void onRewardedVideoExpired()
    {
    }

    public void onRewardedVideoClicked()
    {
    }

}
