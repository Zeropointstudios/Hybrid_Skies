using UnityEngine;
using System.Collections;

public class Demolition : MonoBehaviour {

	public Collider splashCollider;

	// Removed for now to remove warning.
	//Collider splashInstance; 

	void OnTriggerEnter()
	{
		// Removed for now to remove warning.
		//splashInstance = (Collider)Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
	}
}
