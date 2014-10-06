using UnityEngine;
using System.Collections;

public class MageMover : Mover {
	public float period;
	public float radius;

	void Start() {
		StartCoroutine("Movement");
	}

	// This is a coroutine that gets kicked off...
	IEnumerator Movement() {
		while (true) {
			if (onScreen) {
				yield return new WaitForSeconds (period);				
				iTween.MoveBy(gameObject,iTween.Hash(
					"x", Random.Range(-radius, radius),
					"z", Random.Range(-radius, radius),
					"time", period,
					"easytype", iTween.EaseType.easeInOutSine
					));
			} else
				yield return null;
		}
	}
}	

