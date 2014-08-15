using UnityEngine;
using System.Collections;

public class StraightMover : Mover {

	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
}
