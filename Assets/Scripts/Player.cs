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

    #region Variables
    [SerializeField] private int HP;
    private int maxHP;
    private bool died;
    #endregion

    #region Behaviours
    void Start () {
        if (Player.Instance != this) {
            Destroy (this);
        }
        maxHP = HP;
        died = false;
	}
    #endregion

    #region Functions
    public void getDamage(int damage) {
        HP -= damage;
        if (HP <= 0 && !died) {
            die ();
        }
    }
    public void reset() {
        HP = maxHP;
        died = false;
    }
    private void die() {
        died = true;
        GameManager.Instance.gameOver ();
    }
    #endregion

}
