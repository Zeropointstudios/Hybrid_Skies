using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

	//TODO make enemies have a pool also
	public GameObject deathVFX;
	ObjectPool squibPool;
	public int squibID;
	public int hitPoints;
	public ModifierType modifierType = ModifierType.None;

	public ObjectPool returnSquibPool(){return squibPool;}
	public int returnSquibID(){return squibID;}
	public ModifierType returnModifierType() {return modifierType;} 

	void Awake() {
		squibPool = GameObject.Find ("SquibPool").GetComponent<ObjectPool>();
	}

	public void doDamage(int damage)
	{
		hitPoints -= damage;

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
