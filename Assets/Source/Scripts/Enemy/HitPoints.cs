using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also

	public int hitPoints;
	public ModifierType modifierType = ModifierType.None;

	public void doDamage(int damage)
	{
		hitPoints -= damage;

		if (hitPoints < 1)
		{
			gameObject.SetActive(false);
		}
	}

	public ModifierType returnModifierType() {return modifierType;} 
}
