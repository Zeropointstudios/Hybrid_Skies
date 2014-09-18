using UnityEngine;
using System.Collections;

public class DirectionalMover : Mover {

	Vector3 directionVector = new Vector3 (0, 0, 0);

	public void SetDirection(Vector3 direction) {
		directionVector = direction;
	}

	public override void Move() {
		transform.Translate(directionVector * Time.deltaTime * speed);
	}
}
