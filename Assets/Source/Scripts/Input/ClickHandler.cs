using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

	public static Vector3 PositionOfLastTap;

	public delegate void IsHeldDown();
	public static event IsHeldDown HeldDown; //event for when the user holds right click down

	public delegate void IsTapped();
	public static event IsTapped Tapped; //event for when the user taps and does not hold

	public delegate void IsReleaseHold();
	public static event IsReleaseHold ReleaseHold; //event for when the user releases from slowmo/hold

	public float timeRequiredToTriggerHold;
	bool holdCounter = false;
	float timeOfClick;
	float holdTime;

	public void EnableCounter()
	{
		PositionOfLastTap = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, PlayerController.cameraDistance));
		timeOfClick = Time.time;
		holdCounter = true;
	}

	public void DisableCounter()
	{
		if (holdTime <= timeRequiredToTriggerHold)
		{
			Tapped();
		}

		else
		{
			ReleaseHold();
		}
		holdCounter = false;

	}

	void OnEnable()
	{
		InputManager.OnHoldingDown += EnableCounter;
		InputManager.OnRelease += DisableCounter;
	}
	
	void OnDisable()
	{
		InputManager.OnHoldingDown -= EnableCounter;
		InputManager.OnRelease -= DisableCounter;
	}

	void Update()
	{
		if (holdCounter)
		{
			holdTime = Time.time - timeOfClick;
			if (holdTime > timeRequiredToTriggerHold)
			{
				holdCounter = false;
				HeldDown();
			}
		}
	}
}
