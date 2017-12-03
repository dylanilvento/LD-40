using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject enemy;
	float maxTime = 5f;
	float minTime = 1f;

	float[] xRange = {-3f, 25f};
	float[] yRange = {-12f, 4f};
	void Start () {
		StartCoroutine("SpawnEnemies");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnEnemies () {
		while (true) {
			float t = Random.Range(minTime, maxTime);
			yield return new WaitForSeconds(t);

			float xCoord = Random.Range(xRange[0], xRange[1]);
			float yCoord = Random.Range(yRange[0], yRange[1]);

			Vector2 spawnPosition = new Vector2(xCoord, yCoord);

			Instantiate (enemy, spawnPosition, Quaternion.identity);

		}
	}
}
