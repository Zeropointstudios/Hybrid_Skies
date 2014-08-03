using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	public float speed;
	public float tilt;
	public GameBoundary boundary;

	public static float cameraDistance;
	void Start()
	{
		cameraDistance = Camera.main.transform.position.y; //distance from camera to plane

		boundary = GameObject.Find("Boundary").GetComponent<GameBoundary>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		// Stops player from exiting the side of screen.
		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x, -8, 8), 
		    0.0f,
			Mathf.Clamp(rigidbody.position.z, -3, 14)
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Destroy (gameObject);
		}
	}

}
