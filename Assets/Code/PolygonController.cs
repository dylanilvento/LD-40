using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonController : MonoBehaviour {

	Transform player;
	GameObject playerGo;
	GameManager gm;
	[Range(0, 10f)]
	public float movementSpeed;

	[Range(0, 10f)]
	public float viewDistance;
	public bool detachedFromEnemy = false, attachedToPlayer = false;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		player = gm.GetPlayerTransform();
		// playerGo = GameObject.FindGameObjectWithTag("Player");
		// player = playerGo.transform;

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (detachedFromEnemy && !attachedToPlayer) {
			Magnetize();
		}
		
	}

	void FixedUpdate () {
		Vector2 playerPosition = player.position;
		Vector2 currentPosition = transform.position;
		
		if (!attachedToPlayer && (Vector2.Distance(playerPosition, currentPosition) < player.gameObject.GetComponent<PlayerCombat>().GetArmorRadius())) {
			// print("Test");
			// transform.SetParent(player);
			transform.SetParent(player, true);
			attachedToPlayer = true;
			// player.gameObject.GetComponent<PlayerCombat>().IncrementArmorRadius();

			TestDistanceAwayFromPlayer(player.gameObject.GetComponent<PlayerCombat>().GetArmorRadius());

		}
	}

	void Magnetize () {
		Vector2 playerPosition = player.position;
		Vector2 currentPosition = transform.position;

		// print(Vector2.Distance(playerPosition, currentPosition) + " < " + player.gameObject.GetComponent<PlayerCombat>().GetArmorRadius());
		// print(Vector2.Distance(playerPosition, currentPosition) < player.gameObject.GetComponent<PlayerCombat>().GetArmorRadius());

		if (Vector2.Distance(playerPosition, currentPosition) < viewDistance) {
			// print("Test");
			Vector2 relativePositionNormal = (playerPosition - currentPosition).normalized;
			// transform.Translate(relativePositionNormal.x * Time.deltaTime * movementSpeed, relativePositionNormal.y * Time.deltaTime * movementSpeed, 0);
			transform.position = Vector2.MoveTowards(currentPosition, playerPosition, Time.deltaTime * movementSpeed);
			// rotateGroup.transform.Rotate(Vector3.back * rotationSpeed);

			
			
		}

		
	}

	void TestDistanceAwayFromPlayer (float distance) {
		Vector2 playerPosition = player.position;
		Vector2 currentPosition = transform.position;
		while (Vector2.Distance(playerPosition, currentPosition) > distance) {
			Vector2 relativePositionNormal = (playerPosition - currentPosition).normalized;
			
			transform.position = Vector2.MoveTowards(currentPosition, playerPosition, Time.deltaTime * movementSpeed);
		}
	}

	// void OnTriggerEnter2D (Collider2D other) {
	// 	if (other.gameObject.layer == 12 && !attachedToPlayer) {
	// 		transform.SetParent(player);
	// 		attachedToPlayer = true;
	// 		print("TEST");
	// 	}
	// }
}
