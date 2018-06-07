using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnlargeReadingStrategy : ReadingStrategy {

    private Image circle;
    private Sprite circleSprite;
    private float speed = 0.1f;
    private float dropSpeed = 0.06f;

    public EnlargeReadingStrategy(float th, Sprite c) : base(th) {
        circle = GameObject.Find ("Circle").GetComponent<Image> ();
        circleSprite = c;
    }

    public override void init () {
        circle.transform.localScale = Vector3.zero;
        circle.sprite = circleSprite;
        circle.fillAmount = 1;
        power = 0;
    }
    public override void readMind (int value) {
        if (value > threshold) {
            power += speed * value;
        }
        power -= dropSpeed * power;
        power = Mathf.Max (Mathf.Min (power, 100), 0);
        circle.transform.localScale = Vector3.one * power / 100;
    }
}
