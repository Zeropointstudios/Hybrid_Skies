using UnityEngine;
using System.Collections;

public class TankMover : Mover {
	public float seekingPeriod;
	public float elevatePeriod;

	private bool seeking = true;
	private float vdir = 1.0f;

	GameObject player;
	void Awake() {
	}

	void Start() {
		StartCoroutine("Movement");
	}
	
	IEnumerator Movement() {
		while (!onScreen)
			yield return null;

		// Go Down
		seeking = false;
		vdir = -1.0f;
		yield return new WaitForSeconds (elevatePeriod * 2.0f);	
		
		while (true) {
			if (onScreen) {
				// Seeking
				seeking = true;
				vdir = 0.0f;
				yield return new WaitForSeconds (seekingPeriod);				

				// Go Down
				seeking = false;
				vdir = -1.0f;
				yield return new WaitForSeconds (elevatePeriod);				

				// Seeking
				seeking = true;
				vdir = 0.0f;
				yield return new WaitForSeconds (seekingPeriod);				

				// Go Up
				seeking = false;
				vdir = 1.0f;
				yield return new WaitForSeconds (elevatePeriod);		
			} else
				yield return null;
		}
	}

	public override void Move() { //moves the object forward in the direction that the transform is facing
		float dir = 0.0f;
		if (seeking) {
			float x = transform.position.x;
			float targetX = Finder.GetPlayer().transform.position.x;
			dir = Mathf.Clamp(targetX - x, -1.0f, 1.0f);
		}

		transform.position = new Vector3(
			transform.position.x + dir * (speed * Time.deltaTime),
			transform.position.y,
			transform.position.z + vdir * (speed * Time.deltaTime)
		);
	}
}	




