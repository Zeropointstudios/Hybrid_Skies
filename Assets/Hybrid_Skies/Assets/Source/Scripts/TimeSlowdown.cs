using UnityEngine;
using System.Collections;

public class TimeSlowdown : MonoBehaviour {

	public float timeMulitplier;

	public void EnableSlowmo()
	{
		Time.timeScale = timeMulitplier;
	}
	
	public void DisableSlowmo()
	{
		Time.timeScale = 1.0f;
	}

	void OnEnable()
	{
		InputManager.OnHoldingDown += EnableSlowmo;
		InputManager.OnRelease += DisableSlowmo;
	}
	
	void OnDisable()
	{
		InputManager.OnHoldingDown -= EnableSlowmo;
		InputManager.OnRelease -= DisableSlowmo;
	}
}
