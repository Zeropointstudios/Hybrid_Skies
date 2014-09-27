using UnityEngine;
using System.Collections;

public class TankMover : Mover {
	public float period;

	GameObject player;
	void Awake() {
	}

	void Start() {
		StartCoroutine("Movement");
	}
	
	// This is a coroutine that gets kicked off...
	IEnumerator Movement() {
		while (true) {
			if (Finder.GetPlayer() != null) {
				iTween.MoveTo(
					gameObject, 
					iTween.Hash(
						"x", Finder.GetPlayer().transform.position.x,
						"time", period,
						"easytype", iTween.EaseType.easeInOutSine
					));
			}
			yield return new WaitForSeconds (period);				
		}
	}

/*	// Comment this in and commend out the StartCoroutine above to switch to a procedural 
    // implementation.  I personally like the smoothness of the iTween.MoveTo implementation.
	public override void Move() { //moves the object forward in the direction that the transform is facing
		float dx = player.transform.position.x - transform.position.x )
			dx = 1;
		else if ( player.transform.position.x < transform.position.x )
			dx = -1;
			
		transform.Translate(new Vector3(dx * (speed * Time.deltaTime), 0, 0));
	}
*/	
}	




