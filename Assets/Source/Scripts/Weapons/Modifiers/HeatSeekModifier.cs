using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeatSeekModifier : MonoBehaviour {
	
	Vector3? target = null;
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
		// Find the enemy that's closest.
		GameObject bestEnemy = null;
		float bestUtility = Mathf.NegativeInfinity;
		foreach (GameObject enemy in Finder.GetEnemies()) {
			// Lowest ratio of health gets healed.
			float utility = -(Vector3.SqrMagnitude(enemy.transform.position - transform.position));
			if (utility > bestUtility) {
				bestUtility = utility;
				bestEnemy = enemy;
			}
		}
		if (bestEnemy != null)
			target = bestEnemy.transform.position;
	}

	void Update() {
		// Weird, I can comment this out and it still works.
		if (target.HasValue)
			gameObject.transform.LookAt(target.Value);
		counter += Time.deltaTime;
		if (counter > 2) { //find new target
			RadarSweep();
			counter = 0;
		}

	}
}
