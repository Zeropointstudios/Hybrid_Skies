using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeatSeekModifierEnemy : MonoBehaviour {
	
	GameObject player;
	bool isSeeking = true;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start() {
		StartCoroutine ("Seek");
	}

	IEnumerator Seek() {
		if (player != null) 
			yield return new WaitForSeconds (0.5f);
			while (isSeeking) {
				yield return new WaitForSeconds (0.5f);
				gameObject.transform.LookAt(player.transform.position);
		}
	}
}
