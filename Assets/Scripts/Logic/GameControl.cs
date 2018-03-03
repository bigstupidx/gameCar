using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl Instance;
    public Road Road;
    public Car Car;
    void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        Road.InitRoad();
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
