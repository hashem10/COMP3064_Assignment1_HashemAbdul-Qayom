/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for spawning the BARRELS obstacle
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles; //Gameobject type of obstacle

	private List<GameObject> obstaclesForSpawning = new List<GameObject> (); // making list for the obstacles type(red/green)



	void Awake(){
		InitializeObstacles (); // call to the method - InitalizeObstacles
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnRandomObstacle ());
	}


	void InitializeObstacles(){ // defining what each object is
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles[index], new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;
			obstaclesForSpawning.Add (obj);
			obstaclesForSpawning[i].SetActive (false);
			index++;
			if (index == obstacles.Length) // reset if index is out of bound
				index = 0;



		}
	}

	void shuffle(){  // shuffle to make it the green barrel or red barrel
	
		for (int i = 0; i < obstaclesForSpawning.Count; i++) {
			GameObject temp = obstaclesForSpawning [i];
			int random = Random.Range (i, obstaclesForSpawning.Count);
			obstaclesForSpawning [i] = obstaclesForSpawning [random];
			obstaclesForSpawning [random] = temp;	  
		}
	}


	IEnumerator SpawnRandomObstacle() { // Spawn obstacle at a random location
		yield return new WaitForSeconds (Random.Range (1f, 3.5f)); // wait 1 to 3.5 seconds before next spawn

		int index = Random.Range (0, obstaclesForSpawning.Count);
		while (true) {

			if (!obstaclesForSpawning [index].activeInHierarchy) { // if barrels is not in Heiratchy
				obstaclesForSpawning [index].SetActive (true);
				obstaclesForSpawning [index].transform.position = new Vector3(transform.position.x, transform.position.y, -2);
				break;
			} else { // if barrels is in Heiratchy
				index = Random.Range (0, obstaclesForSpawning.Count);
			}
			
		}

		StartCoroutine (SpawnRandomObstacle ());
	}


}
