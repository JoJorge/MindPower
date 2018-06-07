using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagicMissle : MagicMissle {

    [SerializeField] private GameObject explosion;

    public override void Start () {
        base.Start ();
    } 

    protected override void explode () {
        float range = power / 20 + 3;

        GameObject exp = GameObject.Instantiate (explosion, transform.position, Quaternion.identity);
        exp.transform.localScale = Vector3.one * range;
    }

}
