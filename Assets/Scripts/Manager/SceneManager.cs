using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class SceneManager : MonoBehaviour
{
    public const string USER_DATA = "USER_DATA";
    public const string TIP_DATA = "TIP_DATA";
    public const string RATE_DATA = "RATE_DATA";
    public const string LEVEL_RATING = "LEVEL_RATING";

    // 0 : White ---- 1 : Orange ---- 2 : Red
    public const string CURRENT_CAR = "CURRENT_CAR";
    public const string UNLOCKED_CAR = "UNLOCKED_CAR";
    public const string CASH = "CASH";

    private float widthSize = 0f;

    public int MaxLevel = 0;
    public int LastLevel = 0;

    public AdMobBanner Banner;
    public AdMobBannerInterstitial InterStitial;
    public float TimeShowInterstitial = 90f;
    private float _preTimeShowAds = 0f;
    bool isShowInterstitial = false;

    public static SceneManager instance;

    public enum RaceType
    {
        Arcade,
        Endless
    }

    public RaceType CurrentRaceType = RaceType.Arcade;

    void Awake()
    {
        MaxLevel = 0;
        SceneManager.instance = this;

        if (!PlayerPrefs.HasKey(RATE_DATA))
        {
            PlayerPrefs.SetInt(RATE_DATA, 0);
            PlayerPrefs.SetInt(LEVEL_RATING, 0);
        }

        if (!PlayerPrefs.HasKey(USER_DATA))
        {
            CreateNewDataUser();
        }

        GoogleMobileAd.OnInterstitialClosed += OnHideIntertitialBanner;
        GoogleMobileAd.OnInterstitialLoaded += OnLoadIntertitialBannerSuccess;
    }

    bool isLoadBanner = false;
    public void OnLoadIntertitialBannerSuccess()
    {
        isLoadBanner = true;
    
    }

    public void LoadNewIntertitialBanner()
    {
        GoogleMobileAd.LoadInterstitialAd();
    }

    public enum ObjectManager
    {
        MainMenu,
        Message,
        PlayGame,
        Option,
    }

    public enum ObjectDialog
    {
        WinLose,
    }


    public enum TypeInit
    {
        Immediately,
        Delays,
    }

    private GameObject preScene;
    private GameObject preDialog;

    public HomeController HomeController;
    public RaceTypeController RaceTypeController;
    public LevelController LevelController;
    public PlayGameController PlayGameController;
    public GarageController GarageController;

    void Start()
    {
        // Start game UI
        HomeController.ShowHome();
        RaceTypeController.HideRace();
        LevelController.HideLevel();
        PlayGameController.HidePlayGame();
        GarageController.HideGara();
    }

    void CreateNewDataUser()
    {
        string userData = "";
        // => lock => star => score
        for (int j = 0; j < MaxLevel; j++)
        {
            if (j != 0)
            {
                userData += "+0-0-0";
            }
            else
            {
                userData += "+1-0-0";
            }
        }
        PlayerPrefs.SetString(USER_DATA, userData);
    }

    public bool IsOffTip()
    {
        if(!PlayerPrefs.HasKey(TIP_DATA))
        {
            PlayerPrefs.SetString(TIP_DATA, "FALSE");
            return true;
        }

        if (PlayerPrefs.GetString(TIP_DATA) == "TRUE")
        {
            return true;
        }

        return false;
    }

    public void SetTip()
    {
        if (IsOffTip())
        {
            PlayerPrefs.SetString(TIP_DATA, "FALSE");
        }
        else
        {
            PlayerPrefs.SetString(TIP_DATA, "TRUE");
        }
    }

    private bool lastBanner = false;
    public void ShowBanner()
    { 
        Banner.ShowBanner();
    }

    public void HideBanner()
    {
        Banner.HideBanner();
    }

    public void ShowIntertitialBanner()
    {
        if (isLoadBanner && isShowInterstitial)
        {
            Banner.HideBanner();
            InterStitial.ShowBanner();
        }
    }

    public void OnHideIntertitialBanner()
    {
        ShowBanner();
        isShowInterstitial = false;
        isLoadBanner = false;
        LoadNewIntertitialBanner();
    }

    void Update()
    {
        if(!isShowInterstitial)
        {
            _preTimeShowAds += Time.deltaTime;
            if(_preTimeShowAds >= TimeShowInterstitial)
            {
                _preTimeShowAds = 0;
                isShowInterstitial = true;
            }
        }
    }

    public void SetCar(int car)
    {
        PlayerPrefs.SetInt(CURRENT_CAR, car);
    }

    public int GetCar()
    {
        return PlayerPrefs.GetInt(CURRENT_CAR);
    }

    public void UpdateCar(int speed, int gas, int nitro)
    {
        string carData = PlayerPrefs.GetString(GetCar().ToString());

        if (string.IsNullOrEmpty(carData))
            carData = "1-1-1";

        var part = carData.Split('-');

        carData = "";

        carData = (int.Parse(part[0].ToString()) + speed) + "-";
        carData += (int.Parse(part[1].ToString()) + gas) + "-";
        carData += (int.Parse(part[1].ToString()) + nitro);

        PlayerPrefs.SetString(GetCar().ToString(), carData);
    }

    public void GetUnlockedCar()
    {
        
    }
}
