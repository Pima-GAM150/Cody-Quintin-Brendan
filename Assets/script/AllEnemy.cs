using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour {

	public float moveSpeed = 3f;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
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
}
