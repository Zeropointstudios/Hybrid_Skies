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

	//I have to rewrite this to have is target over
#if UNITY_EDITOR	
	void OnMouseEnter()
	{
		if (Absorb.cooldownCounter == 100) {
			// Instanciates the target graphic over target enemy.
			Vector3 targetSpawn = 
				new Vector3 (
					0.0f, 
					(Camera.main.transform.position.y / 2), 
					0.0f) 
					+ transform.position; 
			currentTargetInstance = (GameObject)Instantiate (targetingGraphic, targetSpawn, Quaternion.identity);
			currentTargetInstance.transform.parent = transform;
			print ("is true");
			isTargeted = true;
		}
	}
	
	void OnMouseExit()
	{
		Destroy (currentTargetInstance);
		isTargeted = false;
	}
#elif UNITY_IPHONE

	//this section is like OnMouseEnter for touch iOS

	bool isHitting = false;

	void Update() {
		//TODO maybe add this ray to a global variable or static variable so it isnt calculated by each enemy

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(
			new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y + 150.0f, PlayerController.cameraDistance)); //ray where second finger is placed
		if (collider.Raycast(ray, out hit, PlayerController.cameraDistance)) {  ///if this ship is getting hit by the above ray
			isHitting = true;
		}

		else {
			if (currentTargetInstance != null)	//if it is not getting hit, get rid of targeter if it exists
				Destroy (currentTargetInstance);
			isTargeted = false;
			isHitting = false;
		}

		if (isHitting == true && isTargeted == false && (Absorb.cooldownCounter == 100)) {
			Vector3 targetSpawn = new Vector3 (0.0f, (PlayerController.cameraDistance / 2), 0.0f) + transform.position; 
			currentTargetInstance = (GameObject)Instantiate (targetingGraphic, targetSpawn, Quaternion.identity);
			currentTargetInstance.transform.parent = transform;
			isTargeted = true;
		}
	}

	
#endif
	void AbsorbTarget()
	{
		if (isTargeted) // If target is hovering above enemy ship
		{
			// Absorb this ship's powers.
			ModifierType modifierInEnemy = gameObject.GetComponent<HitPoints>().returnModifierType(); //accesses the enemies mod type
			AbsorbModEvent(modifierInEnemy); //triggers an event that sends out the modifier data
			gameObject.GetComponent<HitPoints>().Kill(); //kills enemy which should actually deactivate it TODO
		}
	}
	
	
	void OnEnable() {
		ClickHandler.ReleaseHold += AbsorbTarget;
	}
	void OnDisable() {
		ClickHandler.ReleaseHold -= AbsorbTarget;
	}
}