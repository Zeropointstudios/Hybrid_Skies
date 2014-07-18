using UnityEngine;
using System.Collections;

public class Absorb : MonoBehaviour {
	
	public GameObject absorbField;
	private float cameraDistance;
	void Start()
	{
		cameraDistance = Camera.main.transform.position.y;
	}
	
	public void moveAbsorbField ()
	{
		absorbField.transform.position = Vector3.MoveTowards (absorbField.transform.position, Input.mousePosition, 0.5f);
	}

	public void EnableAbsorb()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		Vector3 point = ray.origin + (ray.direction * cameraDistance / 2); //creates vector from which radial menu spawns
		absorbField = Instantiate (Resources.Load("Prefabs/Absorber"), point, Quaternion.identity) as GameObject;
	}
	public void DisableAbsorb()
	{
		Destroy (absorbField);
	}
}

