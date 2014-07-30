using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {
	public static HitPoints instance; //global class instance variable
	public int hitPoints;

	public void doDamage(int damage)
	{
		hitPoints -= damage;

		if (hitPoints < 1)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		instance = this;
	}
}
