using UnityEngine;
using System.Collections;

public class TimeSlowdown : MonoBehaviour {

	public void EnableSlowmo()
	{
		Time.timeScale = 0.2f;
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
