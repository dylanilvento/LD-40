using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour {

	int playerId = 0;
	Player player;
	Vector3 moveVector;
	public float moveSpeed = 6f;

	Quaternion originalDir;

	Rigidbody2D rb;
	TrailRenderer tr;

	[Range(0, 10f)]
	public float rotationSpeed;

	public GameObject contrail;

	


	void Awake () {
		player = ReInput.players.GetPlayer(playerId);
		originalDir = transform.rotation;
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<TrailRenderer>();
	}

	// Use this for initialization
	void Start () {
		// float alpha = 0.5f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {new GradientColorKey(new Color32(186, 6, 96, 255), 0.0f), 
									new GradientColorKey(new Color32(142, 6, 81, 255), 1.0f) },

            new GradientAlphaKey[] {new GradientAlphaKey(0.5f, 0.0f), //red
									new GradientAlphaKey(0.25f, 1.0f) } //fushcia

			
            );
        tr.colorGradient = gradient;

		
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}

	void LateUpdate () {

	}

	void GetInput () {
		moveVector.x = player.GetAxis("Horizontal Movement");
		moveVector.y = player.GetAxis("Vertical Movement");

		
		transform.Rotate(Vector3.back * rotationSpeed);
	
		rb.velocity = moveVector * moveSpeed;
		

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
