using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReveal : MonoBehaviour {

	[SerializeField] private SceneController controller;

	private bool reveal = true;
	private int _id;

	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().enabled = false; // Turns off the sprite at the start
	}

	public void OnMouseDown() {
		gameObject.GetComponent<SpriteRenderer> ().enabled = reveal; // Turn it on and off based on mouseclick 
		reveal = !reveal;
	}

	public int id {
		get { return _id;}
	}

	public void SetCard (int id, Sprite image) {
		_id = id;
		GetComponent<SpriteRenderer> ().sprite = image; // set the sprite for this SpriteRenderer component
	}
}
