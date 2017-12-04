using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	GameManager gm;
	Transform player;
	PlayerCombat playerCombat;

	GameObject rotateGroup;

	EnemyCombat enemyCombat;
	


	[Range(0, 10f)]
	public float movementSpeed = 4f;

	public SpriteRenderer[] polygons = new SpriteRenderer[6];
	
	[Range(0, 10f)]
	public float rotationSpeed;
	
	[Range(0, 10f)]
	public float radius;

	[Range(0, 100f)]
	public float maxViewDistance, minViewDistance;
	Vector2 startPosition;

	bool spawnAnimationDone = false;

	float t;
	// Use this for initialization
	void Start () {
		
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		
		if (!gm.playerDead) {
			player = gm.GetPlayerTransform();
			playerCombat = gm.GetPlayer().GetComponent<PlayerCombat>();
		
		}

		rotateGroup = transform.GetChild(0).gameObject;
		enemyCombat = transform.GetChild(0).GetComponent<EnemyCombat>();


		startPosition = transform.position;
		StartCoroutine("PlaySpawnAnimation");

		RandomizePolygonColor();

		

	}
	
	// Update is called once per frame
	void Update () {

		if (!gm.playerDead) Move();
		
		// transform.Translate(player.position);
		// Vector2 movement = new Vector2(Random.Range(0f, 20f), Random.Range(0f, 20f));
		// transform.Translate(movement.normalized.x * movementSpeed, movement.normalized.y * movementSpeed, 0);

	}

	void RandomizePolygonColor() {
		Color c = Random.ColorHSV(0f, 1f, 0.8f, 0.9f, 0.8f, 0.9f);

		foreach (SpriteRenderer sr in polygons) {
			sr.color = c;
		}

		enemyCombat.enemyColor = c;
	}

	void Move() {
		Vector2 playerPosition = player.position;
		Vector2 currentPosition = transform.position;

		if (Vector2.Distance(playerPosition, currentPosition) < (maxViewDistance + playerCombat.GetArmorRadius()) && Vector2.Distance(playerPosition, currentPosition) > (minViewDistance + playerCombat.GetArmorRadius()) && spawnAnimationDone) {
			Vector2 relativePositionNormal = (playerPosition - currentPosition).normalized;
			transform.Translate(relativePositionNormal.x * Time.deltaTime * movementSpeed, relativePositionNormal.y * Time.deltaTime * movementSpeed, 0);
			rotateGroup.transform.Rotate(Vector3.back * rotationSpeed);
		}

		else if (spawnAnimationDone) {
			// t += Time.deltaTime * movementSpeed;

			rotateGroup.transform.Rotate(Vector3.back * rotationSpeed);

			// float x = Mathf.Cos(t - transform.position.x);
			// float y = Mathf.Sin(t - transform.position.y);

			// float x = Mathf.Cos(t) + transform.position.x;
			// float y = Mathf.Sin(t) + transform.position.y;

			// float x = Mathf.Cos(t) + startPosition.x;
			// float y = Mathf.Sin(t) + startPosition.y + radius;


			// transform.position = new Vector2(x, y);
		}
	}

	IEnumerator PlaySpawnAnimation () {
		yield return new WaitForSeconds(2f);
		spawnAnimationDone = true;
		enemyCombat.StartShootingCoroutine();
		
	}
}
