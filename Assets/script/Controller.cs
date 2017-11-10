using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Rigidbody2D body;

	public float moveSpeed = 10.3f;
	public float jumpPower = 9f;

	public SpriteRenderer spriteRenderer;
	public Sprite[] walkingAnimation;
	public Sprite[] idleAnimation;

	Sprite[] currentAnimation;
	int currentAnimIndex;

	public float animationFrameTime = 0.1f;
	float animationTimer;

	void Start() {
		currentAnimation = idleAnimation;
	}

	void Update() {

		// input

		float xInput = Input.GetAxis( "Horizontal" ) * moveSpeed;

		
			body.AddForce( Vector2.right * xInput );
		

		if( Input.GetButtonDown("Vertical") ) {
			if( body.velocity.y < .5f ) {
				if( body.velocity.y >= -.5f ) {
					body.AddForce( Vector2.up * jumpPower, ForceMode2D.Impulse );
				}
			}
		}
	}

	void OnTriggerEnter2D( Collider2D otherCol ) {
		if( otherCol.gameObject.layer == LayerMask.NameToLayer( "Powerups" ) ) {
			otherCol.gameObject.SetActive( false );
		}
	}
}
