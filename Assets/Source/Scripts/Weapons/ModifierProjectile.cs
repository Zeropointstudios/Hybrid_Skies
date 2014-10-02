using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifierProjectile : Weapon {
	ModifierCombo combo;
	void Awake() {
	}

	//when projectile is activated from object pool, it does the following
	void OnEnable() {
		combo = Finder.GetPlayer().GetComponent<PlayerController>().returnModCombo ();
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

	public void OnTriggerEnter(Collider other)									
	{
		if ((owner == WeaponOwner.Player && other.tag == "Enemy") 
		    || (owner == WeaponOwner.Enemy && other.tag == "Player"))
		{
			other.GetComponent<HitPoints>().DoDamage(damage, transform.position);		//damage the enemy hit by weapon
			//			Instantiate(destructionVFX);												//show the weapon exploding
			if (combo.returnBehavioral() != "RebounderModifier") {							//exception where we dont want it destroyed
				gameObject.SetActive(false);												//destroy the weapon instance
			}
		}
	}
}

