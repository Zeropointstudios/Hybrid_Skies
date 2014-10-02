using UnityEngine;
using System.Collections;

public class EMPModifier : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<Firing>().StopAllCoroutines();
		}
	}
}
