using UnityEngine;
using System.Collections;


public class Weapon : MonoBehaviour {

	public int damage;																	//how much damage the weapon does
	public GameObject graphic, destructionVFX;											//the art assets attached to the weapon
	public Transform owner;															//the location from which the weapon spawns
	
	virtual public void OnTriggerEnter(Collider other)									//virtual because most weapons will do Damage and then be destroyed, the few odd cases will be overwritten
	{
		if ((owner.transform.gameObject.tag == "Player" && other.tag == "Enemy") 
		    || (owner.transform.gameObject.tag == "Enemy" && other.tag == "Player"))
		{
			other.GetComponent<HitPoints>().doDamage(damage);							//damage the enemy hit by weapon
			Instantiate(destructionVFX);												//show the weapon exploding
			gameObject.SetActive(false);												//destroy the weapon instance
		}
	}
}