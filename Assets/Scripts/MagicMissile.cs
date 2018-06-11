using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class MagicMissile : MonoBehaviour {

    public enum MagicType{Fire, Ice};
    protected MagicType type;
    protected float speed = 15f;
    protected float power;

    public virtual void Start() {
        Rigidbody rigid = GetComponent<Rigidbody> ();
        rigid.velocity = Vector3.forward * speed;
    }
    public void setPower(float p) {
        power = p;
    }
    protected abstract void explode();
    public void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Wall")) {
            explode ();
            Destroy (gameObject);
        }
    }
}
