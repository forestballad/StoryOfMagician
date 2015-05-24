using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	public bool facingRight = true; // 1 for facing right, -1 for facing left
	public bool isGround = true; // true for standing on ground
	public bool isJumping = false; // true for first jump air
	public bool isGliding = false; // true for second jump air

	public float walkSpeed;
	public float jumpForce;
	public float glideSpeed;

	BoxCollider2D cld;
	Rigidbody2D rb;

	bool k_right;
	bool k_left;
	bool k_up;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		cld = GetComponent<BoxCollider2D> ();
		k_right = false;
		k_left = false;
		k_up = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("right") || Input.GetKeyDown ("right")) k_right = true;
		if (Input.GetKey ("left") || Input.GetKeyDown ("left"))	k_left = true;
		if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Space)) k_up = true;
	}

	void FixedUpdate(){
		if (k_right && !isGliding) {
			if (!facingRight && isGround) {
				facingRight = true;
			}
			rb.velocity = new Vector2 (walkSpeed, rb.velocity.y);
			k_right = false;
		}
		if (k_left && !isGliding) {
			if (facingRight && isGround) {
				facingRight = false;
			}
			rb.velocity = new Vector2 (-walkSpeed, rb.velocity.y);
			k_left = false;
		}
		if (k_up){
			if (isGround){
				isGround = false;
				isJumping = true;
				rb.AddForce(new Vector2(0f,jumpForce));
			}
			else if (isJumping){
				isJumping = false;
				isGliding = true;
				if (facingRight){
					rb.velocity = new Vector2(glideSpeed,rb.velocity.y);
				}
				else {
					rb.velocity = new Vector2(-glideSpeed,rb.velocity.y);
				}
				rb.gravityScale = 0.5f;
			}
			else if (isGliding){
				rb.velocity = new Vector2(0f,0f);
				rb.gravityScale = 5.0f;
			}
			k_up = false;
		}
	}

	public void resetGravityScale(){
		rb.gravityScale = 1f;
	}
}

