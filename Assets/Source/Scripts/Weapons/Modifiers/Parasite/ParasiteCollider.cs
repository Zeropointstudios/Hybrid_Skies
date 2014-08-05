using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParasiteCollider : MonoBehaviour {

	public Vector3 startV3, endV3; //start and end points of expansion for the collider
	public float expansionTime, pathTime; //time to expand collider and time to execute projectile path
	public int targetLimit; //maximum amount of hits a parasite can attack
	public GameObject parasiteProjectile; //the object prefab that spawns after the orignal explodes, does not explode on contact
	GameObject parasiteInstance; //
	public List<GameObject> enemies = new List<GameObject>();

	void Start () {
		StartCoroutine("FindEnemies"); //first method called, expands collider to find position of all enemies
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			enemies.Add (other.gameObject); //if collider hits enemy add it to hitlist
		}
	}

	IEnumerator FindEnemies() {
		float t = 0;
		do
		{
			collider.transform.localScale = Vector3.Lerp(startV3, endV3, t / expansionTime); //expands a collider to collide with the enemies from closest to farthest
			yield return null;
			t += Time.deltaTime;
		}
		while (t < expansionTime);

		Vector3[] coordinateArray = new Vector3[targetLimit];//stores closest enemy positions
		Destroy (collider); //destroy collider used to find enemies
		parasiteInstance = (GameObject)Instantiate (parasiteProjectile, transform.position, Quaternion.identity);

		for (int i = 0; i < targetLimit && i < enemies.Count; i++)
		{
			coordinateArray[i] = enemies[i].transform.position;
		}

		iTween.MoveTo
			(parasiteInstance,
			iTween.Hash(
			"path",
		    coordinateArray,
		    "time",
		    pathTime
			));

	}
}