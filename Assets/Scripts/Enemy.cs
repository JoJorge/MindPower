using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {

    protected int HP = 50;
    [SerializeField] protected float speed;
    protected int power = 10;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody> ().velocity = Vector3.back * speed;
	}

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag ("Player")) {
            attack ();
        }
    }

    public void getDamage(int damage) {
        HP -= damage;
        if (HP <= 0) {
            die ();
        }
    }
    public IEnumerator stop(float stopTime) {
        GetComponent<Rigidbody> ().velocity = Vector3.zero;
        yield return new WaitForSecondsRealtime (stopTime);
        GetComponent<Rigidbody> ().velocity = Vector3.back * speed;
        yield return null;
    }
    protected void die() {
        Destroy (gameObject);
        GameManager.Instance.addScore (1);
    }
    protected void attack() {
        Player.Instance.getDamage(power);
        // disappear after attacking
        Destroy(gameObject);
    }
}
