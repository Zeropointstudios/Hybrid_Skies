using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

	public delegate void IsHeldDown();
	public static event IsHeldDown HeldDown;

	public delegate void IsTapped();
	public static event IsTapped Tapped;
	
	bool triggerCounter = false;
	float rightClickTime;
	float holdTime;

	public void EnableCounter()
	{
		rightClickTime = Time.time;
		triggerCounter = true;
	}

	public void DisableCounter()
	{
		if (holdTime <= 0.3f)
		{
//			Tapped();
		}
		triggerCounter = false;

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
		if (triggerCounter)
		{
			holdTime = Time.time - rightClickTime;
			if (holdTime > 0.3f)
			{
				triggerCounter = false;
				HeldDown();
			}
		}
	}
}
