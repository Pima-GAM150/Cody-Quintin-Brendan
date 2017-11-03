using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : Follow {
    
public override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Vertical"))
        {
            print("Pressed up " + Time.time);
            moveSpeed += 0.1f;
        }
    }
}