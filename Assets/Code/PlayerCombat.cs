using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCombat : MonoBehaviour {
	public GameObject bullet, explosion;
	int playerId = 0;
	Player player;
	
	public int currentScore = 0;
	public int maxScore = 0;
	List<GameObject> polygons = new List<GameObject>();

	GameManager gm;
	PlayerMovement playerMovement;
	TrailRenderer tr;
	float baseMoveSpeed;

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
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		playerMovement = GetComponent<PlayerMovement>();
		baseMoveSpeed = playerMovement.moveSpeed;
		tr = GetComponent<TrailRenderer>();
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

	public void IncrementPolygonCount (GameObject polygon) {
		
		currentScore++;
		if (currentScore > maxScore) maxScore = currentScore;
		// print("test");
		polygons.Add(polygon);
		AdjustArmorRadius();
	}

	public void AdjustArmorRadius () {
		
		// polygonRatio = 32f * polygonCount/(20f+polygonCount);
		polygonRatio = 32f * polygons.Count/(20f+polygons.Count);
		
		// armorRadius = polygonCount / (polygonRatio * Mathf.PI);
		armorRadius = polygons.Count / (polygonRatio * Mathf.PI);
		

		AdjustPlayerStats();

	}

	public void DecrementPolygonCount(GameObject polygon) {
		if (currentScore > 0) currentScore--;
		polygons.Remove(polygon);

		if (polygons.Count == 0) {

			// polygons = new List<GameObject>();

		
		}

		else {
			AdjustArmorRadius();
		}
		
		
	}

	void AdjustPlayerStats () {
		// timeBetweenShots = 0.08f + (polygonCount * 0.0025f);
		// playerMovement.moveSpeed = baseMoveSpeed - (polygonCount * 0.01f);
		// tr.time = 0.5f + (polygonCount * 0.001f);

		timeBetweenShots = 0.08f + (polygons.Count * 0.0025f);
		playerMovement.moveSpeed = baseMoveSpeed - (polygons.Count * 0.01f);
		tr.time = 0.5f + (polygons.Count * 0.001f);
	}


	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.layer == 10 || other.gameObject.layer == 11) {
			
			TakeDamage();
		}
	}

	void TakeDamage() {
		print("took damage");
		int count = Random.Range(5, 20);


		if (polygons.Count == 0) {
			Die();
		}

		else if (count > polygons.Count) {
			foreach (GameObject polygon in polygons) {

				polygon.GetComponent<PolygonController>().StartDestroyCoroutine();
			}

			
		}

		else {
			for (int ii = polygons.Count - count; ii < polygons.Count; ii++) {

				polygons[ii].GetComponent<PolygonController>().StartDestroyCoroutine();
				// polygons.RemoveAt(ii);
			}
		}
	}

	void Die() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		gm.GameOver(maxScore);
		Destroy(this.gameObject);

		
	}

}
