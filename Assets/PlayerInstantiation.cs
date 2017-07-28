using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiation : MonoBehaviour {

    BoxCollider2D coll;
	// Use this for initialization
	void Start () {
        coll = gameObject.AddComponent<BoxCollider2D>();
        coll.size = new Vector2(0.1015f, 0.1491f);
        //Coll.offset = new Vector2(9.5553f, 0.0151f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
