using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float speed = -3f;

	private Rigidbody2D myBody;
	private Animator myAnim;

	[SerializeField]
	AudioSource explode;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		myBody.velocity = new Vector2 (speed, 0f);
	}

	void OnCollisionEnter2D(Collision2D target){

		if(target.gameObject.tag == "Player"){
			StartCoroutine (LateCall());
		}

	}

	IEnumerator LateCall(){
		myAnim.SetBool ("isCollided", true);
		explode.Play ();
		yield return new WaitForSeconds (1f);
		gameObject.SetActive (false);
	}
}
