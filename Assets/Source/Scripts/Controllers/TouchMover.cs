using UnityEngine;
using System.Collections;

public class TouchMover : MonoBehaviour {

#if UNITY_EDITOR
	
#elif UNITY_IPHONE
	//must be attached to player

	void Update() {
		if (Pauser.isPaused == false)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (
			new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y + 150.0f, PlayerController.cameraDistance)); //150 is offset to player can see ship
			transform.position = Vector3.MoveTowards(transform.position, target, 0.9f);
		}
	}
#endif 
}
