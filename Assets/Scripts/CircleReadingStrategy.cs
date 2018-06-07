using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleReadingStrategy : ReadingStrategy {

    private bool completeness;
    private Image circle;
    private Sprite circleSprite;
    private float lowThreshold;
    private float speed = 0.1f;
    private bool completing;

    public CircleReadingStrategy(float th, Sprite c) : base(th){
        circle = GameObject.FindObjectOfType<Image>().GetComponent<Image> ();
        circleSprite = c;
        lowThreshold = th - 10;
        completeness = false;
        completing = false;
    }
    public override float getResult () {
        if (!completeness) {
            return 0;
        }
        else {
            return base.getResult ();
        }
    }
    public override void init () {
        completeness = false;
        completing = false;
        circle.sprite = circleSprite;
        circle.fillAmount = 0;
    }
    public override void readMind (int value) {
        if (completeness) {
            return;
        }
        if (!completing) {
            if (value >= threshold) {
                completing = true;
            }
        }
        else {
            if (value >= lowThreshold) {
                circle.fillAmount += speed;
                if (circle.fillAmount == 1) {
                    completeness = true;
                    power = 200;
                }
            }
            else {
                completing = false;
                circle.fillAmount = 0;
            }
        }
    }
}
