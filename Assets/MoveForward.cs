using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float Speed;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        Speed = 3f;
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Vector2 rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //Debug.Log(transform.rotation * new Vector3(0, 1, 1));
        //Debug.DrawLine(transform.position, transform.rotation * new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //Debug.DrawLine(transform.position, transform.rotation * new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z),Color.green);
        transform.position = Vector3.MoveTowards(transform.position, transform.rotation * new Vector3(transform.position.x, transform.position.y + 10000, transform.position.z), Time.deltaTime * Speed);
    }
}
