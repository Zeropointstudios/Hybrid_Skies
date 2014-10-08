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

// This is basically a Ship class (we're holding off from renaming since that is inconvenient for now).
public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX, shieldExplodeVFX, energyPowerUp;
	ObjectPool squibPool;
	public int energyBonusID; //5 if big unit, 6 if medium unit, 7 is small unit
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
	public DefenseType defenseType = DefenseType.None;  // Pretty sure we decided that this does not matter and they can have both.
	public bool hasShields;
	public bool isPlayer;
	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 
	public bool transcendsBoundary = false;  // If it can cross the game boundary without dying.

	public bool onScreen = false;  // Indicates that the enemy is to be awakened now that it is on-screen.


	//audio FX - quick implementation - todo: call from separate script / audio in object pool?
	public AudioSource SFXshieldDamage;
	public AudioSource SFXshieldDestroy;
	public AudioSource SFXunArmoredDamage; //- if this is active, then spawned enemies don't have sound assigned (get an error) - EN
	public AudioSource SFXDestroy;

	void Awake() {
		squibPool = GameObject.Find("SquibPool").GetComponent<ObjectPool>();
		shields = maxShields;
		initialHitPoints = hitPoints;
		if (isPlayer){
			shieldDisplay.text = shields.ToString ();
			healthDisplay.text = hitPoints.ToString ();
		}

		if (hasShields) {
			StartCoroutine("ShieldRegeneration");
		}

		// Set to initially off-screen.
		onScreen = false;
		gameObject.SendMessage ("SetOnScreen", false, SendMessageOptions.DontRequireReceiver);
	}

	// Once an enemy comes on-screen, it becomes on-screen (i.e. active).
	public void EnterBoundary()
	{
		// Once it's on-screen...
		onScreen = true;
		gameObject.SendMessage ("SetOnScreen", true, SendMessageOptions.DontRequireReceiver);
	}

	public void Update () 
	{
		// Move the enemy ship down a little bit from offscreen (above the screen) toward the screen, until it is on-screen.
		if (!onScreen)
		{
			this.transform.position -= new Vector3(0, 0, GameController.GetScreenDrop());
		}
	}

	IEnumerator ShieldRegeneration() {
		while (hasShields)
		{
			yield return new WaitForSeconds(1);	//regenerates shields every second
				if (shields < maxShields)
					shields +=2;
		}
	}

	public void DrainLife(float amount) {
		hitPoints -= amount;
	}

	public void DoDamage(float damage, Vector3 projectilePosition)
	{
		//if there are shields take away from them first
		if (hasShields) {

			if (shields >= damage) {
				shields -= damage;
				squibPool.Activate(shieldFXID, transform.position, Quaternion.identity);
				if (isPlayer)
					shieldDisplay.text = shields.ToString ();
				if (SFXshieldDamage != null)
					SFXshieldDamage.Play(); //sound FX
				return;
			}
			else {
				damage -= shields;
				shields = 0;
				if (isPlayer)
					shieldDisplay.text = shields.ToString ();
				hasShields = false;
				Instantiate(shieldExplodeVFX, projectilePosition, Quaternion.identity);
				SFXshieldDestroy.Play(); //sound FX
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
			if (SFXunArmoredDamage != null) {
				SFXunArmoredDamage.Play(); //Sound FX
			}
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

		if (!isPlayer)
			Finder.GetObjectPool().Activate(energyBonusID, transform.position, Quaternion.identity);
			
		if (SFXDestroy != null)
			SFXDestroy.Play(); //Sound FX
	
		gameObject.SetActive(false);
	}

}
 