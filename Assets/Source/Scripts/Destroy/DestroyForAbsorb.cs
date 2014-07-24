using UnityEngine;
using System.Collections;

public class DestroyForAbsorb : MonoBehaviour {

	void DestroyAbsorb ()
	{
		Destroy(gameObject); //destroys absorb prefab when right click is released.
	}

	void OnEnable()
	{
		InputManager.OnRelease += DestroyAbsorb;
	}

	void OnDisable()
	{
		InputManager.OnRelease -= DestroyAbsorb;
	}
	
}
