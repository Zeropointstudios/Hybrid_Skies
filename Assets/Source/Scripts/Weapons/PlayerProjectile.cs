using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectile : Weapon {
	
	List<string> weaponModifiers = new List<string> ();

	public void AddModifier(string name)
	{
		if (weaponModifiers.Count > 1)								//if there is already 2 modifiers attached
		{
			Component.Destroy(GetComponent(weaponModifiers[0]));	//get rid of oldest modifier attached to the projectile
			weaponModifiers.RemoveAt(0);							//remove the string from the weaponMod list
			weaponModifiers.Add (name);								//Add the new modifier string to list
			gameObject.AddComponent(name);							//Add the new modifier component to the projectile
		}

		else 														//when there is 0 or 1 mods attached
		{		
			weaponModifiers.Add (name);								//just add new mod to projectile
			gameObject.AddComponent(name);
		}
	}

	
}


