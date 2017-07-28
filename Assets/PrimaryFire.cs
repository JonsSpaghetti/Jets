using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Get all Primary guns on a ship (empty child gameobjects just to monitor position - ship is parent).
/// Must be tagged as "PrimaryGun"
/// </summary>
public class PrimaryFire : MonoBehaviour {

    public List<Transform> guns;
    public Sprite bulletSprite;
    //prefab bullet to fire;
    public GameObject bullet;
    public float bulletSpeed;
    //public float Delay; //TODO - add delay to shooting
    public List<GameObject> bullets;

	// Use this for initialization
	void Start () {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform transform in children) {
            if(transform.gameObject.tag == "PrimaryGun") {
                guns.Add(transform);
            }

        } 
        //Use this later to optimize - have an array of bullets that we can pull from - reuse when off screen.
        InitializeBullets();
        
	}
	
	// Update is called once per frame
	void Update () {
        //TODO - Change this to somehow get called by a PlayerFire script, not just this.
        //TODO - Change to allow holding down space to fire - take advantage of Delay.
       
	}
    /// <summary>
    /// Create bullets at each gun transform (allowing for as many guns as we want)
    /// </summary>
    public void Shoot() {
        foreach (Transform Gun in guns) {
            GameObject newBullet = Instantiate(bullet, Gun );
            //newBullet.GetComponent<BulletInstantiation>().Initialize(BulletSprite, new Vector2(0, 1) * BulletSpeed);
            Vector2 bulletForce = transform.rotation * new Vector3(transform.position.x, transform.position.y +10000, transform.position.z);
            bulletForce.Normalize();
            newBullet.GetComponent<BulletInstantiation>().Initialize(bulletSprite, bulletForce * bulletSpeed);
        }
    }

    void InitializeBullets() {
        for(int i = 0; i < 20; i++) {
            bullets.Add(bullet);
        }
    }
}
