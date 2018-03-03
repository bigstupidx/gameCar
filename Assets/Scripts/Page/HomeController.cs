using UnityEngine;

public class HomeController : MonoBehaviour {

    private CanvasGroup Home;

    void Awake()
    {
        Home = GetComponent<CanvasGroup>();
    }

    public void ShowHome()
    {
        Home.alpha = 1;
        Home.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
    }

    public void HideHome()
    {
        Home.alpha = 0;
        Home.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }

    public void OnPlayClick()
    {
        HideHome();
        //SceneManager.instance.LevelController.ShowLevel();
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
    }

    public void OnRateClick()
    {
        //SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier + "");
#endif
    }

    public void OnMoreGameClick()
    {
        //SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
#if UNITY_ANDROID
        Application.OpenURL("market://search?id=" + Application.companyName + "");
#endif
    }

    public void OnShareClick()
    {
        //SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);

    }


    public void OnRaceClick()
    {
        HideHome();
        SceneManager.instance.RaceTypeController.ShowRace();
    }

    public void OnGarageClick()
    {

    }
}
