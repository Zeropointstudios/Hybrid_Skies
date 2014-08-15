using UnityEngine;
using System.Collections;

public class SecondaryLaserMover : Mover {

	void Start () {
		rigidbody.velocity = (ClickHandler.PositionOfLastTap - transform.position).normalized * speed;
	}
}
