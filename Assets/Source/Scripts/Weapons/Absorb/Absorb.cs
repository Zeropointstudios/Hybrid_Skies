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
	public AudioSource absorbEnableSound, absorbEnableSound2, absorbDisableSound, absorbDisableSound2, absorbLoop;



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
			absorbEnableSound2.Play();
			absorbLoop.Play();
			StartCoroutine(DrainEnergy());
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
			absorbEnableSound2.Play();
			absorbLoop.Play();
			StartCoroutine(DrainEnergy());

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
			absorbLoop.Stop();
			wasAbsorbEnabled = false;
		}
	}
	

	IEnumerator DrainEnergy() {
		while (wasAbsorbEnabled) {
			if (SecondaryFiring.energy>0){
				GameObject.FindGameObjectWithTag("Player").GetComponent<SecondaryFiring>().SubtractAbsorbEnergy(1);
				yield return new WaitForSeconds (drainEnergySpeed);

			}
			else {
				DisableAbsorb();
				absorbLoop.Stop();
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

