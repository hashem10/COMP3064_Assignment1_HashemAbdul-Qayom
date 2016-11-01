/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for controlling our player
*/

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed; // how fast our player will move

	private Rigidbody2D myRigidBody; // reference to player

	[SerializeField]
	private float jumpSpeed; // how high player can jump


	[SerializeField]
	private Transform groundCheck;// check ground
	[SerializeField]
	private float groundCheckRadius; // radius for the ground
	[SerializeField]
	private LayerMask whatIsGround; // reference to our Ground LayerMaks

	private bool isGrounded; // if on the ground

	private Animator myAnim; // player animation

	[SerializeField]
	AudioSource jump; // jump sound
	[SerializeField]
	AudioSource hit; // getting hit sound

	private GamePlayController gamePlayController;

	// Use this for initialization
	void Start () { // get the references to our objects 
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		gamePlayController = FindObjectOfType<GamePlayController>();
	}
	

	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround); // check if object is on the ground
	
		if (Input.GetAxis ("Horizontal") > 0f) { // moving right
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (0.30f, 0.30f, 0.30f);
		} else if (Input.GetAxis ("Horizontal") < 0f) { // moving left
			myRigidBody.velocity = new Vector3 (-moveSpeed - 5f, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (-0.30f, 0.30f, 0.30f);
		} else { // not moving
			myRigidBody.velocity = new Vector3 (0, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (0.30f, 0.30f, 0.30f);
		}
			
		if (Input.GetAxis ("Vertical") < 0f && isGrounded) { // if player is on the ground and up arrow or W is pressed
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
			jump.Play ();
		}

		myAnim.SetBool ("Grounded", isGrounded); // set value for boolead isGrounded
	}


	void OnCollisionEnter2D(Collision2D target){ // when player collides with this objects

		if (target.gameObject.tag == "Danger") { // if it is the star play hit sound
			hit.Play ();
		}else if (target.gameObject.tag == "Heart") { // if it is heart add two/full heart to our heart meter
			gamePlayController.healthCount += 2;
		}

	}
		
}	
