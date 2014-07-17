using UnityEngine;
using System.Collections;

public class TimeSlowdown : MonoBehaviour {

	public static void EnableSlowmo()
	{
		Time.timeScale = 0.1f;
	}
	
	public static void DisableSlowmo()
	{
		Time.timeScale = 1.0f;
	}
}
