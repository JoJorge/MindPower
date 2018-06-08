using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicMissle : MagicMissle {

    [SerializeField] private GameObject explosion;

    public override void Start () {
        base.Start ();
    } 

    protected override void explode () {
        float range = 3 + power / 20;
        int damage = (int)power;

        GameObject exp = GameObject.Instantiate (explosion, transform.position, Quaternion.identity);
        exp.transform.localScale = Vector3.one * range;

        //TODO: give damage to zombies in range
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders) {
            if (collider.CompareTag ("Enemy")) {
                collider.GetComponent<Enemy> ().getDamage (damage);
            }
        }
    }
}
