using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System;

public class Ads : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{

    //private string appId = "ca-app-pub-1526029993586587~8304814826";
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd_FreeChest;
    private RewardedAd rewardedAd_X2Click;
    private RewardedAd rewardedAd_ExUpdate;


    private string adUnitId_FreeChest = "ca-app-pub-8586425167367042/2170340562";
    private string adUnitId_Banner = "ca-app-pub-8586425167367042/4697547547";
    private string adUnitId_X2Click = "ca-app-pub-8586425167367042/4716419336";
    private string adUnitId_ExUpdate = "ca-app-pub-8586425167367042/8983160927";
    private string adUnitId_AdHeroNative = "ca-app-pub-1526029993586587/1439323846";
    private string adUnitId_MejStanica = "ca-app-pub-8586425167367042/3384465876";





    #region UnityAds
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOsGameId;
    [SerializeField] bool _testMode;
    private string _gameId;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    private string _adUnitIdInterstitial = "Interstitial_Android";
    private string _adUnitIdRewarded = "Rewarded_Android";
    private string _adUnitIdBanner = "Banner_Android";
    #endregion

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        if (status() == 0)
        {
            this.RequestBanner();
        }



        CreateAd_X2Click();
        CreateAd_FreeChest();
        CreateAd_ExUpdate();
        RequestInterstitial();




        InitializeAds();
        LoadAdInterstitial();
        LoadAdRewarded();
        Advertisement.Banner.SetPosition(_bannerPosition);
        LoadBanner();
        //ShowBannerAd();
    }
    int status()
    {
        return GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Status;
    }
    public void DestrBanner()
    {
        this.bannerView.Destroy();
    }
    #region UnityAds
    public void LoadBanner()
    {
        Advertisement.Banner.Load(_adUnitIdBanner);
    }
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
    }
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }
    void ShowBannerAd()
    {
        if (status() == 0)
        {
            Advertisement.Banner.Show(_adUnitIdBanner);
            LoadBanner();
        }

    }

    void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }






    public void InitializeAds()
    {
        _gameId = _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }





    public void LoadAdInterstitial()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitIdInterstitial);
        Advertisement.Load(_adUnitIdInterstitial, this);
    }

    public void ShowAdInterstitial()
    {
        if (status() == 0)
        {
            // Note that if the ad content wasn't previously loaded, this method will fail
            Debug.Log("Showing Ad: " + _adUnitIdInterstitial);
            Advertisement.Show(_adUnitIdInterstitial, this);
            LoadAdInterstitial();
        }
    }



    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }






    //Rewarded
    public void LoadAdRewarded()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitIdRewarded);

        Advertisement.Load(_adUnitIdRewarded, this);
    }

    public void ShowAdRewarded()
    {
            Advertisement.Show(_adUnitIdRewarded);
            NoAds();
        LoadAdRewarded();
    }
    int q = 0;


    #endregion
    #region GoogleAdMob Ads
    public void CreateAd_X2Click()
    {
        this.rewardedAd_X2Click = new RewardedAd(adUnitId_X2Click);
        this.rewardedAd_X2Click.OnUserEarnedReward += X2ClickAcsess;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd_X2Click.LoadAd(request);
    }
    public void X2ClickAcsess(object sender, Reward args)
    {
        GameObject.FindGameObjectWithTag("ClickPanel").GetComponent<Click>().X2_click();
    }
    public void X2ClickReklama()
    {
        if (status() == 0)
        {
            if (this.rewardedAd_X2Click.IsLoaded())
            {
                this.rewardedAd_X2Click.Show();
            }
            else
            {
                q = 0;
                Debug.Log("Должен запустить UnityAds: " + q);
                ShowAdRewarded();
            }
            CreateAd_X2Click();
        }
        else
        {
            GameObject.FindGameObjectWithTag("ClickPanel").GetComponent<Click>().X2_click();
        }
    }


    public void CreateAd_FreeChest()
    {
        this.rewardedAd_FreeChest = new RewardedAd(adUnitId_FreeChest);
        this.rewardedAd_FreeChest.OnUserEarnedReward += FreeChestAcsess;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd_FreeChest.LoadAd(request);
    }
    [SerializeField] GameObject OpenCaseFreePanel;
    public void FreeChestAcsess(object sender, Reward args)
    {
        OpenCaseFreePanel.GetComponent<OpenCaseFree>().StartOpenBttn();
    }
    public void FreeChestReklama()
    {
        if (status() == 0)
        {
            if (this.rewardedAd_FreeChest.IsLoaded())
            {
                this.rewardedAd_FreeChest.Show();
            }
            else
            {
                q = 1;
                ShowAdRewarded();
            }
            CreateAd_FreeChest();
        }
        else
        {
            OpenCaseFreePanel.GetComponent<OpenCaseFree>().StartOpenBttn();
        }
    }


    public void CreateAd_ExUpdate()
    {
        this.rewardedAd_ExUpdate = new RewardedAd(adUnitId_X2Click);
        this.rewardedAd_ExUpdate.OnUserEarnedReward += ExUpdateAcsess;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd_ExUpdate.LoadAd(request);
    }
    public void ExUpdateAcsess(object sender, Reward args)
    {
        //Camera.main.GetComponent<OnClicker>().openAndClose_Menu_x3_yes();
    }
    public void ExUpdateReklama()
    {
        if (status() == 0)
        {
            if (this.rewardedAd_ExUpdate.IsLoaded())
            {
                this.rewardedAd_ExUpdate.Show();
            }
            else
            {
                q = 1;
                Debug.Log("Должен запустить UnityAds: " + q);
                ShowAdRewarded();
            }
            CreateAd_ExUpdate();
        }
        else
        {
            //Camera.main.GetComponent<OnClicker>().openAndClose_Menu_x3_yes();
        }
    }







    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = adUnitId_Banner;
#elif UNITY_IPHONE
            string adUnitId = adUnitId_Banner;
#else
            string adUnitId = adUnitId_Banner;
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build(); //30C702D2C05BA97E

            // Load the banner with the request.
            this.bannerView.LoadAd(request);
            this.bannerView.OnAdLoaded += this.HandleOnAdLoadedBan;
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
    }
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = adUnitId_MejStanica;
#elif UNITY_IPHONE
        string adUnitId = adUnitId_MejStanica;
#else
        string adUnitId = adUnitId_MejStanica;
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        this.interstitial.OnAdLoaded += HandleOnAdLoadedIn;
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        ShowBannerAd();
    }

    public void ShowStranica()
    {
        if (status() == 0)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
            else
            {
                ShowAdInterstitial();
            }
            RequestInterstitial();
        }
    }

    public void HandleOnAdLoadedIn(object sender, EventArgs args)
    {
        MonoBehaviour.print("Страничная");
    }
    public void HandleOnAdLoadedBan(object sender, EventArgs args)
    {
        MonoBehaviour.print("Банер");
    }



    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new NotImplementedException();
        Debug.Log($"Unity Ads Initialization Failed:- {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // throw new NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            switch (q)
            {
                case 0:
                    //x2Click
                    GameObject.FindGameObjectWithTag("ClickPanel").GetComponent<Click>().X2_click();
                    break;
                case 1:
                    //FreeChest
                    OpenCaseFreePanel.GetComponent<OpenCaseFree>().StartOpenBttn();
                    break;
                default:
                    break;
            }
        }
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new NotImplementedException();
    }



    #endregion
    void NoAds()
    {
        GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
        {
            ef.GetComponent<WrongStep>().SetText($"Реклама не готова");
        }
        else
        {
            ef.GetComponent<WrongStep>().SetText($"Ads no ready");
        }
    }
}


