﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public float moveSpeed = .1f;
    Transform leftWayPoint, rightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftWayPoint = GameObject.Find ("LeftWayPoint").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();
        leftWayPoint = GameObject.Find("LeftWayPoint (1)").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint (1)").GetComponent<Transform>();

    }

    // Update is called once per frame
    public virtual void Update () {

        if (transform.position.x > rightWayPoint.position.x)
            movingRight = false;
        if (transform.position.x < leftWayPoint.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();
    }
    void moveRight()
    {
        movingRight = true;
        localScale.x = Mathf.Abs( localScale.x );
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);

    }

    void moveLeft()
    {
        movingRight = false;
        localScale.x = -Mathf.Abs(localScale.x);
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);

    }

    public static implicit operator Follow(float v)
    {
        throw new NotImplementedException();
    }
}
