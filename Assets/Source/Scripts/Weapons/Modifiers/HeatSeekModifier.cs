using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeatSeekModifier : MonoBehaviour {
	
	Vector3 target;
	float counter = 0;

	void Awake() {
		Destroy (GetComponent<SecondaryFiring> ());
	}

	void Start() {
		RadarSweep ();
		GetComponent<Mover> ().speed = 15.0f;
	}

	void RadarSweep()
	{
		var transformArray = GameObject.FindGameObjectsWithTag("Enemy")
			.Select(go => go.transform.position)
				.OrderBy(t => Vector3.SqrMagnitude(t - transform.position))
				.ToArray();
		target = transformArray [0];
	}

	void Update() {
		gameObject.transform.LookAt(target);
		counter += Time.deltaTime;
		if (counter > 2) { //find new target
			RadarSweep();
			counter = 0;
		}

	}
}
