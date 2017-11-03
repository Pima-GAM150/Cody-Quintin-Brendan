using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : Follow
{
    public Rigidbody2D body;
    public float EJump = 10f;
    public override void Update()
    {
        base.Update();
            if (Input.GetButtonDown("Vertical"))
            {
                if (body.velocity.y < 0.1f)
                {
                    if (body.velocity.y >= 0f)
                    {
                        body.AddForce(Vector2.up * EJump, ForceMode2D.Impulse);
                    }
                }
            }
    }
}
