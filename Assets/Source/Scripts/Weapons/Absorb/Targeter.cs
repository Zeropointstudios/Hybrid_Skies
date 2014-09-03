using UnityEngine;
using System.Collections;
using System;

public class Targeter : MonoBehaviour {

	// This script must be attached to all Absorbable enemy ships
	public GameObject targetingGraphic; // Holds the prefab to be used.
	GameObject currentTargetInstance;
	bool isTargeted = false;

	public delegate void AbsorbModDelegate(ModifierType mod);
	public static event AbsorbModDelegate AbsorbModEvent;
	
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
		if (isTargeted) // If target is hovering above object
		{
			// Absorb this ship's powers.
			ModifierType modifierInEnemy = gameObject.GetComponent<HitPoints>().returnModifierType(); //accesses the enemies mod type
			AbsorbModEvent(modifierInEnemy); //triggers an event that sends out the modifier data
			Destroy(gameObject); //kills enemy which should actually deactivate it TODO
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