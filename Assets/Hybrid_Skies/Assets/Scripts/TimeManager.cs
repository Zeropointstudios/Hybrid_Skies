using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

	//public static float progressDelayCounter;

	void progressDelayTracker()
	{

	}

	void OnEnable()
	{
		InputManager.OnHoldingDown += progressDelayTracker;
	}

	void OnDisable()
	{
		InputManager.OnHoldingDown -= progressDelayTracker;
	}

}
