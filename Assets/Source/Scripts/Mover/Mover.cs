using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Update() {
		Move ();	
	}

	public virtual void Move() {//moves the object forward in the direction that the transform is facing
		transform.Translate(transform.forward * speed * Time.deltaTime);
	}
}	

