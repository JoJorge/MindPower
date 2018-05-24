using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveHorizontal;
	public float moveVertical;
	public float speed = 5;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");

		rb.AddForce(new Vector3(moveHorizontal,0f,moveVertical) * speed );
	}
}
