using UnityEngine;
using System.Collections;

public class MageMover : Mover {
	public float period;
	public float radius;
	private bool needsToMoveOnScreen = true;

	void Start() {
		StartCoroutine("Movement");
	}

	// This is a coroutine that gets kicked off...
	IEnumerator Movement() {
		while (true) {
			if (onScreen) {
				if (needsToMoveOnScreen) {
					needsToMoveOnScreen = false;
					iTween.MoveTo(gameObject,iTween.Hash(
						"z", 13.0f,
						"time", period,
						"easytype", iTween.EaseType.easeInOutSine
						));
				} else
					iTween.MoveBy(gameObject,iTween.Hash(
						"x", Random.Range(-radius, radius),
						"z", Random.Range(-radius, radius),
						"time", period,
						"easytype", iTween.EaseType.easeInOutSine
						));
				yield return new WaitForSeconds (period);
			} else {
				needsToMoveOnScreen = true;
				yield return null;
			}
		}
	}
}	

