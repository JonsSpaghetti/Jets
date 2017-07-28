using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public int score;

	// Use this for initialization
	void Start () {
        score = 0;		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.FindGameObjectWithTag("UIScore").GetComponent<Text>().text = "Score: " + score;
	}

    public void IncreaseScore(int amount) {
        score += amount;
    }
}
