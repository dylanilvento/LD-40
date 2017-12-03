using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("SelfDestruct");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SelfDestruct () {
		yield return new WaitForSeconds(0.75f);
		Destroy(this.gameObject);
	}
}
