/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class will spawn heart to the game screen
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] heart; // defining what heart is. 

	private List<GameObject> HeartForSpawning = new List<GameObject> (); // a list of heart object, in the future 
																		 // if different type of heart will be spawned



	void Awake(){
		InitializeObstacles (); // call to the method - InitalizeObstacles
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnHeartRandomLocation ()); // call to the method - SpawnHeartRandomLocation
	}


	void InitializeObstacles(){ // defining what each object is
		int index = 0;
		for (int i = 0; i < heart.Length * 3; i++) {
			GameObject obj = Instantiate (heart[index], new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;
			HeartForSpawning.Add (obj);
			HeartForSpawning[i].SetActive (false);
			index++;
			if (index == heart.Length) // reset if index is out of bound
				index = 0;
		}
	}


	IEnumerator SpawnHeartRandomLocation() { // Spawn heart at a random location
		yield return new WaitForSeconds (Random.Range (7f, 15f)); // wait 7 to 15 seconds before spawning

		int index = Random.Range (0, HeartForSpawning.Count); 
		while (true) {

			if (!HeartForSpawning [index].activeInHierarchy) { // if heart is not in Heiratchy
				HeartForSpawning [index].SetActive (true);
				HeartForSpawning [index].transform.position = new Vector3(Random.Range(-2f,9f), transform.position.y, -2);
				break;
			} else { // if heart is in Heirarchy
				index = Random.Range (0, HeartForSpawning.Count);
			}

		}

		StartCoroutine (SpawnHeartRandomLocation ());
	}
}
