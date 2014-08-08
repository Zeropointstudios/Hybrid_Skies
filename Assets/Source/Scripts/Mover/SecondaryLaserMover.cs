using UnityEngine;
using System.Collections;

public class SecondaryLaserMover : Mover {
	public float speed;

	void Start () {
		rigidbody.velocity = (ClickHandler.PositionOfLastTap - transform.position).normalized * speed;
	}
}
