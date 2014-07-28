using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour {

	//this script must be attached to all Absorbable ships
	public GameObject targetingGraphic; //holds the prefab to be used
	GameObject currentTargetInstance;
	bool isTargeted = false;
	
	void OnMouseEnter()
	{
		Vector3 targetSpawn = new Vector3 (0.0f, (Camera.main.transform.position.y/2),0.0f) + transform.position; //instanciates the target graphic over target enemy
		currentTargetInstance = (GameObject)Instantiate(targetingGraphic, targetSpawn, Quaternion.identity);
		currentTargetInstance.transform.parent = transform;
		isTargeted = true;
	}

	void AbsorbTarget()
	{
		if (isTargeted) //if enemy ship is absorbed, destroy it
		{
			Destroy(gameObject);
			//absorb this ships powers
		}
	}

	void OnMouseExit()
	{
		Destroy (currentTargetInstance);
		isTargeted = false;
	}

	void OnEnable()
	{
		ClickHandler.ReleaseHold += AbsorbTarget;
	}
	
	void OnDisable()
	{
		ClickHandler.ReleaseHold -= AbsorbTarget;
		
	}

}