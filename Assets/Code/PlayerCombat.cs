using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCombat : MonoBehaviour {
	public GameObject bullet;
	int playerId = 0;
	Player player;
	
	[Range(0, 15f)]
	public int polygonCount = 0;

	float polygonRatio;

	// float percentile = 0.1f;
	float timeBetweenShots = 0.08f;
	float timeUntilNextShot;
	[Range(0, 15f)]
	public float bulletSpeed;

	float armorRadius = 0.01f;
	float armorRadiusRate = 0.025f;

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

		else if (timeUntilNextShot >= 0){
			timeUntilNextShot -= Time.deltaTime;
		}
	}

	public float GetArmorRadius () {
		return armorRadius;
	}

	public void IncrementPolygonCount () {
		polygonCount++;
	}

	public void IncrementArmorRadius () {
		polygonRatio = 32f * polygonCount/(100f+((polygonCount/50) * 50));
		// armorRadius = polygonCount / ((32 * (polygonCount/100f)) * Mathf.PI);
		armorRadius = polygonCount / (polygonRatio * Mathf.PI);
		print(polygonRatio);
	}
}
