using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public Sprite[] CarSprite;
    public SpriteRenderer SpriteRender;
    public float Speed;
    public float NitroSpeed;

    void Awake()
    {
        if(SpriteRender == null)
        {
            SpriteRender.GetComponent<SpriteRenderer>();
        }
    }

   public void Init(Vector3 pos)
    {
        LeanTween.move(this.gameObject, pos, 0.1f);
    }

   public void Init(Vector3 pos, int carIndex)
   {
       SpriteRender.sprite = CarSprite[carIndex];
       LeanTween.move(this.gameObject, pos, 0.1f);
   }


}
