using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private static Player instance;
    public static Player Instance{ 
        get {
            if (instance == null) {
                instance = FindObjectOfType<Player> ();
                if (instance == null) {
                    GameObject obj = new GameObject ("Player");
                    instance = obj.AddComponent<Player> ();
                }
            }

            return instance;
        }
    }

    [SerializeField] private int HP;
    [SerializeField] private int nowHP;
    private bool died;

	// Use this for initialization
	void Start () {
        if (Player.Instance != this) {
            Destroy (this);
        }
        nowHP = HP;
        died = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getDamage(int damage) {
        nowHP -= damage;
        if (nowHP <= 0 && !died) {
            die ();
        }
    }
    public void reset() {
        nowHP = HP;
        died = false;
    }
    private void die() {
        died = true;
        GameManager.Instance.gameOver ();
    }

}
