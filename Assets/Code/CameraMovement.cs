using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Transform player;

	[Range(0f,5)]
	public float dampening = 2.5f;
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
		if ((player.position.x < transform.position.x - dampening) && transform.position.x > 0) {

			if ((player.position.y < transform.position.y - dampening) && transform.position.y > -9.3f) {

				transform.Translate(-6 * Time.deltaTime, -6 * Time.deltaTime, 0);
				
			}

			else if ((player.position.y > transform.position.y + dampening) && transform.position.y < 0) {

				transform.Translate(-6 * Time.deltaTime, 6 * Time.deltaTime, 0);
				
			}

			else {
				transform.Translate(-6 * Time.deltaTime, 0, 0);
			}
			
			
		}

		else if ((player.position.x > transform.position.x + dampening) && transform.position.x < 17.4) {

			if ((player.position.y < transform.position.y - dampening) && transform.position.y > -9.3f) {

				transform.Translate(6 * Time.deltaTime, -6 * Time.deltaTime, 0);
				
			}

			else if ((player.position.y > transform.position.y + dampening) && transform.position.y < 0) {

				transform.Translate(6 * Time.deltaTime, 6 * Time.deltaTime, 0);
				
			}

			else {
				transform.Translate(6 * Time.deltaTime, 0, 0);
			}
			
		}

		if ((player.position.y < transform.position.y - dampening) && transform.position.y > -9.3f) {

			if ((player.position.x < transform.position.x - dampening) && transform.position.x > 0) {

				transform.Translate(-6 * Time.deltaTime, -6 * Time.deltaTime, 0);
			}

			else if ((player.position.x > transform.position.x + dampening) && transform.position.x < 17.4) {

				transform.Translate(6 * Time.deltaTime, -6 * Time.deltaTime, 0);
			}

			else {
				transform.Translate(0, -6 * Time.deltaTime, 0);
			}
			
			
		}

		else if ((player.position.y > transform.position.y + dampening) && transform.position.y < 0) {

			if ((player.position.x < transform.position.x - dampening) && transform.position.x > 0) {

				transform.Translate(-6 * Time.deltaTime, 6 * Time.deltaTime, 0);
			}

			else if ((player.position.x > transform.position.x + dampening) && transform.position.x < 17.4) {

				transform.Translate(6 * Time.deltaTime, 6 * Time.deltaTime, 0);
			}

			else {
				transform.Translate(0, 6 * Time.deltaTime, 0);
			}
			
		}
	}


}
