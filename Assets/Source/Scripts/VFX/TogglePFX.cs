using UnityEngine;
using System.Collections;

public class TogglePFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Toggle()
	{
		if (particleSystem)
			{
			if (particleSystem.isStopped)
			{
				particleSystem.Play ();
			}
			else
			{
				particleSystem.Stop();
			}
		}
	}
}
