using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetPlayer () {
		return player;
	}

	public Transform GetPlayerTransform () {
		return player.transform;
	}
}
