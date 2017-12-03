using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	GameObject parentGroup;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		parentGroup = transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other) {
		print(other.gameObject.layer);

		if (other.gameObject.layer == 8) {

			parentGroup.transform.DetachChildren();
			Destroy(parentGroup);
			GetComponent<RotateGroupController>().ActivatePolygons();
			Instantiate (explosion, transform.position, Quaternion.identity);
			transform.DetachChildren();
			Destroy(this.gameObject);

		}
	}
}
