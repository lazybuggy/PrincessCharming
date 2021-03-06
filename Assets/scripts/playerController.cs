﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	//variables
	private float maxSpeed = 50f;
	private float speed = 50f;
	public GameObject failedCanvas;
	public GameObject pauseCanvas;
	public bool grounded;
	private bool facingRight;
	public float timeLeft=60f;
	private bool hasKey;
	private Text counter;
	private Text attackCounter;
	private Text timer;
	public static bool gamePaused= false;
	bool isAttacking;
//	public Sprite attack;
	private Animator myAnimation;

	private Rigidbody2D rb2d;
	//private bool princessAttack = false;
	int attackHash = Animator.StringToHash("canAttack");

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		facingRight = true;
		counter = GameObject.FindWithTag("gemCount").GetComponent<Text>();
		attackCounter = GameObject.FindWithTag("eggCount").GetComponent<Text>();
		timer = GameObject.FindWithTag("timer").GetComponent<Text>();
		timer.text = timeLeft.ToString("f0");
		myAnimation = GetComponent<Animator> ();
		isAttacking = false;
	}

	// Update is called once per frame
	void Update () {

		myAnimation.SetFloat ("speed", Mathf.Abs (rb2d.velocity.x));

		//flip sprite
		//moving left
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (0.22f, 0.22f, 1);
		}

		//moving right
		else if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (-0.22f, 0.22f, 1);
		}

		//jumping
		if (Input.GetButtonDown ("Vertical")) {
			//if the player is on the ground
			if (grounded) {
				rb2d.AddForce (Vector2.up * 170f);
			}
		}

		//attacking
		if (Input.GetButtonDown ("Attack")) {
			isAttacking = true;
			myAnimation.SetTrigger (attackHash);
		    //isAttacking = false;

		}

		//pause
		if(Input.GetButtonDown("Pause"))  {
			gamePaused = true;
			Time.timeScale = 0;
			pauseCanvas.SetActive (true);
			Text gems = GameObject.FindWithTag("gemScore").GetComponent<Text>();
			string gemCounting = GameObject.FindWithTag("gemCount").GetComponent<Text>().text;
			gems.text = gemCounting;
			Text eggs = GameObject.FindWithTag("eggScore").GetComponent<Text>();
			string eggCounting = GameObject.FindWithTag("eggCount").GetComponent<Text>().text;
			eggs.text = eggCounting;
			Text timer = GameObject.FindWithTag("timeScore").GetComponent<Text>();
			string timeCounting = GameObject.FindWithTag("timer").GetComponent<Text>().text;
			timer.text = timeCounting;
		}

		if (!gamePaused) {
			timeLeft -= Time.deltaTime;
			timer.text = timeLeft.ToString ("f0");
			if (timeLeft <= 0) {
				GameOver ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Contains ("gem")) {
			Destroy (col.gameObject);
			int count = Int32.Parse(counter.text);
			count+=3;
			counter.text = count.ToString();

		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Enemy") {
			if (isAttacking) {
				Destroy (col.gameObject);
				//NEL POINTS HERE
				int count = Int32.Parse(attackCounter.text);
				count+=5;
				attackCounter.text = count.ToString();
			} else {
				GameOver2 ();
			}
		}
	}

	void Wait(){
	//	isAttacking = false;

	}

	void FixedUpdate(){

		//moving player horizontally
		float hor = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2 (hor * speed * Time.deltaTime, rb2d.velocity.y);
	
		//limiting speed of player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if(rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}

	public void setKey(bool obtained){
		hasKey = obtained;
	}

	public bool getKey(){
		return hasKey;
	}

	void GameOver(){
		failedCanvas.SetActive(true);
		GameObject.FindWithTag ("ouch").GetComponent<Text> ().text = "Time's Up!";
		GameObject.FindWithTag ("egg").GetComponent<Image> ().enabled = false;
		Time.timeScale = 0.0f;
	}

	void GameOver2(){
		failedCanvas.SetActive(true);
		GameObject.FindWithTag("ouch").GetComponent<Text>().text="Ouch that hurt!";
		GameObject.FindWithTag ("time").GetComponent <Image> ().enabled = false;
		Time.timeScale = 0.0f;
	}
}
