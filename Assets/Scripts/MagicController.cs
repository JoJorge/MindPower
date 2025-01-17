﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour {

    #region Variables
    private bool reading;
    private MagicMissile.MagicType readingMagicType;
    private Dictionary<MagicMissile.MagicType, ReadingStrategy> type2strategy;
    [SerializeField] private float fireThresholds;
    [SerializeField] private float iceThresholds;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject iceball;
    private GameObject orbCore;
    private TGCConnectionController controller;
    #endregion

    #region Behaviours
    public void Start () {
        reading = false;
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        type2strategy = new Dictionary<MagicMissile.MagicType, ReadingStrategy> ();


        Sprite circle = Resources.Load<Sprite> ("FireCircle");
        type2strategy.Add (MagicMissile.MagicType.Fire, new CircleReadingStrategy(fireThresholds, circle, 50));

        /*
        GameObject ball = Resources.Load<GameObject> ("FireballEffect");
        type2strategy.Add (MagicMissile.MagicType.Fire, new EnlargeBallReadingStrategy(fireThresholds, ball, 20));
        */
        /*
        circle = Resources.Load<Sprite> ("IceCircle");
        type2strategy.Add (MagicMissile.MagicType.Ice, new EnlargeCircleReadingStrategy(iceThresholds, circle));
        */
        /*
        Sprite circle = Resources.Load<Sprite> ("IceCircle");
        type2strategy.Add (MagicMissile.MagicType.Ice, new CircleReadingStrategy(iceThresholds, circle, 80));
        */

        GameObject ball = Resources.Load<GameObject> ("IceballEffect");
        type2strategy.Add (MagicMissile.MagicType.Ice, new EnlargeBallReadingStrategy(iceThresholds, ball, 20));

	}
    #endregion

    #region Functions
    public bool isReading() {
        return reading;
    }
    public void setReadingStrategy(MagicMissile.MagicType type, ReadingStrategy rs) {
        type2strategy [type] = rs;
    }
    public void startReading(MagicMissile.MagicType type, GameObject core) {
        reading = true;
        orbCore = core;
        readingMagicType = type;
        type2strategy [type].init ();
        if (type == MagicMissile.MagicType.Fire) {    
            controller.UpdateAttentionEvent += type2strategy [type].readMind;
            controller.UpdateAttentionEvent += changeOrb;
        }
        else {
            controller.UpdateMeditationEvent += type2strategy [type].readMind;
            controller.UpdateMeditationEvent += changeOrb;
        }
    }
    public void endReading() {
        reading = false;
        orbCore = null;
        float power = type2strategy[readingMagicType].getResult();
        if (power > 0) {
            shoot (power);
        }
        type2strategy [readingMagicType].close ();
        if (readingMagicType == MagicMissile.MagicType.Fire) {
            
            controller.UpdateAttentionEvent -= type2strategy [readingMagicType].readMind;
            controller.UpdateAttentionEvent -= changeOrb;
        }
        else {
            controller.UpdateMeditationEvent -= type2strategy [readingMagicType].readMind;
            controller.UpdateMeditationEvent -= changeOrb;
        }
    }
    private void shoot(float power) {
        if (readingMagicType == MagicMissile.MagicType.Fire) {
            GameObject missle = GameObject.Instantiate (fireball, Camera.main.transform.position + Vector3.down + Vector3.forward, Quaternion.identity);
            missle.GetComponent<FireMagicMissile> ().setPower (power);
        }
        else {
            GameObject missle = GameObject.Instantiate (iceball, Camera.main.transform.position + 1.2f * Vector3.down, Quaternion.identity);
            missle.GetComponent<IceMagicMissile> ().setPower (power);
        }
    }
    public void directShoot() {
        GameObject missle = GameObject.Instantiate (iceball, Camera.main.transform.position + Vector3.down + Vector3.forward, Quaternion.identity);
        missle.GetComponent<IceMagicMissile> ().setPower (30);
    }
    private void changeOrb(int value) {
        orbCore.transform.localScale = Vector3.one * (float)value / 100 * 3;
    }
    #endregion
}
