using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondaryFiring : Firing { //handles player energy and secondary weapon math TODO put energy in separate class

	public Text energyDisplay;
	public static float energy = 100; 
	public int baseEnergyCost, modEnergyCost;
	int currentEnergyCost;

	//AudioSource mainGun01;
	public AudioSource secondWeapon01;

	void Awake() {
		autoFire = false;
		currentEnergyCost = baseEnergyCost;
	}

	public void SetEnergyCost(ModifierCombo combo) {								//determines cost of firing secondary weapon
		int totalCost = 0;
		if (combo.returnBehavioral() != ""){totalCost+=modEnergyCost;}
		if (combo.returnElemental() != ""){totalCost+=modEnergyCost;}
		totalCost += baseEnergyCost;
		currentEnergyCost = totalCost;
	}

	public void AddEnergy (float energyx) {
		energy += energyx;
		energyDisplay.text = energy.ToString();
	}

	public void SubtractAbsorbEnergy (float enemyHP) {
		energy -= enemyHP;
		energyDisplay.text = energy.ToString();
	}

	bool SubtractEnergy() {
		if ((energy - currentEnergyCost) >= 0) {										//checks to see if there is enough energy to fire
			energy -= currentEnergyCost;
			energyDisplay.text = energy.ToString();
			return true;
		}

		else {return false;}
	}

	void OnEnable() {
		ClickHandler.Tapped += FireProjectile;
	}
	
	void OnDisable() {
		ClickHandler.Tapped -= FireProjectile;
	}

	public override void FireProjectile() {
		if (SubtractEnergy()) {

			float hypotenuse, opposite, shotAngle; 
			Vector3 oppositePoint = new Vector3(shotSpawn.transform.position.x, 0, ClickHandler.PositionOfLastTap.z); //used to calculate opposite
			hypotenuse = Vector3.Distance(ClickHandler.PositionOfLastTap, shotSpawn.transform.position);
			opposite = Vector3.Distance (ClickHandler.PositionOfLastTap, oppositePoint);

			shotAngle = Mathf.Asin (opposite / hypotenuse) * Mathf.Rad2Deg;
			if (ClickHandler.PositionOfLastTap.z < shotSpawn.transform.position.z)	                        //determines if angle in 2nd or 3rd quad
				shotAngle = 180 - shotAngle;
			if (ClickHandler.PositionOfLastTap.x < shotSpawn.transform.position.x)							//determines positive or negative angle
				shotAngle = 360.0f - shotAngle;

			Finder.GetObjectPool().Activate (projectileID, shotSpawn.transform.position, Quaternion.Euler(0, shotAngle/2, 0));
			//substract from energy pool

			if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().returnModCombo().returnBehavioral() == "SpreadModifier"){ //if spread modifier is attached
				Finder.GetObjectPool().Activate (projectileID, shotSpawn.transform.position, Quaternion.Euler(0, shotAngle/2 + 9, 0));
				Finder.GetObjectPool().Activate (projectileID, shotSpawn.transform.position, Quaternion.Euler(0, shotAngle/2 - 9, 0));
			}

			AudioSource[] audios = GetComponents<AudioSource> ();
			secondWeapon01 = audios [1];
			secondWeapon01.Play();
		}
	}

}