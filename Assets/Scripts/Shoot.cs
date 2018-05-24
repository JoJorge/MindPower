using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject Fire_Ball, Ice_Ball;
	public float Shoot_Pos;

	private float direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J))
		{
			Instantiate (Fire_Ball, (this.gameObject.transform.position + new Vector3(Shoot_Pos,0f,0f)), this.gameObject.transform.rotation);
		}
	}
}
