/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for what happens in Main Menu
*/

using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame(){ // start the game when play button is clicked
		Application.LoadLevel ("Gameplay");
	}
}
