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
		transform.position = Vector3.MoveTowards (transform.position, Input.mousePosition, 0.5f);
	}
}
