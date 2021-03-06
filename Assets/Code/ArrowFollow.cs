﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour {

	public Transform target;

	GameManager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		if (target == null) {
			target = gm.GetPlayerTransform();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!gm.playerDead) FollowPlayer();
	}

	void FollowPlayer () {
		Vector3 vectorToTarget = target.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
	}
}
