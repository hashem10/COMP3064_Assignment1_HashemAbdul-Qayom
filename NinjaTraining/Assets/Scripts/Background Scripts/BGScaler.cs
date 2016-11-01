/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class will scale our background to fit the screen
*/

using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {


	void Start () {
		var height = Camera.main.orthographicSize * 2f; // defining value for the height of our background
		var width = height * Screen.width / Screen.height; // defining balue for the width of our background

		if (gameObject.name == "Background") { // if it is our background scale it to the defiend width and height
			transform.localScale = new Vector3 (width, height, -2);
		} else {
			transform.localScale = new Vector3 (width + 3f, 8.2f, -2);
		}
	}

}
