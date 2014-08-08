using UnityEngine;
using System.Collections;

public class StraightMover : Mover {
	public float speed;

	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
}
