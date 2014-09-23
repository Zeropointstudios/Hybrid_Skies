using UnityEngine;
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
	public GameObject defenseVFX;
	ObjectPool squibPool;
	public int squibID;
	public int hitPoints;
	public int defense;   // damage done = damage - defense
	public ModifierType modifierType = ModifierType.None;
	public RaceType raceType = RaceType.None;
	public DefenseType defenseType = DefenseType.None;

	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 

	void Awake() {
		squibPool = GameObject.Find("SquibPool").GetComponent<ObjectPool>();
	}

	public void doDamage(int damage)
	{
		int effectiveDamage = Mathf.Max(damage - defense, 0);

		if ( defenseVFX != null && defense > .5 * damage ) {
			Instantiate(defenseVFX, transform.position, Quaternion.identity);
		}

		hitPoints -= effectiveDamage;

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
 