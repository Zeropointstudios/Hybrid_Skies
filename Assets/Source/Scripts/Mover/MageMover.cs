using UnityEngine;
using System.Collections;

public class MageMover : Mover {
	public float period;
	public float radius;
	private bool needsToMoveOnScreen = true;

	public float initialZ = 11.0f; // should be near the top of the screen.

	private Vector3 direction;

	void Start() {
		StartCoroutine("Movement");
	}

	// This is a coroutine that gets kicked off...
	IEnumerator Movement() {
		while (true) {
			if (onScreen) {
				Vector3 target;
				if (needsToMoveOnScreen) {
					needsToMoveOnScreen = false;
					target = new Vector3(
						transform.position.x,
						transform.position.y,
						initialZ  
					);
				} else {
					target = new Vector3(
						transform.position.x + Random.Range(-radius, radius),
						transform.position.y,
						transform.position.z + Random.Range(-radius, radius)
					);
				}
				direction = (target - transform.position) / (period * speed);
				yield return new WaitForSeconds (period);
			} else {
				needsToMoveOnScreen = true;
				yield return null;
			}
		}
	}

	public override void Move()
	{
		transform.position = transform.position + (direction * (speed * Time.deltaTime));
	}
}	

