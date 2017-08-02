using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpriteAnim : MonoBehaviour {

    public enum State {
        Idle = 0,
        Turn = 3,
        Turned = 6
    }
    public enum Direction {
        None = 0,
        Right = 1,
        Left = 2
    }

    public SpriteRenderer spriteRen;
    public Sprite[] sprites;
    public String loadFolder;
    public int frames;
    public int animRate;
    public State currState;
    public float turnTime;
    public float turnThreshold;
    public List<State> states;

    // Use this for initialization
    void Start() {
        spriteRen = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(loadFolder);
        frames = 0;
        animRate = 10;
        currState = State.Idle;
        turnTime = 0;
        turnThreshold = 0.01f;
        states = new List<State>();
        states.Add(State.Idle);
        states.Add(State.Turn);
        states.Add(State.Turned);
    }

    // Update is called once per frame
    void Update() {
        //initialization of local vars        
        int currFrame;
        float horizontal;
        Direction CurrDir;

        if (frames > 2000) {
            frames = 0;
        }
        frames++;
        horizontal = Input.GetAxisRaw("Horizontal");
        if (frames % animRate == 0) {
            currFrame = Array.IndexOf(sprites, spriteRen.sprite);
            //not turning
            if (horizontal == 0) {
                if (turnTime > 0) {
                    turnTime -= Time.deltaTime;
                }
                else {
                    turnTime += Time.deltaTime;
                }
            }
            else {
                if (horizontal > 0 && turnTime <= turnThreshold * 2) {
                    turnTime += Time.deltaTime;
                    if (turnTime > turnThreshold * 2) {
                        turnTime = turnThreshold * 2;
                    }
                }
                else {
                    turnTime -= Time.deltaTime;
                    if (turnTime < -turnThreshold * 2) {
                        turnTime = -turnThreshold * 2;
                    }
                }

            }
            if (turnTime >= turnThreshold) {
                CurrDir = Direction.Right;
            }
            else if (turnTime <= turnThreshold) {
                CurrDir = Direction.Left;
            }
            else {
                CurrDir = Direction.None;
            }
            turnLogic(CurrDir);
            currFrame = PlayAnimation((int)currState, (int)currState + 2, currFrame);
            spriteRen.sprite = sprites[currFrame];
        }


    }



    /// <summary>
    /// Plays certain animation segment
    /// </summary>
    /// <param name="startFrame">First frame of animation.</param>
    /// <param name="endFrame">Last frame of animation.</param>
    /// <param name="currFrame">Frame that we're currently rendering.</param>
    int PlayAnimation(int startFrame, int endFrame, int currFrame) {
        if (currFrame >= endFrame) {
            return currFrame = startFrame;
        }

        else {
            return currFrame += 1;
        }
    }
    /// <summary>
    /// Executes turn logic and handles flipping of sprite.
    /// </summary>
    /// <param name="flipX">Do we flip x or no?</param>
    void turnLogic(Direction dir) {
        if (turnTime < turnThreshold && turnTime > -turnThreshold) {
            currState = State.Idle;
        }
        else if (Mathf.Abs(turnTime) > turnThreshold && Mathf.Abs(turnTime) < turnThreshold * 2) {
            currState = State.Turn;
        }
        else if (Mathf.Abs(turnTime) >= turnThreshold * 2) {
            currState = State.Turned;
        }

        if (dir == Direction.Left) {
            spriteRen.flipX = true;
        }
        else {
            spriteRen.flipX = false;
        }
    }
/// <summary>
/// Unused for now, but was getting the next state in an enum.
/// </summary>
/// <param name="currState"></param>
/// <returns></returns>
    State nextState(State currState) {
        int index = states.IndexOf(currState);
        if (index < states.Count - 1)
            return states[states.IndexOf(currState) + 1];
        else
            return states[states.IndexOf(currState)];


    }
}
