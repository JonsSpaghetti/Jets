using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour {

    public Rigidbody2D rigid;
    public float speed;
    //For testing
    //public float horizontal;
    //public float vertical;


	// Use this for initialization
	void Start () {
        //Create rigidbody 2D
        rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.mass = 0.3f;
        rigid.drag = 0.33f;
        speed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(horizontal) > 0) {
            //We're moving horizontally
            rigid.AddForce(new Vector2(horizontal, 0) * speed);
        }	
        if(Mathf.Abs(vertical) > 0) {
            //Moving vertically
            rigid.AddForce(new Vector2(0, vertical) * speed);
        }
        //TODO - add movement to flip player to other side of screen if they go out of bounds.
	}
}
