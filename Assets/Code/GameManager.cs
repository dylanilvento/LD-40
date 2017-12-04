using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class GameManager : MonoBehaviour {
	public GameObject player;
	Player playerController;
	PlayerCombat playerCombat;
	public Text scoreFG, scoreBG, gameOver, highScore, pressStart;

	public bool playerDead = false;
	// Use this for initialization
	void Start () {
		playerCombat = player.GetComponent<PlayerCombat>();
		playerController = ReInput.players.GetPlayer(0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerDead && playerController.GetButtonDown("Start")) {
			Time.timeScale = 1f;
			SceneManager.LoadScene("Main");
		}
		
		UpdateScoreboard();



	}

	public GameObject GetPlayer () {
		return player;
	}

	public Transform GetPlayerTransform () {
		return player.transform;
	}

	void UpdateScoreboard() {
		string score = playerCombat.currentScore + "/" + playerCombat.maxScore;
		scoreFG.text = score;
		scoreBG.text = score;

		gameOver.color = Color.clear;
		highScore.color = Color.clear;
		pressStart.color = Color.clear;

		if (playerCombat.currentScore == 0) scoreFG.color = Color.red;
		else scoreFG.color = Color.white;
	}

	public void GameOver (int maxScore) {
		
		
		// Time.timeScale = 0f;
		
		scoreBG.color = Color.clear;
		scoreFG.color = Color.clear;

		gameOver.color = new Color(1f, 1f, 1f, 1f);
		highScore.color = Color.white;
		pressStart.color = Color.white;

		highScore.text = "high score: " + maxScore;
		playerDead = true;

	}
}
