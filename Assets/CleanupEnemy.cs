using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupEnemy : MonoBehaviour {
    public float killTimer;
	// Use this for initialization
	void Start () {
        killTimer = 10f;	
	}
	
	// Update is called once per frame
	void Update () {
	    if (killTimer > 0) {
            killTimer -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
	}
}
