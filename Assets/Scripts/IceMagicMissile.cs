using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagicMissile : MagicMissile {

    [SerializeField] private GameObject explosion;

    public override void Start () {
        base.Start ();
    } 

    protected override void explode () {
        float range = 3 + power / 20;
        float stopTime = 5 + power / 20;

        GameObject exp = GameObject.Instantiate (explosion, transform.position, Quaternion.identity);
        exp.transform.localScale = Vector3.one * range;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders) {
            if (collider.CompareTag ("Enemy")) {
                Enemy enemy = collider.GetComponent<Enemy> ();
				if (enemy.isFreezing ()) {
					enemy.addFreezeTime (stopTime);
				}
				else {
					enemy.StartCoroutine (enemy.freeze (stopTime));
				}
            }
        }
    }

}
