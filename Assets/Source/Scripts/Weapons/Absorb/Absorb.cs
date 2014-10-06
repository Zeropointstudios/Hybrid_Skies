using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Absorb : MonoBehaviour {

	public static int cooldownCounter = 100;
	public float cooldownSpeed;
	public Text cooldownDisplay;
	public GameObject absorbField, absorbFieldTarget;
	public float timeMultiplier;
	bool wasAbsorbEnabled = false;

	public int returnCoolDown(){return cooldownCounter;}

#if UNITY_EDITOR
	// Instanciates the absorb prefab at the location of right-click.
	public void EnableAbsorb() 
	{
		if (cooldownCounter == 100) {
			Time.timeScale = timeMultiplier; //slows down time when event HeldDown is called
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			Vector3 point = ray.origin + (ray.direction * PlayerController.cameraDistance); //creates position from which absorb field spawns
			absorbField.transform.position = point;
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			wasAbsorbEnabled = true;
		}
	}

#elif UNITY_IPHONE
	public void EnableAbsorb() 
	{
		if (cooldownCounter == 100) {
			Time.timeScale = timeMultiplier; //slows down time when event HeldDown is called
			Vector3 point = Camera.main.ScreenToWorldPoint (
				new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y + 125.0f, PlayerController.cameraDistance / 2));
			absorbField.transform.position = point;
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			wasAbsorbEnabled = true;
		}
	}

#endif

	public void DisableAbsorb()
	{
		if (wasAbsorbEnabled) {
			Time.timeScale = 1.0f; //resumes normal time when event OnRelease is caleld
			absorbField.BroadcastMessage("Toggle");
			absorbFieldTarget.BroadcastMessage("Toggle");
			wasAbsorbEnabled = false;
		}
	}
	

	IEnumerator countUp() {
		while (cooldownCounter < 100) {
			cooldownCounter += 1;
			cooldownDisplay.text = cooldownCounter.ToString();
			if (cooldownCounter == 100)
				cooldownDisplay.text = "Ready";
			yield return new WaitForSeconds (cooldownSpeed);
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

