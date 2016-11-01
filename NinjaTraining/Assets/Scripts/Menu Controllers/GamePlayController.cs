/*
* Source File Name(s): 
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is responsible for Game panel(buttons, text), scoring, and health meter
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel; // reference to pause panel which will be set in unity
	[SerializeField]
	private Button restartGameButton;// reference to Restart button which will be set in unity
	[SerializeField]
	private Text scoreText, pauseText; // reference to score and pause text which will be set in unity

	private int score; // this will hold our game score


	public Image heart1; // reference to heart1 image which will be set in unity
	[SerializeField]
	private Image heart2; // reference to heart2 image which will be set in unity
	[SerializeField]
	private Image heart3; // reference to heart3 image which will be set in unity
	[SerializeField]
	private Image heart4; // reference to heart4 image which will be set in unity
	[SerializeField]
	private Image heart5; // reference to heart5 image which will be set in unity

	[SerializeField]
	private Sprite heartFull; // reference to when heart is full image which will be set in unity
	[SerializeField]
	private Sprite heartHalf; // reference to when heart is half image which will be set in unity
	[SerializeField]
	private Sprite heartEmpty; // reference to when heart is empty image which will be set in unity

	//keeping track of how much heart we have and our max health
	public int maxHealth; // set in unit
	public int healthCount;


	// player died class

	private PlayerDied playerDied; // reference to PlayerDied class

	// Use this for initialization
	void Start () {
		
		scoreText.text = score.ToString() + " M"; // set initial score text
		healthCount = maxHealth; // set initial health count
		StartCoroutine (UpdateScore ()); // start updating score
	}

	void Awake(){
		playerDied = FindObjectOfType<PlayerDied> (); // reference to PlayerDied class
	}
	
	IEnumerator UpdateScore(){ // update score
		yield return new WaitForSeconds (0.6f); // every 6 seconds add 5 to the score text
		score+=5;
		scoreText.text = score.ToString() + " M"; // update score text
		StartCoroutine (UpdateScore ());
	}

	void Update(){
		if (healthCount <= 0) { // kill player if health reaches 0
			PlayerDiedEndTheGame ();
		} if (healthCount > 10) { // set max health back to 10 even if player get heart when heart is full
			healthCount = maxHealth;
		}
		HeartMeterUpdate (); // call to HeartMeterUpdate method
	}

	public void HurtPlayer(int damageAmount){ // produce damage when called
		healthCount -= damageAmount;	
	}

	void OnEnable(){  
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable(){
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}

	void PlayerDiedEndTheGame(){ // kill player and set the following variable to default
		if (!PlayerPrefs.HasKey ("Score")) {
			PlayerPrefs.SetInt ("Score", 0);
		}else{
			int highScore = PlayerPrefs.GetInt("score");

			if (highScore < score) {
				PlayerPrefs.SetInt ("Score", score);
			}
		}
		healthCount = maxHealth;
		pauseText.text = "Game Over!";
		pausePanel.SetActive (true); // show pause panel
		restartGameButton.onClick.RemoveAllListeners (); // remove all listeners
		restartGameButton.onClick.AddListener (() => RestartGame()); // only add RestartGame method to listener
		Time.timeScale = 0f;
	}

	public void PauseButton(){ // when pause button is clicked
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => ResumeGame());
	}


	public void ResumeGame(){ // when resume button is clicked
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame(){ // when restart game clicked
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}

	public void GoToMainMenu(){ // when go to menu click
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void HeartMeterUpdate(){ // update heart
		switch (healthCount) { // switch statement regarding what image to show in according to healCount variable

		case 10: // when health is  10
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			heart4.sprite = heartFull;
			heart5.sprite = heartFull;
			return;
		case 9: // when health is  9
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			heart4.sprite = heartFull;
			heart5.sprite = heartHalf;
			return;
		case 8: // when health is  8
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			heart4.sprite = heartFull;
			heart5.sprite = heartEmpty;
			return;
		case 7: // when health is  7
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			heart4.sprite = heartHalf;
			heart5.sprite = heartEmpty;
			return;
		case 6: // when health is  6
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 5: // when health is  5
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartHalf;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 4: // when health is  4
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 3: // when health is  3
			heart1.sprite = heartFull;
			heart2.sprite = heartHalf;
			heart3.sprite = heartEmpty;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 2: // when health is  2
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 1: // when health is  1
			heart1.sprite = heartHalf;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		case 0: // when health is  0
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			heart4.sprite = heartEmpty;
			heart5.sprite = heartEmpty;
			return;
		default:
			if (healthCount > 10) { // if health is greater then 10 show heart full
				heart1.sprite = heartFull;
				heart2.sprite = heartFull;
				heart3.sprite = heartFull;
				heart4.sprite = heartFull;
				heart5.sprite = heartFull;
			}else if (healthCount < 10) { // if health is less then 10 show heart empty
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				heart4.sprite = heartEmpty;
				heart5.sprite = heartEmpty;
			}
			return;

		}
	}
}

































