using UnityEngine;
using System.Collections;

public class iPhonePauseHandler : MonoBehaviour {


#if UNITY_EDITOR
	//do nothing
#elif UNITY_IPHONE
	/*

	This needs to have the ship translate toward the position of Touch.Gettouch(0)

	it needs to have an event for when the player pushes down on the ships thumb holder which could be a collider or something that detects of a raycast, or we could just do a distance

	 */

//	Vector3 playerPosition;

	void Start () {
//		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}

	public delegate void PauseDelegate();
	public static event PauseDelegate Pause;

	public delegate void UnpauseDelegate();
	public static event UnpauseDelegate Unpause;

	void Update() {

		if (Input.GetTouch (0).phase == TouchPhase.Began)
		{
			Unpause();
		}
		
		if (Input.GetTouch(0).phase == TouchPhase.Ended) 
		{
			Pause();
		}

	}
#endif
}
