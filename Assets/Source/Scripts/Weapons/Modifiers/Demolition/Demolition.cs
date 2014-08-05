using UnityEngine;
using System.Collections;

public class Demolition : MonoBehaviour {

	public Collider splashCollider;
//	Collider splashInstance; //need this in order to access the explosion spawn for combinations.

	void OnTriggerEnter()
	{
		// Removed for now to remove warning.
		Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
	}
}
