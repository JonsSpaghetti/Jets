using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// To prevent rotation of child bullets w/ parent transform.
/// </summary>
public class FixRotation : MonoBehaviour {
    
    Quaternion rotation;
    void Awake() {
        rotation = transform.rotation;
    }
    void LateUpdate() {
        transform.rotation = rotation;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotation = transform.rotation;
	}


}
