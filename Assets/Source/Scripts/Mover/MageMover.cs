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
			//iTween.MoveTo(
			//	gameObject, 
			//	transform.position + Random.insideUnitSphere * radius, 
			//	period);
			iTween.MoveBy(gameObject,iTween.Hash(
				"x", Random.Range(-radius, radius),
				"time", period,
				"easytype", iTween.EaseType.easeInOutSine
				));
			yield return new WaitForSeconds (period);				
		}
	}
}	

