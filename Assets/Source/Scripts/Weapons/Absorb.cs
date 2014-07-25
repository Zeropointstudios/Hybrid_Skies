using UnityEngine;
using System.Collections;

public class Absorb : MonoBehaviour {
	
	public GameObject absorbField;
	public static float cameraDistance;
	public static bool isAbsorbing = false;

	void Start()
	{
		cameraDistance = Camera.main.transform.position.y; //distance from camera to plane
	}

	public void EnableAbsorb() //instanciates the absorb prefab at the location of right-click
	{
		AbsorbIsOn ();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		Vector3 point = ray.origin + (ray.direction * cameraDistance / 2); //creates position from which absorb field spawns
		Instantiate (absorbField, point, Quaternion.identity);
	}

	public void AbsorbIsOn()
	{
		isAbsorbing = true;
	}

	public void AbsorbIsOff()
	{
		isAbsorbing = false;
	}
	
	void OnEnable()
	{
		ClickHandler.HeldDown += EnableAbsorb; //when event HeldDown is called, instanciate absorb
		InputManager.OnRelease += AbsorbIsOff;
	}
	
	void OnDisable()
	{
		ClickHandler.HeldDown -= EnableAbsorb;
		InputManager.OnRelease -= AbsorbIsOff;

	}
}

