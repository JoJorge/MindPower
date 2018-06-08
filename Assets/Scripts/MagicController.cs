using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour {

    #region Variables
    private bool reading;
    private MagicMissle.MagicType readingMagicType;
    private Dictionary<MagicMissle.MagicType, ReadingStrategy> type2strategy;
    [SerializeField] private float fireThresholds;
    [SerializeField] private float iceThresholds;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject iceball;
    private GameObject orbCore;
    private TGCConnectionController controller;
    #endregion

    public void Start () {
        reading = false;
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        type2strategy = new Dictionary<MagicMissle.MagicType, ReadingStrategy> ();
        Sprite circle = Resources.Load<Sprite> ("FireCircle");
        type2strategy.Add (MagicMissle.MagicType.Fire, new CircleReadingStrategy(fireThresholds, circle));
        circle = Resources.Load<Sprite> ("IceCircle");
        type2strategy.Add (MagicMissle.MagicType.Ice, new EnlargeReadingStrategy(iceThresholds, circle));
	}

    #region Functions
    public bool isReading() {
        return reading;
    }
    public void setReadingStrategy(MagicMissle.MagicType type, ReadingStrategy rs) {
        type2strategy [type] = rs;
    }
    public void startReading(MagicMissle.MagicType type, GameObject core) {
        reading = true;
        orbCore = core;
        readingMagicType = type;
        type2strategy [type].init ();
        if (type == MagicMissle.MagicType.Fire) {    
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
        type2strategy [readingMagicType].init ();
        if (readingMagicType == MagicMissle.MagicType.Fire) {
            
            controller.UpdateAttentionEvent -= type2strategy [readingMagicType].readMind;
            controller.UpdateAttentionEvent -= changeOrb;
        }
        else {
            controller.UpdateMeditationEvent -= type2strategy [readingMagicType].readMind;
            controller.UpdateMeditationEvent -= changeOrb;
        }
    }
    private void shoot(float power) {
        if (readingMagicType == MagicMissle.MagicType.Fire) {
            GameObject missle = GameObject.Instantiate (fireball, Camera.main.transform.position + 1.2f * Vector3.down, Quaternion.identity);
            missle.GetComponent<FireMagicMissle> ().setPower (power);
        }
        else {
            GameObject missle = GameObject.Instantiate (iceball, Camera.main.transform.position + 1.2f * Vector3.down, Quaternion.identity);
            missle.GetComponent<IceMagicMissle> ().setPower (power);
        }
    }
    public void directShoot() {
        GameObject missle = GameObject.Instantiate (iceball, Camera.main.transform.position + 1.2f * Vector3.down, Quaternion.identity);
        missle.GetComponent<IceMagicMissle> ().setPower (30);
    }
    private void changeOrb(int value) {
        orbCore.transform.localScale = Vector3.one * (float)value / 100 * 3;
    }
    #endregion
}
