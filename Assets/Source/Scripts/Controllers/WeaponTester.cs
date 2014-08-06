using UnityEngine;
using System.Collections;

public class WeaponTester : MonoBehaviour {
	public GameObject rebound, demo, poison, flower;
	public GUIText currentWeapon;
	GameObject secondaryWeapon;

	void Update () {

		if(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
		{
			GetComponent<SecondaryLaser>().SecondaryLaserProjectile = rebound;
			currentWeapon.text = "Rebounder";
		}

		if(Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
		{
			GetComponent<SecondaryLaser>().SecondaryLaserProjectile = demo;
			currentWeapon.text = "Area of Effect";
		}

		if(Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))
		{
			GetComponent<SecondaryLaser>().SecondaryLaserProjectile = poison;
			currentWeapon.text = "Poison DOT";
		}

		if(Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4))
		{
			GetComponent<SecondaryLaser>().SecondaryLaserProjectile = flower;
			currentWeapon.text = "Flower";
		}

	}
}
