using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsPlayer : MonoBehaviour {

    public  GameObject player;
    public float turnRate;
    Transform target;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        turnRate = 80f;
	}
	
	// Update is called once per frame
	void Update () {

        if (player != null) {
            target = player.transform;
            //If above your target, point at them.
            if (transform.position.y > target.position.y) {
                //New way
                Vector3 targetVector = target.position - transform.position;
                float angle = (Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg) - 90;
                Quaternion qtrn = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qtrn, Time.deltaTime * turnRate);


                ////Old way
                //target.position = new Vector3(target.position.x, target.position.y, transform.position.z);
                //transform.up = target.position - transform.position;
            }
        }
        else {
            PointDown();
        }
	}

    public void PointDown() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), turnRate * Time.deltaTime);
    }
}
