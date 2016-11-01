/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible deactivating objects when it hits the ground or player
*/

using UnityEngine;
using System.Collections;

public class OnHitGroundDeactivate : MonoBehaviour {
	private Rigidbody2D myBody;

	[SerializeField]
	private AudioSource hit;

	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
		
//		myBody.velocity = new Vector2 (Random.Range(-5f,-1f), 0f); 
	}
		

	void OnCollisionEnter2D(Collision2D target){

		if (target.gameObject.tag == "Player") {
			gameObject.SetActive (false);

		} else if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Obstacle") {
			gameObject.SetActive (false);
		}

	}
}
