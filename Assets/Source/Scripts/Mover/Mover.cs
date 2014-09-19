using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;

	public float duration = -1.0f;  // How long before this movement expires, -1 if never.
	protected float timePassed = 0.0f;

	void Update() {
		timePassed += Time.deltaTime;

		if (!IsDone())
			Move ();	
	}

	void Reset() {
		timePassed = 0.0f;
	}

	public virtual void Move() { //moves the object forward in the direction that the transform is facing
		transform.Translate(transform.forward * (speed * Time.deltaTime));
	}

	public virtual bool IsDone() {
		return duration > 0.0f && timePassed >= duration;
	}
}	

