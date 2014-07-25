using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour {

	public GameObject targetingGraphic; //holds the prefab to be used
	GameObject currentTargetInstance;
	
	void OnMouseEnter()
	{
		if (Absorb.isAbsorbing)
		{
			Vector3 targetSpawn = new Vector3 (0.0f, (Camera.main.transform.position.y/2),0.0f) + transform.position; //instanciates the target graphic over target enemy
			currentTargetInstance = (GameObject)Instantiate(targetingGraphic, targetSpawn, Quaternion.identity);
			currentTargetInstance.transform.parent = transform;
		}
	}

	void OnMouseExit()
	{
		Destroy (currentTargetInstance);
	}
	

}