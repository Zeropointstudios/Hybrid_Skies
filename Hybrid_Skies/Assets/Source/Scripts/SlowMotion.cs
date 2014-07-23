using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {

	public float timeMultiplier;

	public void EnableSlowmo()
	{
		Time.timeScale = timeMultiplier;
	}
	
	public void DisableSlowmo()
	{
		Time.timeScale = 1.0f;
	}

	void OnEnable()
	{
		InputManager.OnRelease += DisableSlowmo;
		ClickHandler.HeldDown += EnableSlowmo;
	}
	
	void OnDisable()
	{
		InputManager.OnRelease -= DisableSlowmo;
		ClickHandler.HeldDown -= EnableSlowmo;
	}
}
