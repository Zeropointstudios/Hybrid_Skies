using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParasiteMod : MonoBehaviour {

	public int targetLimit; //maximum amount of hits a parasite can attack
	public GameObject parasiteProjectile, radarPrefab; //the object prefab that spawns after the orignal explodes, does not explode on contact
	GameObject radarColliderInstance;
	
	void Start ()
	{
		StartCoroutine("FindEnemies"); //first method called, expands collider to find position of all enemies
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			radarColliderInstance = (GameObject)Instantiate(radarPrefab, transform.position, Quaternion.identity);

		}
	}

	void FireParasite()
	{
	}

}
