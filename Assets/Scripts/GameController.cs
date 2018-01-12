﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	private BossController bossController;


	void Start () { 
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

		GameObject pineappleControllerObject = GameObject.FindWithTag ("BossController");
		if (pineappleControllerObject != null) {
			bossController = pineappleControllerObject.GetComponent <BossController>();
		}
		if (bossController == null) {
			Debug.Log("Cannot find 'PineApple' script");
		}


	}
  
	void Update () {
		
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene("Main");
			}
		}
	
	}
		
	IEnumerator SpawnWaves () {
	    yield return new WaitForSeconds (startWait);
	    while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); 
				Quaternion spawnRotation =  Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation); 
				yield return new WaitForSeconds (spawnWait);
			}
			if (score >= 0) {
				hazardCount = 0;
				bossController.StartFlight ();
			}

			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
	    }
	}
  
	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	public void GameOver () {
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}