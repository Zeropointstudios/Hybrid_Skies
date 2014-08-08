using UnityEngine;
using System.Collections;

public class DirectionalMover : Mover {

	public float speed;

	public void SetDirection(Vector3 vector)
	{
		rigidbody.velocity = vector * speed;
	}
}
