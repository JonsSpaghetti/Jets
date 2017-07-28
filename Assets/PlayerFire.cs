using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public PrimaryFire fireScript;
	// Use this for initialization
	void Start () {
        fireScript = GetComponent<PrimaryFire>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            fireScript.Shoot();
        }
    }
}
