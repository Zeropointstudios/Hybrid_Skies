using UnityEngine;
using System.Collections;

public class Demolition : MonoBehaviour {

	public Collider splashCollider;
	Collider splashInstance;

	void OnTriggerEnter()
	{
		splashInstance = (Collider)Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
	}
}
