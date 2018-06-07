using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicMissle : MagicMissle {

    [SerializeField] private GameObject explosion;

    public override void Start () {
        base.Start ();
    } 

    protected override void explode () {
        float range = Mathf.Max(5, power / 10);
        float damage = power;

        GameObject exp = GameObject.Instantiate (explosion, transform.position, Quaternion.identity);

    }
}
