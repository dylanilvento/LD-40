using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Transform player;

	[Range(0f,5)]
	public float dampening;
	float maxY = 0, minY = -9.3f, maxX = 18.5f, minX = -1f;
	GameManager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		player = gm.GetPlayerTransform();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!gm.playerDead) FollowPlayer();

	}

	void FollowPlayer() {
		if ((player.position.x < transform.position.x - dampening) && transform.position.x > minX) {

			if ((player.position.y < transform.position.y - dampening) && transform.position.y > minY) {

				transform.Translate(-6 * Time.deltaTime, -6 * Time.deltaTime, 0);
				
			}

			else if ((player.position.y > transform.position.y + dampening) && transform.position.y < maxY) {

				transform.Translate(-6 * Time.deltaTime, 6 * Time.deltaTime, 0);
				
			}

			else {
				transform.Translate(-6 * Time.deltaTime, 0, 0);
			}
			
			
		}

		else if ((player.position.x > transform.position.x + dampening) && transform.position.x < maxX) {

			if ((player.position.y < transform.position.y - dampening) && transform.position.y > minY) {

				transform.Translate(6 * Time.deltaTime, -6 * Time.deltaTime, 0);
				
			}

			else if ((player.position.y > transform.position.y + dampening) && transform.position.y < 0) {

				transform.Translate(6 * Time.deltaTime, 6 * Time.deltaTime, 0);
				
			}

			else {
				transform.Translate(6 * Time.deltaTime, 0, 0);
			}
			
		}

		if ((player.position.y < transform.position.y - dampening) && transform.position.y > minY) {

			if ((player.position.x < transform.position.x - dampening) && transform.position.x > minX) {

				transform.Translate(-6 * Time.deltaTime, -6 * Time.deltaTime, 0);
			}

			else if ((player.position.x > transform.position.x + dampening) && transform.position.x < maxX) {

				transform.Translate(6 * Time.deltaTime, -6 * Time.deltaTime, 0);
			}

			else {
				transform.Translate(0, -6 * Time.deltaTime, 0);
			}
			
			
		}

		else if ((player.position.y > transform.position.y + dampening) && transform.position.y < maxY) {

			if ((player.position.x < transform.position.x - dampening) && transform.position.x > minX) {

				transform.Translate(-6 * Time.deltaTime, 6 * Time.deltaTime, 0);
			}

			else if ((player.position.x > transform.position.x + dampening) && transform.position.x < maxX) {

				transform.Translate(6 * Time.deltaTime, 6 * Time.deltaTime, 0);
			}

			else {
				transform.Translate(0, 6 * Time.deltaTime, 0);
			}
			
		}
	}


}
