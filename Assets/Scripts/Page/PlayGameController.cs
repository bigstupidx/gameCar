using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameController : MonoBehaviour {

    private CanvasGroup PlayGame;

    void Awake()
    {
        PlayGame = GetComponent<CanvasGroup>();
    }

    public void ShowPlayGame()
    {
        PlayGame.alpha = 1;
        PlayGame.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
    }

    public void HidePlayGame()
    {
        PlayGame.alpha = 0;
        PlayGame.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }
}
