using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour {

	int playerId = 0;
	Player player;
	Vector3 moveVector;
	float moveSpeed = 6f;

	Quaternion originalDir;

	Rigidbody2D rb;

	[Range(0, 10f)]
	public float rotationSpeed = 3f;


	void Awake () {
		player = ReInput.players.GetPlayer(playerId);
		originalDir = transform.rotation;
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}

	void GetInput () {
		moveVector.x = player.GetAxis("Horizontal Movement");
		moveVector.y = player.GetAxis("Vertical Movement");

		// print(moveVector.y);

		// // if (moveVector.y > 0) {
		// 	rb.velocity = transform.up * moveVector.y * moveSpeed;
		// // } 
		

		// if (moveVector.x < 0) {
			// transform.Rotate(Vector3.forward * rotationSpeed);

			// transform.rotation = Quaternion.LookRotation(moveVector.normalized);
		// }

		// else if (moveVector.x > 0) {
			transform.Rotate(Vector3.back * rotationSpeed);
		// }

		// print(transform.up + ", " + moveVector.normalized);

		rb.velocity = moveVector * moveSpeed;

		// var rotationDir = Quaternion.LookRotation(moveVector.normalized);
		// rotationDir *= originalDir;
		// transform.rotation = rotationDir;

	}

	Vector3 SquareVector(Vector3 v) {

		return new Vector3(v.x * v.x, v.y * v.y, v.z * v.z);

	}


	void RotateShip(Vector2 v) {
		//assume all rotation is positive
		if (v.x > 0) {
			if (v.y > 0 && transform.rotation.z != -45f) {
				// transform.Rotate(Vector3.forward * rotationSpeed);
				// transform.rotation = new Vector3(0,0, -1 *rotationSpeed);

				transform.rotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(0, 0, 0.5f));

				print("vel: " + rb.velocity + ", rotation: " + transform.rotation.z);
			}
		}
	} 
}
