using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {

    public static AdManager instance;
    public BannerView bannerView;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Start(){ }

    public void showBanner()
    {
        string adUnitId = "ca-app-pub-3886265077707229~4464731145";
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        
    }

    public void hideBanner()
    {
        bannerView.Hide();
    }


}

