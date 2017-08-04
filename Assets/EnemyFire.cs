using System.Collections;
using System.Collections.Generic;

using UnityEngine;

//TODO - Create IFireable interface - set EnemyFire and PlayerFire as "Firables" - Create ShipController to do firing etc..
public class EnemyFire : MonoBehaviour {
    public float fireTimer;
    public float fireCd;
    public float fireCdTimer;
    public PrimaryFire FireScript;
    public bool visible;
    // Use this for initialization
    void Start() {
        fireTimer = 1.0f;
        fireCd = 1f;
        fireCdTimer = 0;
        FireScript = GetComponent<PrimaryFire>();
    }

    // Update is called once per frame
    void Update() {
        if (visible) {
            if (fireTimer > 0) {
                fireTimer -= Time.deltaTime;
            }
            else {
                if (fireTimer < 0) {
                    FireScript.Shoot();
                }
                fireTimer = Random.value;
            }
        }
    }

    void OnWillRenderObject() {
        visible = true;
    }
}
