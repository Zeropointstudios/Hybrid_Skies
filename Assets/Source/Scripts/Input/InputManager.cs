using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Events
	public delegate void HoldingDownDelegate();
	public static event HoldingDownDelegate OnHoldingDown;

	public delegate void ReleaseDelegate();
	public static event ReleaseDelegate OnRelease;

	// TODO: Eventually need to add preprocessor constants to determine which platform we are using

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0) && OnHoldingDown != null) //event called on right-click down
		{
			OnHoldingDown();
		}

		if (Input.GetMouseButtonUp(0) && OnRelease != null) //event called on right-click up
		{
			OnRelease();
		}
	}
}