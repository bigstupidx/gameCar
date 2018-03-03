using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageController : MonoBehaviour {

    private CanvasGroup Gara;

    public List<Sprite> ListCar = new List<Sprite>();
    public Image Car;
    public int CurrentCar = 0;
    public Text Money;

    void Awake()
    {
        Gara = GetComponent<CanvasGroup>();
    }

    public void ShowGara()
    {
        Gara.alpha = 1;
        Gara.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
        CurrentCar = SceneManager.instance.GetCar();
        Car.sprite = ListCar[CurrentCar];
    }

    public void HideGara()
    {
        Gara.alpha = 0;
        Gara.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }

    public void OnSwitchClick(bool isBack)
    {
        if (isBack)
        {
            CurrentCar--;
        }
        else
        {
            CurrentCar++;
        }

        if (CurrentCar < 0)
            CurrentCar = 2;
        else if (CurrentCar > 2)
            CurrentCar = 0;

        Car.sprite = ListCar[CurrentCar];
        SceneManager.instance.SetCar(CurrentCar);
    }

    public void OnBackClick()
    {
        HideGara();
        SceneManager.instance.HomeController.ShowHome();
    }

    public void OnRaceClick()
    {
        HideGara();
        SceneManager.instance.LevelController.ShowLevel();
    }

    public void OnUpdateSpeed()
    {
        SceneManager.instance.UpdateCar(1, 0, 0);
    }

    public void OnUpdateNitro()
    {
        SceneManager.instance.UpdateCar(0, 0, 1);
    }

    public void OnUpdateGas()
    {
        SceneManager.instance.UpdateCar(0, 1, 0);
    }

    public void OnSelectCar(int car)
    {
        CurrentCar = car;
        SceneManager.instance.SetCar(car);
    }
}
