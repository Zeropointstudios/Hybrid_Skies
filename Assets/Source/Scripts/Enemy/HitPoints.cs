using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

	public int hitPoints;
	public ModifierType modifierType = ModifierType.None;

	public void doDamage(int damage)
	{
		hitPoints -= damage;

		if (hitPoints < 1)
		{
			Destroy(gameObject);
		}
	}
}
