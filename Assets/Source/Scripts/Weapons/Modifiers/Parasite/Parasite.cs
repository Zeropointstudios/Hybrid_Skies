using UnityEngine;
using System.Collections;

public class Parasite : MonoBehaviour {

	public Collider parasiteSpawn;
	Collider parasiteInstance; //need this in order to access the explosion spawn for combinations.
	
	void OnTriggerEnter()
	{
		parasiteInstance = (Collider)Instantiate (parasiteSpawn, gameObject.transform.position, Quaternion.identity);
	}
}
