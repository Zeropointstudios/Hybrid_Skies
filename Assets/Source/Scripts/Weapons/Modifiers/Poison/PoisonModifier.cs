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
			poisonCounterInstance = pool.Activate(2, transform.position, Quaternion.identity);
			poisonCounterInstance.transform.parent = other.transform;
		}
	}

}
