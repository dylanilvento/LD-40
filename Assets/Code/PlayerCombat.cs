using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCombat : MonoBehaviour {
	public GameObject bullet;
	int playerId = 0;
	Player player;

	// float percentile = 0.1f;
	float timeBetweenShots = 0.08f;
	float timeUntilNextShot;
	float bulletSpeed = 8f;

	Vector2 shootVector;
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
		timeUntilNextShot = timeBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {

		Shoot();

	}

	public void SetTimeBetweenShots (float val) {
		// percentile = val;
		timeBetweenShots = val;
	}

	public void SetBulletSpeed (float val) {
		bulletSpeed = val;
	}

	void Shoot() {
		shootVector.x = player.GetAxis("Horizontal Shooting");
		shootVector.y = player.GetAxis("Vertical Shooting");

		if ((Mathf.Abs(shootVector.x) > 0 || Mathf.Abs(shootVector.y) > 0) && timeUntilNextShot <= 0) {
			timeUntilNextShot = timeBetweenShots;
			GameObject spawnedBullet = (GameObject) Instantiate (bullet, transform.position, Quaternion.identity);
			spawnedBullet.GetComponent<Rigidbody2D>().velocity = shootVector.normalized * bulletSpeed;
		}

		else {
			timeUntilNextShot -= Time.deltaTime;
		}
	}
}
