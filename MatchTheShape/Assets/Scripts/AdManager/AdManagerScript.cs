using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdManagerScript : MonoBehaviour
{
    [SerializeField] internal GameHandle gameHandle;

    private BannerView bannerAd;
    private RewardedAd rewardAd;

    private string bannerAdId = "ca-app-pub-6812974506656826/7614905878";
    private string rewardAdId = "ca-app-pub-6812974506656826/7107788772";

    private void Start()
    {
        RequestBanner();
        RequestReward();
    }
    private void RequestBanner()
    {
        this.bannerAd = new BannerView(bannerAdId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(request);
    }
    void RequestReward()
    {
        MobileAds.Initialize(InitStatus => { });
        this.rewardAd = new RewardedAd(rewardAdId);

        this.rewardAd.OnAdLoaded += HandleRewardedAdLoaded;

        //this.rewardAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;

        this.rewardAd.OnAdOpening += HandleRewardedAdOpening;
        this.rewardAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        rewardAd.LoadAd(request);
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("ad was load");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        Debug.Log("ad was fail");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("ad was open");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("ad was not watch");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Ad closed");
        RequestReward();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.Log("ad earned");
        string type = args.Type;
        double amount = args.Amount;
        gameHandle.isPlayerHasReward = true;
    }
    public void ShowRewardAd()
    {
        if (this.rewardAd.IsLoaded())
        {
            this.rewardAd.Show();
        }
    }
}
