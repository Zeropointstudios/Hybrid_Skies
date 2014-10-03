using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BarbarianMover : Mover {
	public float findTargetPeriod;
	public int numJumpsBeforeTargetingPlayer = 3;
	public int numJumpsInBetweenTargetingPlayer = 1;

	private Vector3 target;
	private float angle;
	private int numJumpsAfterTargetingPlayer = 0;

	void Awake() {
	}
	
	void Start() {
		StartCoroutine("FindNewTarget");
	}
	
	// This is a coroutine that gets kicked off...
	IEnumerator FindNewTarget() {
		while (true) {
			bool targetPlayer = false;
			if (numJumpsBeforeTargetingPlayer > 0) {
				numJumpsBeforeTargetingPlayer--;
			} else if (numJumpsAfterTargetingPlayer > 0) {
				numJumpsAfterTargetingPlayer--;
			} else {
				targetPlayer = true;
				numJumpsAfterTargetingPlayer = numJumpsInBetweenTargetingPlayer;
			}

			if (targetPlayer)
				target = Finder.GetPlayer().transform.position;
			else 
				target = new Vector3(
					Random.Range(Finder.GetPlayerController().shipMovementBoundaryX1, Finder.GetPlayerController().shipMovementBoundaryX2), 
					0.0f,
					Random.Range(Finder.GetPlayerController().shipMovementBoundaryY1, Finder.GetPlayerController().shipMovementBoundaryY2)
					);

			yield return new WaitForSeconds (findTargetPeriod);		
			
		}
	}
	
	public override void Move() { //moves the object forward in the direction that the transform is facing
		if (target != null) {
			Vector3 targetLocation = target;
			Vector3 location = transform.position;

			Vector3 movement = targetLocation - location;
			float magnitude = movement.magnitude;
			
			if ( movement.magnitude > 1.0f ) {
				movement.Normalize();
			}
			
			transform.position = transform.position + movement * (speed * Time.deltaTime);
		}
	}
}	




