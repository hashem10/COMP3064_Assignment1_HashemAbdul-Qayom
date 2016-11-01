/*
* Source File Name(s): Player
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for killing our player
*/


using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour {

	public delegate void EndGame();
	public static event EndGame endGame;


	public void PlayerDiedEndGame(){ // end game and destroy player
		if (endGame != null)
			endGame();
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){ // when collids with Collector object kill player
	
		if (target.tag == "Collector") {
			PlayerDiedEndGame ();
		}
	
	}


}
