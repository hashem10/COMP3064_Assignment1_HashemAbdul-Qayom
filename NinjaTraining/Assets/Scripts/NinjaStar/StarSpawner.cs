/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for spawning ninja star
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] stars; // Gameobject type of stars

	private List<GameObject> starsForSpawning = new List<GameObject> (); // making list for ninja stars

	void Awake(){
		InitializeObstacles ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnStarsRandomLocation ());  // call to the method - InitalizeObstacles
	}
		
	void InitializeObstacles(){ // defining what each object is
		int index = 0;
		for (int i = 0; i < stars.Length * 3; i++) {
			GameObject obj = Instantiate (stars[index], new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;
			starsForSpawning.Add (obj);
			starsForSpawning[i].SetActive (false);
			index++;
			if (index == stars.Length) // reset if index is out of bound
				index = 0;



		}
	}


	IEnumerator SpawnStarsRandomLocation() { // Spawn star at a random location
		yield return new WaitForSeconds (Random.Range (0.4f, 0.7f)); // wait 0.4 to 0.7 second before spawning

		int index = Random.Range (0, starsForSpawning.Count);
		while (true) {

			if (!starsForSpawning [index].activeInHierarchy) { // if star is not in Heiratchy
				starsForSpawning [index].SetActive (true);
				starsForSpawning [index].transform.position = new Vector3(Random.Range(-9f,9f), transform.position.y, -2);
				break;
			} else { // if star is  in Heiratchy
				index = Random.Range (0, starsForSpawning.Count);
			}

		}

		StartCoroutine (SpawnStarsRandomLocation ());
	}
}
