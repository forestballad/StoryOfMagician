using UnityEngine;
using System.Collections;

public class GroundDetection : MonoBehaviour {
	public MovementControl target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		target.isGround= true;
		target.isJumping = false;
		target.isGliding = false;
		target.resetGravityScale();
	}

	void OnTriggerStay2D(Collider2D other){
		target.isGround= true;
		target.resetGravityScale();
	}

	void OnTriggerExit2D(Collider2D other){
		target.isGround = false;
	}
}
