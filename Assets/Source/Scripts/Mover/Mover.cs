using UnityEngine;
using System.Collections;

// TODO: Make Mover have Spawner functionality (Slowly moves down if off-screen.  When it gets on-screen, becomes active)
public class Mover : MonoBehaviour {
	public float speed;

	public float duration = -1.0f;  // How long before this movement expires, -1 if never.
	protected float timePassed = 0.0f;

	protected bool onScreen = true;  // It will get set to false via the "SetOnScreen" message if the ship has HitPoints
	                                 // (so Weapons can start onScreen without having 

	public void SetOnScreen(bool _onScreen) {
		print (gameObject + " SetOnScreen " + _onScreen);
		onScreen = _onScreen;
	}

	void Update() {
		if (onScreen) {
			timePassed += Time.deltaTime;

			if (!IsDone())
				Move ();	
		}
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
