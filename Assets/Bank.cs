using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour {

    public float Horizontal;
    public bool Turning;
    public Animator anim;
    public Animation an;
    public SpriteRenderer sprite;
    public int nextAnim;
    public int counter;
    public int currAnim;
    public float speed;
    public Sprite[] sprites;

    // Use this for initialization
    void Start() {
        nextAnim = 5; //5 frames till next animation
        anim = GetComponent<Animator>();
        an = GetComponent<Animation>();
        sprite = GetComponent<SpriteRenderer>();
        currAnim = 0;
        speed = 3;

        sprite.sprite = sprites[9];      
    }

    // Update is called once per frame
    void Update() {

        //Horizontal = Input.GetAxisRaw("Horizontal");
        //if (Horizontal != 0) {
        //    Turning = true;
        //    anim.SetBool("Turning", Turning);
        //    if (Horizontal < 1) {
        //        sprite.flipX = true;
        //        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, Time.deltaTime * speed);
        //    }
        //    else {
        //        sprite.flipX = false;
        //        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, Time.deltaTime * speed);
        //    }
        //}
        //else {
        //    Turning = false;
        //    anim.SetBool("Turning", Turning);
        //}
        //if (counter < nextAnim) {
        //    counter += 1;
        //}
        //else {
        //    counter = 0;
        //    Horizontal = Input.GetAxisRaw("Horizontal");
        //    if (Horizontal == 0) {
        //        AnimationState idle = animation["Plane Idle"];
        //        advanceAnimation(idle, 0.8f);
        //    }
        //    else if (Horizontal > 0) {
        //        AnimationState bank = animation["Plane Turn"];
        //        advanceAnimation(bank, 0.8f);

        //    }

        //    else if (Horizontal < 0) {
        //        sprite.flipX = true;
        //        AnimationState bank = animation["Plane Turn"];
        //        advanceAnimation(bank, 0.8f);


        //    }

        //}
    }
    void advanceAnimation(AnimationState animState, float time) {
        animState.time += time;
        animState.speed = 0;
        an.Play();
    }
}