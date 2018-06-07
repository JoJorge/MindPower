﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicMissle : MagicMissle {

    [SerializeField] private GameObject explosion;

    public override void Start () {
        base.Start ();
    } 

    protected override void explode () {
        float range = power / 20 + 3;
        float damage = power;

        GameObject exp = GameObject.Instantiate (explosion, transform.position, Quaternion.identity);
        exp.transform.localScale = Vector3.one * range;

        //TODO: give damage to zombies in range
    }
}
