using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start() {
		Move ();	
	}

	public virtual void Move() {//moves the object forward in the direction that the transform is facing
		rigidbody.velocity = transform.forward * speed;
	}
}	

