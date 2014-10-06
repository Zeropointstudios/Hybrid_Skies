using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BarbarianMover : Mover {
	public float huntPlayerPeriod = 4;
	public float huntRandomTargetPeriod = 2;
	public int numJumpsBeforeTargetingPlayer = 3;
	public int numJumpsInBetweenTargetingPlayer = 1;
	public float angleUpdateClamp;
	public float angularSpeed;
	public float randomTargetX0;
	public float randomTargetX1;
	public float randomTargetY0;
	public float randomTargetY1;

	private Vector3 target;
	private float targetAngle;
	public float angle;
	private int numJumpsAfterTargetingPlayer = 0;
	private bool targetPlayer = false;

	void Awake() {
		// Convert public parameters from degrees to radians.
		angleUpdateClamp *= (Mathf.PI / 180);
		angularSpeed *= (Mathf.PI / 180);
		angle *= (Mathf.PI / 180);
	}
	
	void Start() {
		StartCoroutine("FindNewTarget");
	}
	
	// This is a coroutine that gets kicked off...
	IEnumerator FindNewTarget() {
		yield return null; // Wait a frame, so all Finder references are updated.

		while (true) {
			if (onScreen) {
				if (numJumpsBeforeTargetingPlayer > 0) {
					targetPlayer = false;
					numJumpsBeforeTargetingPlayer--;
				} else if (numJumpsAfterTargetingPlayer > 0) {
					targetPlayer = false;
					numJumpsAfterTargetingPlayer--;
				} else {
					targetPlayer = true;
					numJumpsAfterTargetingPlayer = numJumpsInBetweenTargetingPlayer;
				}

				if (targetPlayer) {
					yield return new WaitForSeconds (huntPlayerPeriod);	
				}
				else { 
					float x = Random.Range(randomTargetX0, randomTargetX1);
					float y = Random.Range(randomTargetY0, randomTargetY1);
					target = new Vector3(x, 0, y);

					yield return new WaitForSeconds (huntRandomTargetPeriod);	
				}
			} else
				yield return null;
		}
	}
	
	public override void Move() { //moves the object forward in the direction that the transform is facing
		if (targetPlayer)
			target = Finder.GetPlayer().transform.position;

		if (target != null) {
			Vector3 location = transform.position;

			Vector3 movement = target - location;

			if (movement.magnitude > 1) {
				
				targetAngle = Mathf.Atan2(movement.z, movement.x);
			
				if (angle - targetAngle < -Mathf.PI)
					angle += 2 * Mathf.PI;

				if (angle - targetAngle > Mathf.PI)
					angle -= 2 * Mathf.PI;

				float angleUpdate = targetAngle - angle;
				angleUpdate = Mathf.Clamp(angleUpdate, -angleUpdateClamp, angleUpdateClamp);

				angle += angleUpdate * (angularSpeed * Time.deltaTime);

				transform.rotation = Quaternion.Euler(0, 90 - (angle * Mathf.Rad2Deg), 0);
			}

			transform.position = transform.position + transform.forward * (speed * Time.deltaTime);
		}
	}
}	




