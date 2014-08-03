using UnityEngine;
using System.Collections;

public class Absorb : MonoBehaviour {
	GameObject absorbFieldClone;
	public GameObject absorbField;

	// Instanciates the absorb prefab at the location of right-click.
	public void EnableAbsorb() 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		Vector3 point = ray.origin + (ray.direction * PlayerController.cameraDistance / 2); //creates position from which absorb field spawns
		absorbFieldClone = (GameObject)Instantiate (absorbField, point, Quaternion.identity);
	}

	public void DisableAbsorb()
	{
		Destroy (absorbFieldClone);
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

