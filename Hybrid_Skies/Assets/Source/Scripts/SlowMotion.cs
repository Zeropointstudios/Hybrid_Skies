using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {

	public float timeMultiplier;

	public void EnableSlowmo()
	{
		Time.timeScale = timeMultiplier; //slows down time when event HeldDown is called
	}
	
	public void DisableSlowmo()
	{
		Time.timeScale = 1.0f; //resumes normal time when event OnRelease is caleld
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
