using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour {

    private bool reading;
    // TODO: ReadingStrategy
    private bool completeness;
    private float power;
    private GameObject orbCore;

	void Start () {
        reading = false;
        completeness = false;
        power = 0;
	}
	
	void Update () {
		
	}

    public bool isReading() {
        return reading;
    }
    // TODO
    public void setReadingStrategy() {
    }
    public void startReading(GameObject core) {
        reading = true;
        orbCore = core;
        // TODO: start reading strategy
    }
    public void endReading() {
        reading = false;
        orbCore = null;
        // TODO: stop reading strategy
        if (completeness) {
            shoot (power);
        }
    }
    // TODO
    private void shoot(float power) {
    }
}
