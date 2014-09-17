using UnityEngine;
using System.Collections;


//This script makes the object follow a target object.
public class Follower : MonoBehaviour {
	public Transform tTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tTarget) {
			transform.position = tTarget.position;
		}
	}
}
