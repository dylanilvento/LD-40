using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	GameManager gm;
	Transform player;

	GameObject rotateGroup;

	[Range(0, 10f)]
	public float movementSpeed = 4f;
	
	[Range(0, 10f)]
	public float rotationSpeed;
	
	[Range(0, 10f)]
	public float radius;

	[Range(0, 100f)]
	public float viewDistance;
	Vector2 startPosition;

	bool spawnAnimationDone = false;

	float t;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		player = gm.GetPlayerTransform();
		rotateGroup = transform.GetChild(0).gameObject;


		startPosition = transform.position;
		StartCoroutine("PlaySpawnAnimation");

		

	}
	
	// Update is called once per frame
	void Update () {

		Move();
		
		// transform.Translate(player.position);
		// Vector2 movement = new Vector2(Random.Range(0f, 20f), Random.Range(0f, 20f));
		// transform.Translate(movement.normalized.x * movementSpeed, movement.normalized.y * movementSpeed, 0);

	}

	void Move() {
		Vector2 playerPosition = player.position;
		Vector2 currentPosition = transform.position;

		if (Vector2.Distance(playerPosition, currentPosition) < viewDistance && spawnAnimationDone) {
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
		
	}
}
