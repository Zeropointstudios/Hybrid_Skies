using UnityEngine;
using System.Collections;

public class DestroyForAbsorb : MonoBehaviour {

	void DestroyAbsorb ()
	{
		Destroy(gameObject);
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
