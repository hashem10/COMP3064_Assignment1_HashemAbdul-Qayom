/*
* Source File Name(s): Background, Ground object
* Author Name: Hashem Abdul-Qayom
* Last Modified by: Hashem Abdul-Qayom
* Date last Modified: October 31, 2016
* Program Description: This class is made to make background slide(left to right)
*/

using UnityEngine;
using System.Collections;

public class BackgroundLoop : MonoBehaviour {

	public float speed = 0.1f; // sliding speed

	private Vector2 offset = Vector2.zero; 
	private Material mat; // reference to our material

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material; // getting material componenet
		offset = mat.GetTextureOffset ("_MainTex"); // set ofset
	}
	
	// Update is called once per frame
	void Update () {
		offset.x += speed * Time.deltaTime; // move our screen based on speed and time
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
