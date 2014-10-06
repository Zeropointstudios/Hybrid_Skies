using UnityEngine;
using System.Collections;

public class PoisonModifier : MonoBehaviour {
	GameObject poisonCounterInstance;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			print ("spawned a poison");
			poisonCounterInstance = Finder.GetObjectPool().Activate(2, transform.position, Quaternion.identity); //where 2 is ID for poison
			poisonCounterInstance.transform.parent = other.transform;
		}
	}

}
