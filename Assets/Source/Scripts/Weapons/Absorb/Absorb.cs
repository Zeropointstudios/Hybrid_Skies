﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Absorb : MonoBehaviour {

	public static int cooldownCounter = 100;
	public float drainEnergySpeed;
	public Text cooldownDisplay;
	public GameObject absorbField, absorbFieldTarget;
	public float timeMultiplier;
	bool wasAbsorbEnabled = false;
	public AudioSource absorbEnableSound, absorbDisableSound, absorbDisableSound2;



	public int returnCoolDown(){return cooldownCounter;}

#if UNITY_EDITOR
	// Instanciates the absorb prefab at the location of right-click.
	public void EnableAbsorb() 
	{
		if (SecondaryFiring.energy>0) {
			Time.timeScale = timeMultiplier; //slows down time when event HeldDown is called
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			Vector3 point = ray.origin + (ray.direction * PlayerController.cameraDistance); //creates position from which absorb field spawns
			absorbField.transform.position = point;
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			wasAbsorbEnabled = true;
			absorbEnableSound.Play();
			StartCoroutine(drainEnergy());
		}
	}

#elif UNITY_IPHONE
	public void EnableAbsorb() 
	{
		if (SecondaryFiring.energy>0) {
			Time.timeScale = timeMultiplier; //slows down time when event HeldDown is called
			Vector3 point = Camera.main.ScreenToWorldPoint (
				new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y + 125.0f, PlayerController.cameraDistance / 2));
			absorbField.transform.position = point;
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			wasAbsorbEnabled = true;
			absorbEnableSound.Play();
			StartCoroutine(drainEnergy);

		}
	}

#endif

	public void DisableAbsorb()
	{
		if (wasAbsorbEnabled) {
			Time.timeScale = 1.0f; //resumes normal time when event OnRelease is caleld
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			absorbDisableSound.Play();
			absorbDisableSound2.Play();
			wasAbsorbEnabled = false;
		}
	}
	

	IEnumerator drainEnergy() {
		while (wasAbsorbEnabled) {
			if (SecondaryFiring.energy>0){
				GameObject.FindGameObjectWithTag("Player").GetComponent<SecondaryFiring>().subtractAbsorbEnergy(1);
				yield return new WaitForSeconds (drainEnergySpeed);

			}
			else {
				DisableAbsorb();
				absorbDisableSound.Play();
				absorbDisableSound2.Play();
			}
		}
	}

	void OnEnable()
	{
		ClickHandler.HeldDown += EnableAbsorb; // When event HeldDown is called, instanciate absorb.
		ClickHandler.ReleaseHold += DisableAbsorb;
	}
	
	void OnDisable()
	{
		ClickHandler.HeldDown -= EnableAbsorb;
		ClickHandler.ReleaseHold -= DisableAbsorb;
	}
}

