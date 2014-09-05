#if UNITY_EDITOR

using UnityEngine;
using System.Collections;

public class TouchMover : MonoBehaviour {

#elif UNITY_IPHONE
	//must be attached to player

	void Update() {
		Vector3 target = Camera.main.ScreenToWorldPoint (
			new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, PlayerController.cameraDistance));
		transform.position = Vector3.MoveTowards(transform.position, target + 1.5f, 0.9f);
	}
#endif 
}
