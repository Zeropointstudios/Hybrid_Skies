using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ParasiteMod : MonoBehaviour {

	public int targetLimit, parasiteDamage; //maximum amount of hits a parasite can attack
	public float pathTime;
	bool hit = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" && hit == false)
		{
			RadarSweep();
			hit = true;
		}

		if (other.tag == "Enemy" && hit == true)
		{
			other.gameObject.GetComponent<HitPoints> ().doDamage (parasiteDamage, transform.position);
		}
	}

	void RadarSweep()
	{
		var transformArray = GameObject.FindGameObjectsWithTag("Enemy")
			.Select(go => go.transform.position)
				.OrderBy(t => Vector3.SqrMagnitude(t - transform.position)).Skip (1).Take(targetLimit) //skips the first enemy in the list which is the one we collided with
					.ToArray();
		FireParasite (transformArray);
	}

	void DestroyParasite()
	{
		Destroy (gameObject);
	}

	void FireParasite(Vector3[] enemiesOnRadar)
	{
		if (enemiesOnRadar.Length > 1)
		{
			iTween.MoveTo (gameObject,
			              iTween.Hash (
							"path",
							enemiesOnRadar,
							"time",
							pathTime,
							"easetype",
							"linear",
							"oncomplete",
							"DestroyParasite",
							"oncompletetarget",
							gameObject
							));					
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
