using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
		while (true) {
			// Find the enemy with the fewest hit points (other than the current target and itself)
			GameObject bestEnemy = null;
			float bestUtility = Mathf.NegativeInfinity;
			print ("EVALUATING ENEMIES:");
			foreach (GameObject enemy in Finder.GetEnemies()) {
				if (enemy.tag != "Enemy")
					continue;
				if (enemy.hideFlags == HideFlags.NotEditable || enemy.hideFlags == HideFlags.HideAndDontSave) {
					print ("Wrong flags");
					continue;
				}

				if (PrefabUtility.GetPrefabType(enemy) == PrefabType.Prefab) {
					print ("Ignore prefab");
					continue;
				}

				print ("Potential enemy: " + enemy);
				print ("  tag: " + enemy.tag);
				print ("  prefab type: " + PrefabUtility.GetPrefabType(enemy));
				print ("  location: " + enemy.transform.position);
				print ("  hit points: " + enemy.GetComponent<HitPoints>().hitPoints);

				
				//string assetPath = AssetDatabase.GetAssetPath(enemy.transform.root.gameObject);
				//if (!string.IsNullOrEmpty(assetPath)) {
				//	print ("Wrong path");
				//	continue;
				//}

				float utility = -enemy.GetComponent<HitPoints>().hitPoints;

				print ("  utility: " + utility);
				if (utility > bestUtility && enemy != targetEnemy && enemy != gameObject) {
					bestUtility = utility;
					bestEnemy = enemy;
				}
			}
			if (bestEnemy != null)
				targetEnemy = bestEnemy;

			print ("Target enemy: " + targetEnemy);
			
			print ("Target enemy's position: " + targetEnemy.transform.position); 

			print ("Best utility: " + bestUtility);

			Debug.DebugBreak();

			yield return new WaitForSeconds (findTargetPeriod);		

		}
	}

	public override void Move() { //moves the object forward in the direction that the transform is facing
		if (targetEnemy != null) {
			//print ("targetEnemy: " + targetEnemy);
			Vector3 targetLocation = targetEnemy.transform.position;
			//print ("targetLocation: " + targetLocation);
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




