using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript2 : MonoBehaviour {
    public float max_health = 100f;
    public float cur_health = 0f;
	// Use this for initialization
	void Start () {
        cur_health = max_health;

	}
    public void TakeDamage(float amount)
    {
        cur_health -= amount;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
