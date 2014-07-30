using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {
	
	public GameObject poisonCounter;
	GameObject poisonCounterInstance;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			poisonCounterInstance = (GameObject)Instantiate(poisonCounter, new Vector3 (0.0f, (PlayerController.cameraDistance/2),0.0f) + transform.position, Quaternion.identity);
			poisonCounterInstance.transform.parent = other.transform;
		}

	}


}
