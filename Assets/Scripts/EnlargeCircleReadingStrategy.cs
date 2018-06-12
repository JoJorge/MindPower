using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnlargeCircleReadingStrategy : ReadingStrategy {

    private Image circle;
    private Sprite circleSprite;
    private float speed = 0.2f;
    private float dropSpeed = 0.08f;

    public EnlargeCircleReadingStrategy(float th, Sprite c) : base(th) {
        circle = GameObject.Find("Canvas").transform.Find("Circle").GetComponent<Image> ();
        circleSprite = c;
    }

    public override void init () {
        circle.transform.localScale = Vector3.zero;
        circle.sprite = circleSprite;
        circle.fillAmount = 1;
        power = 0;
    }
    public override void close () {
        circle.transform.localScale = Vector3.zero;
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
