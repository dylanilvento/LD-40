using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	GameObject parentGroup;


	GameObject player;
	GameManager gm;
	public GameObject bullet;

	public Color enemyColor;
	
	[Range(0, 15f)]
	public float bulletSpeed;

	[Range(0, 10f)]
	public float timeBetweenShots;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		parentGroup = transform.parent.gameObject;
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		if (!gm.playerDead) player = gm.GetPlayer();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartShootingCoroutine() {
		StartCoroutine("Shoot");
		print("test");
	}

	IEnumerator Shoot () {
		while (!gm.playerDead) {
			
			
			float t = Random.Range(timeBetweenShots, timeBetweenShots + 3f);
			
			yield return new WaitForSeconds(t);
			Vector2 shootVector = (player.transform.position - transform.position).normalized;
			GameObject spanwnedBullet = Instantiate (bullet, transform.position, Quaternion.identity);
			spanwnedBullet.GetComponent<SpriteRenderer>().color = enemyColor;

			spanwnedBullet.GetComponent<Rigidbody2D>().velocity = shootVector * bulletSpeed;
			
		}
	}



	void OnCollisionEnter2D (Collision2D other) {
		

		if (other.gameObject.layer == 8 || other.gameObject.layer == 9) {
			// print(other.gameObject.layer);

			parentGroup.transform.DetachChildren();
			Destroy(parentGroup);
			GetComponent<RotateGroupController>().ActivatePolygons();
			Instantiate (explosion, transform.position, Quaternion.identity);
			transform.DetachChildren();
			Destroy(this.gameObject);

		}
	}
}
