﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax; //embeds class with sub-properties that can be modified in inspector
}

public class PlayerController : MonoBehaviour
{	
	public float timeSpeed;
	public float speed;
	public Boundary boundary;
	public float tilt;

	public static float cameraDistance;
	void Start()
	{
		cameraDistance = Camera.main.transform.position.y; //distance from camera to plane
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), //stops player from exiting the side of screen
		    0.0f,
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}