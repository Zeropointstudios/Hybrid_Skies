using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	//events
	public delegate void HoldingDownDelegate();
	public static event HoldingDownDelegate OnHoldingDown;

	public delegate void ReleaseDelegate();
	public static event ReleaseDelegate OnRelease;


	//eventually need to add preprocessor constants to determine what platform we are using

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			OnHoldingDown();
			print ("down");
		}

		if (Input.GetMouseButtonUp(0))
		{
			OnRelease();
			print ("up");
		}

	}

}