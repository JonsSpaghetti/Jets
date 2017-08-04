using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public PrimaryFire fireScript;
    float delay;
    float cdTimer;
	// Use this for initialization
	void Start () {
        fireScript = GetComponent<PrimaryFire>();
        delay = 0.3f;
        cdTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            if (cdTimer <= 0) {
                cdTimer = delay;
                fireScript.Shoot();
            }
        }
        cdTimer -= Time.deltaTime;
    }
}
