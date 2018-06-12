using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance{ 
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager> ();
                if (instance == null) {
                    GameObject obj = new GameObject ("GameManager");
                    instance = obj.AddComponent<GameManager> ();
                }
            }

            return instance;
        }
    }

    #region Variables
    [SerializeField] private MainController mainController;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Text scoreText;
    private int score;
    #endregion

    #region Functions
    public void startGame() {
        mainController.startControl ();
        enemySpawner.startSpawn ();
        score = 0;
    }
    public void gameOver() {
        mainController.stopControl ();
        enemySpawner.stopSpawn ();
        restartButton.SetActive (true);
    }
    public void restartGame() {
        mainController.startControl ();
        Player.Instance.reset ();
        enemySpawner.destroySpawned ();
        enemySpawner.startSpawn ();
        score = 0;
        scoreText.text = "Score: " + score;
    }
    public void addScore(int n) {
        score += n;
        scoreText.text = "Score: " + score;
    }
    #endregion
}
