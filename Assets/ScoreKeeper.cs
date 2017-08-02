using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public int score;
    GameManager gameManager;

	// Use this for initialization
	void Start () {
        score = 0;
        gameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.gOver) {
            GameObject.FindGameObjectWithTag("UIScore").GetComponent<Text>().text = "Score: " + score;
        }
	}

    public void IncreaseScore(int amount) {
        score += amount;
    }
}
