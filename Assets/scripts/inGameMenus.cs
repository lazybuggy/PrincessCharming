﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenus : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject failPanel;
	public GameObject passPanel;
	public GameObject pausePanel;

	public void onHelp() {
		Debug.Log ("onHelp!");
		helpPanel.SetActive (true);
	}
	
	public void onCloseHelp() {
			
		Debug.Log ("onCloseHelp!");

		helpPanel.SetActive (false);
	}
	public void onRestartPause(){
		Debug.Log ("onRestartPause!");
		pausePanel.SetActive (false);
	}
	public void onContinuePause(){
		Debug.Log ("onContinuePause!");
		pausePanel.SetActive (false);
	}
	public void onLevelSelectPause(){
		Debug.Log ("onLevelSelectPause!");
		pausePanel.SetActive (false);
	}

	public void onRetryFail(){
		Debug.Log ("onRetryFailed!");
		failPanel.SetActive (false);
	}
	public void onLevelSelectFail(){
		Debug.Log ("onLevelSelectFailed!");
		failPanel.SetActive (false);
	}

	public void onRetryPassed(){
		Debug.Log ("onRetryPassed");
		passPanel.SetActive (false);
	}
	public void onContinuePassed(){
		Debug.Log ("onContinuePassed");
		passPanel.SetActive (false);
	}
	public void onLevelSelectPass(){
		Debug.Log ("onLevelSelectPass!");
		passPanel.SetActive (false);
	}
		
}