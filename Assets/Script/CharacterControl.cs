using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public bool facingRight = true; // 1 for facing right, -1 for facing left
	public bool ground = true; // true for standing on ground
	public float walkSpeed;
	public float jumpForce;

	BoxCollider2D cld;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		cld = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D otherCollider) {
		if (otherCollider.gameObject.tag == "Ground") {
			ground = true;
		}
	}

	void FixedUpdate(){
		if (ground) {
			if (Input.GetKey ("right")){
				if (!facingRight){
					facingRight = true;
				}
				rb.velocity = new Vector2(walkSpeed,rb.velocity.y);
			}
			if (Input.GetKey ("left")){
				if (facingRight){
					facingRight = false;
				}
				rb.velocity = new Vector2(-walkSpeed,rb.velocity.y);
			}
			if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Space)){
				ground = false;
				rb.AddForce(new Vector2(0f,jumpForce));
			}
		}


	}
}
