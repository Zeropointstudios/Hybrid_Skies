using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectile : Weapon {
	
	List<string> weaponModifiers = new List<string> ();

	public void AddModifier(string name)
	{
		if (weaponModifiers.Count > 1)
		{
			Component.Destroy(GetComponent(weaponModifiers[1]));
			weaponModifiers.Remove(0);
			weaponModifiers.Add (name);
			gameObject.AddComponent(GetComponent(name));
		}

		else
		{
			weaponModifiers.Add (name);
			gameObject.AddComponent(GetComponent(name));
		}
}
