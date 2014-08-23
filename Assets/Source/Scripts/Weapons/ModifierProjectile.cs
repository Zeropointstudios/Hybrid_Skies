using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifierProjectile : Weapon {
	ModifierCombo combo;
	GameObject player;
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnEnable() {
		combo = player.GetComponent<PlayerController>().returnModCombo ();
		if (combo.elementalModifier != null) 
			gameObject.AddComponent (combo.elementalModifier.returnName());
		if (combo.behavioralModifier != null) 
			gameObject.AddComponent(combo.behavioralModifier.returnName());
	}

	void OnDisable() {
		if (combo.elementalModifier != null) 
			Destroy (combo.elementalModifier);
		if (combo.behavioralModifier != null) 
			Destroy(combo.behavioralModifier);
	}
}

