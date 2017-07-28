using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour {

    public float xCoord;
    public Camera cam;
    public float viewX;
    public float viewWidth;
    public float rate;
    public float xMin, xMax;
    public float aspect;
    public GameObject spawnPrefab;
    public float spawnCd;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        aspect = 1024 / 768;
        viewWidth = cam.orthographicSize * cam.aspect * 2; 
        rate = 1.0f;
        spawnCd = rate;
        xMin = cam.ScreenToWorldPoint(new Vector3(0, 0)).x;
        xMax = cam.ScreenToWorldPoint(new Vector3(cam.rect.xMax, 0)).x; 
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnCd >= 0) {
            spawnCd -= Time.deltaTime;
        }
        else {
            viewX = Random.value;
            Instantiate(spawnPrefab, new Vector3(transform.position.x * viewX + xMin, 25, 0), new Quaternion(0, 0, 180, 0));
            spawnCd = rate;
        }
		
	}
}
