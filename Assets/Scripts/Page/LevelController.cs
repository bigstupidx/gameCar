using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private CanvasGroup Level;

    void Awake()
    {
        Level = GetComponent<CanvasGroup>();
    }

    public void ShowLevel()
    {
        Level.alpha = 1;
        Level.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
    }

    public void HideLevel()
    {
        Level.alpha = 0;
        Level.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }
}
