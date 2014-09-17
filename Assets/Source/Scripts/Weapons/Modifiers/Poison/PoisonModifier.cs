using UnityEngine;
using System.Collections;

public class PoisonModifier : MonoBehaviour {
	ObjectPool pool;
	GameObject poisonCounterInstance;

	void Awake() {
		pool = GameObject.FindGameObjectWithTag ("Pool").GetComponent<ObjectPool>();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			print ("spawned a poison");
			poisonCounterInstance = pool.Activate(2, transform.position, Quaternion.identity); //where 2 is ID for poison
			poisonCounterInstance.transform.parent = other.transform;
		}
	}

}
