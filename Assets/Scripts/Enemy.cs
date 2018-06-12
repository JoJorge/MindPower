using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {

    #region Variables
    protected int HP = 50;
    [SerializeField] protected float speed;
    protected int power = 10;
	protected float freezedTime;
	protected bool freezing;
    [SerializeField] private Material frozenMat;
    private Material originMat;
    #endregion

    #region Behaviours
	void Start () {
        GetComponent<Rigidbody> ().velocity = Vector3.back * speed;
		freezedTime = 0.0f;
		freezing = false;
        originMat = GetComponent<MeshRenderer> ().material;
	}
		
    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag ("Player")) {
            attack ();
        }
    }
    #endregion

    #region Function
    public void getDamage(int damage) {
        HP -= damage;
        if (HP <= 0) {
            die ();
        }
    }
	public bool isFreezing() {
		return freezing;
	}
	public void addFreezeTime(float time) {
		freezedTime += time;
	}
    public IEnumerator freeze(float stopTime) {
		freezing = true;
		freezedTime = stopTime;
        GetComponent<Rigidbody> ().velocity = Vector3.zero;
        GetComponent<MeshRenderer> ().material = frozenMat;
		while (freezedTime > 0) {
			float tmp = freezedTime;
			freezedTime = 0;
			yield return new WaitForSecondsRealtime (tmp);
		}
        GetComponent<MeshRenderer> ().material = originMat;
        GetComponent<Rigidbody> ().velocity = Vector3.back * speed;
		freezing = false;
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
    #endregion
}
