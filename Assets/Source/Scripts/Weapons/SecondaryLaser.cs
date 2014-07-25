using UnityEngine;
using System.Collections;

public class SecondaryLaser : MonoBehaviour {

	public GameObject SecondaryLaserProjectile;

	public void FireSecondary()
	{
		Instantiate(SecondaryLaserProjectile, GameObject.FindWithTag("Player").GetComponent<PlayerController>().shotSpawn.position, Quaternion.identity);
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
