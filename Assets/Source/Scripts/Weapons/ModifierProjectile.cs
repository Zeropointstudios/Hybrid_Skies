using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifierProjectile : Weapon {
	ModifierCombo combo;
	GameObject player;
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	//when projectile is activated from object pool, it does the following
	void OnEnable() {
		combo = player.GetComponent<PlayerController>().returnModCombo ();
		if (combo.returnElemental() != "") 
			gameObject.AddComponent (combo.returnElemental());
		if (combo.returnBehavioral() != "") 
			gameObject.AddComponent(combo.returnBehavioral());
	}

	//when projectile is disabled or hits an enemy
	void OnDisable() {
		if (combo.returnElemental() != "") 
			Destroy(GetComponent(combo.returnElemental()));
		if (combo.returnBehavioral() != "") 
			Destroy(GetComponent(combo.returnBehavioral()));
	}
}

