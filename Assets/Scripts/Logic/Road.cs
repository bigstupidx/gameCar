using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public Sprite Road1, Road2;
    public SpriteRenderer SpriteRoad1, SpriteRoad2;
    public float BoundLeft, BoundRight, BoundTop, BoundBottom;


    void Awake()
    {
        //InitRoad();
    }

	void Start () {
		
	}

    public void ChangeRoad(int road)
    {
        if(road ==1)
        {
            SpriteRoad1.sprite = Road1;
            SpriteRoad2.sprite = Road1;
        }
        else
        {
            SpriteRoad1.sprite = Road2;
            SpriteRoad2.sprite = Road2;
        }
    }

    public void InitRoad()
    {
        BoundLeft = -(SpriteRoad1.size.x / 2);
        BoundRight = -BoundLeft;
        BoundTop = (SpriteRoad1.size.y / 2);
        BoundBottom = -BoundTop;
        SpriteRoad1.gameObject.transform.position = new Vector3(0, 0, 0);
        SpriteRoad2.gameObject.transform.position = new Vector3(0, 2 * BoundTop, 0);
    }

    public void Run()
    {

    }
}
