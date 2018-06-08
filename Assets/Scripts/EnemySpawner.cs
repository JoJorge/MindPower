﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // in second
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;
    private float nowInterval;
    [SerializeField] private GameObject enemy;
    private float roadWidth = 4;
    private bool spawning;

	// Use this for initialization
	void Start () {
        Debug.Assert (minInterval <= maxInterval);
        spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawning) {
            nowInterval -= Time.deltaTime;
            if (nowInterval <= 0) {
                GameObject.Instantiate (enemy, transform.position + Vector3.right * Random.Range (-roadWidth / 2, roadWidth / 2), Quaternion.identity, transform.parent);
                nowInterval = Random.Range (minInterval, maxInterval);
            }
        }
	}

    public void startSpawn() {
        nowInterval = Random.Range (minInterval, maxInterval);
        spawning = true;
    }
    public void stopSpawn() {
        spawning = false;
    }
    public void destroySpawned() {
        for (int i = 0; i < transform.parent.childCount; i++) {
            GameObject obj = transform.parent.GetChild (i).gameObject;
            if (obj.CompareTag ("Enemy")) {
                Destroy (obj);
            }
        }
    }
}
