using UnityEngine;
using System.Collections;

public class SecondaryLaserMover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = (ClickHandler.PositionOfLastTap - transform.position) * speed;
	}
}
