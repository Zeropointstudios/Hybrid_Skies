using UnityEngine;
using System.Collections;

public class AbsorbMover : MonoBehaviour {

	void Update()
	
#if UNITY_EDITOR

	{				
		// Makes absorb field follow mouse while click is held down.
		Vector3 target = Camera.main.ScreenToWorldPoint (
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, PlayerController.cameraDistance));
		transform.position = Vector3.MoveTowards(transform.position, target, 0.9f);
	}

#elif UNITY_IPHONE
	{
		Vector3 target = Camera.main.ScreenToWorldPoint (
			new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y + 150.0f, PlayerController.cameraDistance));
		transform.position = Vector3.MoveTowards(transform.position, target, 0.9f);

	}
#endif
}
