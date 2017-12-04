using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject enemy;

	GameManager gm;

	Player player;

	
	float maxTime = 8f;
	float minTime = 2f;

	float[] xRange = {-3f, 25f};
	float[] yRange = {-12f, 4f};
	void Start () {
		
		player = ReInput.players.GetPlayer(0);
		gm = GetComponent<GameManager>();
		StartCoroutine("SpawnEnemies");
	}
	
	// Update is called once per frame
	void Update () {

		// if (player.GetButtonDown("Spawn")) {
		// 	Spawn();
		// }
		
	}

	IEnumerator SpawnEnemies () {
		while (!gm.playerDead) {
			float t = Random.Range(minTime, maxTime);
			yield return new WaitForSeconds(t);

			Spawn();

		}
	}

	void Spawn() {
		float xCoord = Random.Range(xRange[0], xRange[1]);
			float yCoord = Random.Range(yRange[0], yRange[1]);

			Vector2 spawnPosition = new Vector2(xCoord, yCoord);

			Instantiate (enemy, spawnPosition, Quaternion.identity);
	}
}
