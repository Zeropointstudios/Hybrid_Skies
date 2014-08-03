using UnityEngine;
using System.Collections;

public class DirectionalMover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	public void SetDirection(Vector3 vector)
	{
		rigidbody.velocity = vector * speed;
	}
}
