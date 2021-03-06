using System.Collections;
using System.Collections.Generic;
#if unity_editor
using UnityEditor;
#endif
using UnityEngine;

public class ClericMover : Mover {
	public float findTargetPeriod;
	public float orbitingRange;
	public float influenceRange;
	public float healingRate;

	GameObject targetEnemy = null;
	void Awake() {
	}

	void Start() {
		StartCoroutine("FindNewTarget");
	}
	
	// This is a coroutine that gets kicked off...
	IEnumerator FindNewTarget() {
		yield return null; // Wait a frame, so all Finder references are updated.

		while (true) {
			if (onScreen) {
				// Find the enemy with the fewest hit points (other than the current target and itself)
				GameObject bestEnemy = null;
				float bestUtility = Mathf.NegativeInfinity;
				foreach (GameObject enemy in Finder.GetEnemies()) {
					// Lowest ratio of health gets healed.
					float utility = -(enemy.GetComponent<HitPoints>().hitPoints / enemy.GetComponent<HitPoints>().initialHitPoints); 
					if (utility > bestUtility && enemy != targetEnemy && enemy != gameObject) {
						bestUtility = utility;
						bestEnemy = enemy;
					}
				}
				if (bestEnemy != null)
					targetEnemy = bestEnemy;

				yield return new WaitForSeconds (findTargetPeriod);		
			} else
				yield return null;
		}
	}

	public override void Move() { //moves the object forward in the direction that the transform is facing
		if (targetEnemy != null) {
			Vector3 targetLocation = targetEnemy.transform.position;
			Vector3 location = transform.position;
			Vector3 dir = targetLocation - location;
			Vector3 orbitingLocation = targetLocation - dir * (orbitingRange / Mathf.Max(dir.magnitude, 1.0f));

			Vector3 movement = orbitingLocation - location;
			float magnitude = movement.magnitude;

			if ( movement.magnitude > 1.0f ) {
				movement.Normalize();
			}

			transform.position = transform.position + movement * (speed * Time.deltaTime);

			Vector3 offsetFromTarget = targetLocation - location;
			if (offsetFromTarget.magnitude < influenceRange) {
				targetEnemy.GetComponent<HitPoints>().Heal(healingRate * Time.deltaTime);
			}
		}
	}
}	




