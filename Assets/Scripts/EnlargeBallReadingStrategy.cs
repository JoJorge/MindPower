using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeBallReadingStrategy : ReadingStrategy {

    private GameObject ball;
    private float speed = 0.2f;
    private float dropSpeed = 0.08f;
    private float powerTh = 30;
    private float minBallSize;

    public EnlargeBallReadingStrategy(float th, GameObject b, float mbs) : base(th) {
        ball = b;
        ball = GameObject.Instantiate (ball, Player.Instance.transform.Find("BallPosition"));
        ball.transform.localScale = Vector3.one;
        ball.SetActive (false);
        minBallSize = mbs;
    }

    public override float getResult () {
        if (power < minBallSize)
            return 0;
        return base.getResult ();
    }
    public override void init () {
        ball.SetActive (true);
        ball.transform.localScale = Vector3.zero;
        power = 0;
    }
    public override void close () {
        ball.SetActive (false);
    }
    public override void readMind (int value) {
        if (value > threshold) {
            power += speed * value;
        }
        power -= dropSpeed * power;
        power = Mathf.Max (Mathf.Min (power, 100), 0);
        ball.transform.localScale = Vector3.one * power / 100;
    }
}
