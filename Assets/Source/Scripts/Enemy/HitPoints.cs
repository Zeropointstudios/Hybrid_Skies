using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX;
	public int hitPoints;
	public ModifierType modifierType = ModifierType.None;

	public void doDamage(int damage)
	{
		hitPoints -= damage;

		if (hitPoints < 1)
		{
			Kill ();
		}
	}

	public void Kill()
	{
		Instantiate(deathVFX, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

	public ModifierType returnModifierType() {return modifierType;} 
}
