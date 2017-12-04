using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class TitleBob : MonoBehaviour {
	float t;
	[Range(0, 10f)]
	public float modifier;

	Player player;
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(0);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		float y = Mathf.Sin(t + modifier);

		transform.position = new Vector2(transform.position.x, y);

		if (player.GetButtonDown("Start")) {
			SceneManager.LoadScene("Main");
		}

	}
}
