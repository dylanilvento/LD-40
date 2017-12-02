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
		float alpha = 0.5f;
        // Gradient gradient = new Gradient();
        // gradient.SetKeys(
        //     new GradientColorKey[] {new GradientColorKey(new Color32(199, 15, 15, 255), 0.0f), //red
		// 							new GradientColorKey(new Color32(234, 201, 17, 255), 0.14f), //gold
		// 							new GradientColorKey(new Color32(140, 210, 28, 255), 0.28f), //lime green
		// 							new GradientColorKey(new Color32(28, 210, 59, 255), 0.42f), //bright green
		// 							new GradientColorKey(new Color32(28, 172, 210, 255), 0.56f), //cerulean
		// 							new GradientColorKey(new Color32(28, 59, 210, 255), 0.7f), //deep blue
		// 							new GradientColorKey(new Color32(155, 28, 210, 255), 0.84f), //purple
		// 							new GradientColorKey(new Color32(129, 28, 114, 255), 1.0f) }, //fushcia

        //     new GradientAlphaKey[] {new GradientAlphaKey(alpha, 0.0f), //red
		// 							new GradientAlphaKey(alpha, 0.14f), //gold
		// 							new GradientAlphaKey(alpha, 0.28f), //lime green
		// 							new GradientAlphaKey(alpha, 0.42f), //bright green
		// 							new GradientAlphaKey(alpha, 0.56f), //cerulean
		// 							new GradientAlphaKey(alpha, 0.7f), //deep blue
		// 							new GradientAlphaKey(alpha, 0.84f), //purple
		// 							new GradientAlphaKey(alpha, 1.0f) } //fushcia

			
        //     );
        // tr.colorGradient = gradient;

		
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}

	void LateUpdate () {
		// if (Mathf.Abs(moveVector.x) > 0 || Mathf.Abs(moveVector.y) > 0) {
		// 	GameObject spawnedContrail = (GameObject) Instantiate(contrail, transform.position, Quaternion.identity);
		// 	spawnedContrail.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
		// }
	}

	void GetInput () {
		moveVector.x = player.GetAxis("Horizontal Movement");
		moveVector.y = player.GetAxis("Vertical Movement");

		
		transform.Rotate(Vector3.back * rotationSpeed);
	
		rb.velocity = moveVector * moveSpeed;

		// if (Mathf.Abs(moveVector.x) > 0 || Mathf.Abs(moveVector.y) > 0) {
		// 	GameObject spawnedContrail = (GameObject) Instantiate(contrail, transform.position, Quaternion.identity);
		// 	spawnedContrail.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
		// }
		

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
