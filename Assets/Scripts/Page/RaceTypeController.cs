using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTypeController : MonoBehaviour {

    private CanvasGroup Race;

    void Awake()
    {
        Race = GetComponent<CanvasGroup>();
    }

    public void ShowRace()
    {
        Race.alpha = 1;
        Race.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
    }

    public void HideRace()
    {
        Race.alpha = 0;
        Race.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }

    public void OnArcadeClick()
    {
        SceneManager.instance.CurrentRaceType = SceneManager.RaceType.Arcade;
        HideRace();
        SceneManager.instance.LevelController.ShowLevel();
    }

    public void OnEndlessClick()
    {
        SceneManager.instance.CurrentRaceType = SceneManager.RaceType.Endless;
        HideRace();
        SceneManager.instance.PlayGameController.ShowPlayGame();
    }

    public void OnBackClick()
    {
        HideRace();
        SceneManager.instance.HomeController.ShowHome();
    }
}
