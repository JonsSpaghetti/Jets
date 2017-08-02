using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    GameObject player;
    Texture gameOverTexture; //Set game over screen here

    public bool gOver;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

    void gameOver() {
        //GameOver logic - display "Game Over message" and restart game after button press/time limit.
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 25), "Retry")) {
            SceneManager.LoadScene("Jet");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 25, 150, 25), "Quit")) {
            Application.Quit();
        }
    }

    void OnGUI() {
        if(!player) {
            gOver = true;
            gameOver(); 
        }	
    }
}
