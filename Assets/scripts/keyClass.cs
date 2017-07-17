﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyClass : MonoBehaviour {

	private GameObject playerObj;
	private playerController player;
	private GameObject keyObj;
	public GameObject keyFoundCanvas;
	public GameObject door;
	//private Animation doorOpening;
	private float canvasTime = 3;

	void Start() {
		playerObj = GameObject.FindGameObjectWithTag("Player"); 
		player = (playerController)playerObj.GetComponent (typeof(playerController));
		keyObj = GameObject.FindGameObjectWithTag("key");

	//	doorOpening = door.GetComponent<Animation>();

	}

	void OnTriggerEnter2D(Collider2D coll){

		//flash canvas on screen
		keyFoundCanvas.SetActive (true);
		Destroy (keyFoundCanvas, canvasTime);
		//make key invis;
		keyObj.SetActive(false);
		//set that player has the key
		player.setKey(true);

		//open door
		//doorOpening.Play();

	}
}
