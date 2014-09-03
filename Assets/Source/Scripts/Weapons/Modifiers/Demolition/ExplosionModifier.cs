using UnityEngine;
using System.Collections;

public class ExplosionModifier : MonoBehaviour {

	public Collider splashCollider;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
		}
	}
}
