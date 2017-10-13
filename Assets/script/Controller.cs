using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public Rigidbody2D body;

	public float moveSpeed = 5f;
	public float jumpPower = 5f;

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

		if( body.velocity.y == 0f ) {
			body.AddForce( Vector2.right * xInput );
		}

		if( Input.GetButtonDown("Vertical") ) {
			if( body.velocity.y < 0.1f ) {
				if( body.velocity.y >= 0f ) {
					body.AddForce( Vector2.up * jumpPower, ForceMode2D.Impulse );
				}
			}
		}

		// animation

		if( xInput > 0f ) {
			currentAnimation = walkingAnimation;
			spriteRenderer.flipX = false;
		}
		if( xInput < 0f ) {
			currentAnimation = walkingAnimation;
			spriteRenderer.flipX = true;
		}
		if( xInput == 0f ) {
			currentAnimation = idleAnimation;
		}

		if( animationTimer > animationFrameTime ) {
			currentAnimIndex++;

			if( currentAnimIndex >= currentAnimation.Length ) {
				currentAnimIndex = 0;
			}

			spriteRenderer.sprite = currentAnimation[currentAnimIndex];

			animationTimer = 0f;
		}

		animationTimer += Time.deltaTime;
	}

	void OnTriggerEnter2D( Collider2D otherCol ) {
		if( otherCol.gameObject.layer == LayerMask.NameToLayer( "Powerups" ) ) {
			otherCol.gameObject.SetActive( false );
		}
	}
}
