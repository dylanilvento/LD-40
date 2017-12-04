using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	Player player;
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetButtonDown("Start")) {
			SceneManager.LoadScene("Main");
		}
	}
}
