/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for making player take damage upon hit
*/

using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	private GamePlayController gamePlayController; // Reference to GamePlayController class

	[SerializeField]
	private int giveDamageAmount; // amount of damage to be taken, specified threw unity

	// Use this for initialization
	void Start () {
		gamePlayController = FindObjectOfType<GamePlayController> (); // when game starts, find GamePlayController
	}


	void OnCollisionEnter2D(Collision2D target){ // when object collides

		if(target.gameObject.tag == "Player"){
			gamePlayController.HurtPlayer (giveDamageAmount); // take giveDamageAmount damage when player is hit

		}

	}

}
