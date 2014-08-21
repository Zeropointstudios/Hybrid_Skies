﻿using UnityEngine;
using System.Collections;

public class PoisonModifier : ElementalModifier {
	
	public GameObject poisonCounter;
	GameObject poisonCounterInstance;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			poisonCounterInstance = (GameObject)Instantiate (poisonCounter, transform.position, Quaternion.identity);
			poisonCounterInstance.transform.parent = other.transform;
		}
	}

	public override void OnProjectileInit(Projectile projectile) {

	}
	public override void OnProjectileDestroy(Projectile projectile) {
		//Instanciate VFX
	}
}
