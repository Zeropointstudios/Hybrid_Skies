using UnityEngine;
using System.Collections;

public class DestroyForAbsorb : MonoBehaviour {

	void DestroyAbsorb ()
	{
		Destroy(gameObject);
	}

	void OnEnable()
	{
		InputManager.OnRelease += DestroyAbsorb;
	}

	void OnDisable()
	{
		InputManager.OnRelease -= DestroyAbsorb;
	}

	void FixedUpdate()
	{
		Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Absorb.cameraDistance));
		transform.position = Vector3.MoveTowards (transform.position, target, 0.5f);
		print (Input.mousePosition);
		print (transform.position + " absorbeR");
	}
}
