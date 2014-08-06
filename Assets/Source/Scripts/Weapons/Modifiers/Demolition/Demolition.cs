using UnityEngine;
using System.Collections;

public class Demolition : MonoBehaviour {

	public Collider splashCollider;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
		}
	}
}
