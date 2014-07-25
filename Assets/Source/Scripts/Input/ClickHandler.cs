using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

	public delegate void IsHeldDown();
	public static event IsHeldDown HeldDown; //event for when the user holds right click down

	public delegate void IsTapped();
	public static event IsTapped Tapped; //event for when the user taps and does not hold

	public float timeRequiredToTriggerHold;
	bool holdCounter = false;
	float timeOfClick;
	float holdTime;

	public void EnableCounter()
	{
		timeOfClick = Time.time;
		holdCounter = true;
	}

	public void DisableCounter()
	{
		if (holdTime <= timeRequiredToTriggerHold)
		{
			print ("tap");
			//Tapped();
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
