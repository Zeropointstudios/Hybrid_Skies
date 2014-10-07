using UnityEngine;
using System.Collections;

public class StraightDownMover : Mover {
	public override void Move() {
		transform.Translate(new Vector3(0, 0, -0.1f) * speed);
	}
}
