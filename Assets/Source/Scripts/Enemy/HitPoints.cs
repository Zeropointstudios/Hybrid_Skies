using UnityEngine;
using UnityEngine.UI;
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

// TODO: rename HitPoints to Ship, so it can hold properties about ships (like it basically does now).
public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX, shieldExplodeVFX;
	ObjectPool squibPool;
	public int squibID;
	public int armorFXID;
	public int shieldFXID;
	public float hitPoints;
	public float initialHitPoints;
	public float defense;   // damage done = damage - defense
	public float maxShields;
	public float shields;
	public Text shieldDisplay, healthDisplay;
	public ModifierType modifierType = ModifierType.None;
	public RaceType raceType = RaceType.None;
	public DefenseType defenseType = DefenseType.None; //pretty sure we decided that this does not matter and they can have both
	public bool hasShields;
	public bool isPlayer;
	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 
	public bool transcendsBoundary = false;  // If it can cross the game boundary without dying.

	void Awake() {
		squibPool = GameObject.Find("SquibPool").GetComponent<ObjectPool>();
		shields = maxShields;
		initialHitPoints = hitPoints;
		if (isPlayer){
			shieldDisplay.text = shields.ToString ();
			healthDisplay.text = hitPoints.ToString ();
		}
	}

	IEnumerator ShieldRegeneration() {
		while (hasShields)
		{
			yield return new WaitForSeconds(1);	//regenerates shields every second
				if (shields < maxShields)
					shields +=1;
		}
	}

	public void DoDamage(float damage, Vector3 projectilePosition)
	{
		//if there are shields take away from them first
		if (hasShields) {

			if (shields >= damage) {
				shields -= damage;
				squibPool.Activate(shieldFXID, transform.position, Quaternion.identity);
				shieldDisplay.text = shields.ToString ();
				return;
			}
			else {
				damage -= shields;
				shields = 0;
				shieldDisplay.text = shields.ToString ();
				hasShields = false;
				Instantiate(shieldExplodeVFX, projectilePosition, Quaternion.identity);
			}
		}

		if (defense > 0) {
			float effectiveDamage = Mathf.Max(damage - defense, 0);

			if (defense > .5 * damage ) {	//shows armor hits if the weapon is doing less than half its original damage
				squibPool.Activate(armorFXID, projectilePosition, Quaternion.identity); //shows armor vfx hit
			}

			else {
				squibPool.Activate(squibID, projectilePosition, Quaternion.identity); //shows normal vfx hit

			}
			hitPoints -= effectiveDamage;

		}

		else { //if there is no armor or shields, do what is left of damage (including reduction from shield)
			squibPool.Activate(squibID, projectilePosition, Quaternion.identity); //shows normal vfx hit
			hitPoints -= damage;
		}


		if (hitPoints < 1 && gameObject.activeSelf == true) {
			Kill ();
		}


		if (isPlayer) {
			shieldDisplay.text = shields.ToString ();
			healthDisplay.text = hitPoints.ToString ();
		}
	}
	
	public void Heal(float healing)
	{
		hitPoints = Mathf.Min(hitPoints + healing, initialHitPoints);
	}

	public void Kill()
	{
		Instantiate(deathVFX, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

}
 