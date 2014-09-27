using UnityEngine;
using System.Collections;

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
		GameObject[] enemies = Finder.GetEnemies();
		
		while (true) {
			// Find the enemy with the fewest hit points (other than the current target and itself)
			GameObject bestEnemy = null;
			float bestUtility = Mathf.NegativeInfinity;
			foreach (GameObject enemy in enemies) {
				float utility = -enemy.GetComponent<HitPoints>().hitPoints;
				if (utility > bestUtility && enemy != targetEnemy && enemy != gameObject) {
					bestUtility = utility;
					bestEnemy = enemy;
				}
			}
			if (bestEnemy != null)
				targetEnemy = bestEnemy;

			yield return new WaitForSeconds (findTargetPeriod);				
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




