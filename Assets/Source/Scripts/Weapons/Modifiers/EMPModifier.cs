using UnityEngine;
using System.Collections;

public class EMPModifier : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (other.GetComponent<Firing>()!=null)
				other.GetComponent<Firing>().StopAllCoroutines();
			Instantiate(Resources.Load ("Prefabs/VFX/EMP/FXSet_Explode_EMP"), transform.position, Quaternion.identity);
		}
	}
}
