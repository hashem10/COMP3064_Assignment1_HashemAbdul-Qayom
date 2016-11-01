/*
* Source File Name(s): hudHeart_full prefab, Barrel1Obstacle prefab, Barrel2Obstacle prefab, Ninja_star prefab
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class will disable any object that hits our Collector object.
*/


using UnityEngine;
using System.Collections;

public class ObstaclesOffScreen : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){ // when triggered disable the object
	
		if(target.tag == "Collector"){
			gameObject.SetActive (false);
		}

	}

}
