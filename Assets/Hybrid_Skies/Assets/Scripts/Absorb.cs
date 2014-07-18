using UnityEngine;
using System.Collections;

public class Absorb : MonoBehaviour {
	
	public GameObject absorbField;
	private float cameraDistance;
	bool isAbsorbing;
	void Start()
	{
		isAbsorbing = false;
		cameraDistance = Camera.main.transform.position.y;
	}

	public void EnableAbsorb()
	{
		if (isAbsorbing == false) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			Vector3 point = ray.origin + (ray.direction * cameraDistance / 2); //creates vector from which radial menu spawns
			Instantiate (absorbField, point, Quaternion.identity);
			isAbsorbing = true;
		}
	}
	public void DisableAbsorb()
	{
		isAbsorbing = false;
	}

	void OnEnable()
	{
		InputManager.OnHoldingDown += EnableAbsorb;
		InputManager.OnRelease += DisableAbsorb;
	}
	
	void OnDisable()
	{
		InputManager.OnHoldingDown -= EnableAbsorb;
		InputManager.OnRelease -= DisableAbsorb;
	}
}

