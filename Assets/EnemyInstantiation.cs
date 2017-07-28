using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiation : MonoBehaviour {

    public SpriteRenderer spriteRen;
    public BoxCollider2D coll;
    public string spritePath;
    public Rigidbody2D rigid;
    public int scoreValue;

    // Use this for initialization
    void Start() {
        coll = GetComponent<BoxCollider2D>();
        if (!coll) {
            coll = gameObject.AddComponent<BoxCollider2D>();
        }

        coll.offset = new Vector2(0, -0.03f);
        coll.size = new Vector2(0.23f, 0.1f);

        spriteRen = GetComponent<SpriteRenderer>();
        if (!spriteRen) {
            spriteRen = gameObject.AddComponent<SpriteRenderer>();
        }

        rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        if (scoreValue == 0) {
            scoreValue = 10;
        }

    }

    // Update is called once per frame
    void Update() {

    }
}
