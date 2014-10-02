using UnityEngine;
using System.Collections;

public class ExplosionModifier : MonoBehaviour {

	GameObject splashCollider;

	void Awake() {
		splashCollider = Resources.Load ("Prefabs/Modifier/DemolitionExplosion") as GameObject;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Instantiate (splashCollider, gameObject.transform.position, Quaternion.identity);
		}
	}
}
