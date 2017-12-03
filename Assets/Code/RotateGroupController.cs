using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGroupController : MonoBehaviour {

	Rigidbody2D[] polygonRB;
	PolygonController[] polygonControls;
	PolygonCollider2D[] polygonColliders;

	// Use this for initialization
	void Start () {
		polygonRB = GetComponentsInChildren<Rigidbody2D>();
		polygonControls = GetComponentsInChildren<PolygonController>();
		polygonColliders = GetComponentsInChildren<PolygonCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivatePolygons () {
		transform.DetachChildren();
		foreach (Rigidbody2D rb in polygonRB) {
			Vector2 explodeVelocity = new Vector2(Random.Range(-4f, 4f), Random.Range(1-4, 4f));
			
			rb.velocity = explodeVelocity;
		}

		foreach (PolygonController pc in polygonControls)
		{
			pc.detachedFromEnemy = true;
		}

		foreach (PolygonCollider2D pc in polygonColliders)
		{
			pc.enabled = true;
		}
	}
}
