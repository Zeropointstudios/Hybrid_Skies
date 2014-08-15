using UnityEngine;
using System.Collections;

public class DirectionalMover : Mover {

	public void SetDirection(Vector3 vector)
	{
		rigidbody.velocity = vector * speed;
	}
}
