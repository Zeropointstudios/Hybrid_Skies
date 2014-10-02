using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RebounderModifier : MonoBehaviour {

	public int targetLimit = 3; //maximum amount of hits a parasite can attack
	public int parasiteDamage = 5;
	public float pathTime = 0.4f;
	bool hit = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" && hit == false)
		{
			print("collided");
			RadarSweep();
			hit = true;
		}

		if (other.tag == "Enemy" && hit == true)
		{
			other.gameObject.GetComponent<HitPoints> ().DoDamage (parasiteDamage, transform.position);
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

	void DestroyParasite() {
		gameObject.SetActive(false);
	}

	void FireParasite(Vector3[] enemiesOnRadar)
	{
		print ("fire");
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
			gameObject.SetActive(false);
		}
	}

}
