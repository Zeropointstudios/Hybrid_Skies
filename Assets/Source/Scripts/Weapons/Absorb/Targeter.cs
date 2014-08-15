using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour {

	// This script must be attached to all Absorbable ships
	public GameObject targetingGraphic; // Holds the prefab to be used.
	GameObject currentTargetInstance;
	bool isTargeted = false;
	
	void OnMouseEnter()
	{
		// Instanciates the target graphic over target enemy.
		Vector3 targetSpawn = 
			new Vector3 (
				0.0f, 
				(Camera.main.transform.position.y / 2), 
				0.0f) 
			+ transform.position; 
		currentTargetInstance = (GameObject)Instantiate (targetingGraphic, targetSpawn, Quaternion.identity);
		currentTargetInstance.transform.parent = transform;
		isTargeted = true;
	}

	void AbsorbTarget()
	{
		if (isTargeted) // If enemy ship is absorbed, destroy it.
		{
			// Absorb this ship's powers.
			Destroy(gameObject);
		}
	}

	void OnMouseExit()
	{
		Destroy (currentTargetInstance);
		isTargeted = false;
	}

	void OnEnable()
	{
		ClickHandler.ReleaseHold += AbsorbTarget;
	}
	
	void OnDisable()
	{
		ClickHandler.ReleaseHold -= AbsorbTarget;
		
	}

}