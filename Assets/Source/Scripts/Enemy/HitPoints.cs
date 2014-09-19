using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX;
	public GameObject shieldVFX;
	ObjectPool squibPool;
	public int squibID;
	public int hitPoints;
	public int shield;    // damage done = damage - shield
	public ModifierType modifierType = ModifierType.None;

	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 

	void Awake() {
		squibPool = GameObject.Find("SquibPool").GetComponent<ObjectPool>();
	}

	public void doDamage(int damage)
	{
		int effectiveDamage = Mathf.Max(damage - shield, 0);

		if ( shield > .5 * damage && shieldVFX != null) {
			Instantiate(shieldVFX, transform.position, Quaternion.identity);
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
 