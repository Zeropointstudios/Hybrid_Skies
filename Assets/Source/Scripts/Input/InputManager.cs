﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	

	// Events
	public delegate void HoldingDownDelegate();
	public static event HoldingDownDelegate OnHoldingDown;

	public delegate void ReleaseDelegate();
	public static event ReleaseDelegate OnRelease;


	void Update ()
	{
#if UNITY_EDITOR

		if (Input.GetMouseButtonDown(0) && OnHoldingDown != null) //event called on right-click down
		{
			OnHoldingDown();
		}

		if (Input.GetMouseButtonUp(0) && OnRelease != null) //event called on right-click up
		{
			OnRelease();
		}

#elif UNITY_IPHONE

		if (Input.GetTouch(1).phase == TouchPhase.Began && OnHoldingDown != null) //event called on second touch down
		{
			if (Pauser.isPaused == false)
			{
				OnHoldingDown();
			}
		}
		
		if (Input.GetTouch(1).phase == TouchPhase.Ended && OnRelease != null
		    || Input.GetTouch(0).phase == TouchPhase.Ended && OnRelease != null) //event called on second touch down
		{
			if (Pauser.isPaused == false)
			{
				OnRelease();
			}
		}
#endif

	}
}