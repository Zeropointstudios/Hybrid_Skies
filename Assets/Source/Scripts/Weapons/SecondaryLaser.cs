	using UnityEngine;
using System.Collections;

public class SecondaryLaser : MonoBehaviour {
	public Transform shotSpawn;
	public GameObject SecondaryLaserProjectile;

	public void FireSecondary()
	{
		Instantiate(SecondaryLaserProjectile, shotSpawn.position, Quaternion.identity);
	}

	void OnEnable()
	{
		ClickHandler.Tapped += FireSecondary;
	}

	void OnDisable()
	{
		ClickHandler.Tapped -= FireSecondary;
	}
}
