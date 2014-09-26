﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public enum RaceType {
	None,

	Organic,
	Tech
};

[System.Serializable]
public enum DefenseType {
	None,
	
	Armor,
	Shield
};

public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX;
	ObjectPool squibPool;
	public int squibID;
	public int armorFXID;
	public int shieldFXID;
	public int hitPoints;
	public int defense;   // damage done = damage - defense
	public int maxShields;
	int shields;
	public ModifierType modifierType = ModifierType.None;
	public RaceType raceType = RaceType.None;
	public DefenseType defenseType = DefenseType.None; //pretty sure we decided that this does not matter or exist @Aaron from Pablo
	public bool hasShields;

	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 

	void Awake() {
		squibPool = GameObject.Find("SquibPool").GetComponent<ObjectPool>();
		shields = maxShields;

	}

	IEnumerator ShieldRegeneration() {
		while (hasShields)
		{
			yield return new WaitForSeconds(1);	//regenerates shields every second
				if (shields < maxShields)
					shields +=1;
		}
	}

	public void doDamage(int damage)
	{
		//if there are shields take away from them first
		if (hasShields) {
			if (shields >= damage) {
				shields -= damage;
				squibPool.Activate(shieldFXID, transform.position, Quaternion.identity);
			}

			else
				damage -= shields;
				shields = 0;

		}

		if (defense > 0) {
			int effectiveDamage = Mathf.Max(damage - defense, 0);

			if (defense > .5 * damage ) {	//shows armor hits if the weapon is doing less than half its original damage
				squibPool.Activate(armorFXID, transform.position, Quaternion.identity); //shows armor vfx hit
			}

			else
				squibPool.Activate(squibID, transform.position, Quaternion.identity); //shows normal vfx hit
			hitPoints -= effectiveDamage;

		}

		else //if there is no armor or shields, do what is left of damage (including reduction from shield)
			squibPool.Activate(squibID, transform.position, Quaternion.identity); //shows normal vfx hit
			hitPoints -= damage;


		if (hitPoints < 1 && gameObject.activeSelf == true)
		{
			Kill ();
		}
	}

	public void Kill()
	{
		Instantiate(deathVFX, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

}
 