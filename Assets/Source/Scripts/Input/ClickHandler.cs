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


#if UNITY_EDITOR

	public void EnableCounter()
	{
		PositionOfLastTap = Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x,Input.mousePosition.y, PlayerController.cameraDistance));
		timeOfClick = Time.time;
		holdCounter = true;
	}

	public void DisableCounter()
	{
		if (holdTime <= timeRequiredToTriggerHold)
		{
			if ( Tapped != null )
			{
				Tapped();
			}
		}
		else
		{
			if ( ReleaseHold != null )
			{
				ReleaseHold();
			}
		}
		holdCounter = false;
	}
	
	void Update()
	{
		if (holdCounter)
		{
			holdTime = Time.time - timeOfClick;
			if (holdTime > timeRequiredToTriggerHold)
			{
				holdCounter = false;
				if ( HeldDown != null ) 
				{
					HeldDown();
				}
			}
		}
	}
	
#elif UNITY_IPHONE

	public void EnableCounter()
	{
		PositionOfLastTap = Camera.main.ScreenToWorldPoint(
			new Vector3(Input.touches[1].position.x, Input.touches[1].position.y, PlayerController.cameraDistance));
		timeOfClick = Time.time;
		holdCounter = true;
	}
	
	public void DisableCounter()
	{
		if (holdTime <= timeRequiredToTriggerHold)
		{
			if ( Tapped != null )
			{
				Tapped();
			}
		}
		else
		{
			if ( ReleaseHold != null )
			{
				ReleaseHold();
			}
		}
		holdCounter = false;
	}



	void Update()
	{

		if (holdCounter)
		{
			holdTime = Time.time - timeOfClick;
			if (holdTime > timeRequiredToTriggerHold)
			{
				holdCounter = false;
				if ( HeldDown != null ) 
				{
					HeldDown();
				}
			}
		}
	}


#endif

}
