using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiation : MonoBehaviour {

    public enum BulletSource{
        Player,
        Enemy
    }

    public SpriteRenderer spriteRen;
    public Rigidbody2D rigid;
    public Sprite bulletSprite;
    public Vector2 bulletForce;
    public bool fired;
    public float despawnTimer;
    public BoxCollider2D coll;
    public BulletSource source;


    public void Initialize(Sprite sprite, Vector2 force) {
        bulletSprite = sprite;
        bulletForce = force;
        transform.parent = null;
    }
    // Use this for initialization
    void Start() {



    }

    //At instantation...
    void Awake() {
        transform.localPosition = Vector2.zero;
        spriteRen = gameObject.AddComponent<SpriteRenderer>();
        rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        despawnTimer = 4.0f;
        coll = gameObject.AddComponent<BoxCollider2D>();
        coll.isTrigger = true;
        coll.offset = new Vector2(-0.005688721f, 0.01592215f);
        coll.size = new Vector2(0.01208801f, 0.03041184f);
        gameObject.tag = "Bullet";
        //Don't destroy the ship if it shoots and collides w/ its bullet.
        Physics2D.IgnoreCollision(coll, transform.parent.transform.parent.GetComponent<BoxCollider2D>());

        //Add bullet source for score counting        
        switch (transform.parent.tag) {
            case "Player":
                source = BulletSource.Player;
                break;
            case "Enemy":
                source = BulletSource.Enemy;
                break;
            default:
                Debug.Log("Should never hit this...");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        if (!fired) {
            spriteRen.sprite = bulletSprite;
            rigid.AddForce(bulletForce);
            fired = true;
        }

        else {
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0) {
                Destroy(gameObject);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        CheckScore(col);
    }

    void CheckScore(Collider2D col) {
        if (col.gameObject.tag == "Enemy" && source == BulletSource.Player) {
            ScoreKeeper scoreKeeper = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreKeeper>(); ;
            scoreKeeper.IncreaseScore(col.gameObject.GetComponent<EnemyInstantiation>().scoreValue);
        }

    }
}
