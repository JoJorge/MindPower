using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public float Destroy_Time;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyGameObject", Destroy_Time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}
}
