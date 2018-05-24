using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlySpeed : MonoBehaviour {

	public float Fly_Speed;
	public Text Score_Text;

	public GameObject Explosion;
	public AudioClip sExplosion;

	//private int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += new Vector3 (Fly_Speed,0f,0f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
			GameObject New_Explosion = (GameObject)Instantiate (Explosion, transform.position, Quaternion.identity);
			//score++;
			//Score_Text.text = "Score : " + score;
			//if (score >= 12) {
				//win
			//}
		}

	}
}
