using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour {

	float lifespan = 3f;
	// Use this for initialization
	void Start () {
		
		

	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;

		if (lifespan <= 0) Destroy(this.gameObject);

		print(lifespan);
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy(this.gameObject);
	}

	void CountdownToDestroy () {

		

		

		
		
	}
}
