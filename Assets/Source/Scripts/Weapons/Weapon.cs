using UnityEngine;
using System.Collections;


public class Weapon : MonoBehaviour {

	public int damage;																	//how much damage the weapon does
//	public GameObject graphic, destructionVFX;											//the art assets attached to the weapon and who shot the weapon
	public enum WeaponOwner {Player, Enemy};
	public WeaponOwner owner;

	virtual public void OnTriggerEnter(Collider other)									//virtual because most weapons will do Damage and then be destroyed, the few odd cases will be overwritten
	{
		if ((owner == WeaponOwner.Player && other.tag == "Enemy") 
		   || (owner == WeaponOwner.Enemy && other.tag == "Player"))
		{
			other.GetComponent<HitPoints>().doDamage(damage);							//damage the enemy hit by weapon
//			Instantiate(destructionVFX);												//show the weapon exploding
			ObjectPool squibPool = other.GetComponent<HitPoints>().returnSquibPool();
			int squibID = other.GetComponent<HitPoints>().returnSquibID();
			squibPool.Activate(squibID, other.transform.position, Quaternion.identity);				//hit object bleeds
			gameObject.SetActive(false);												//destroy the weapon instance
		}
	}
}