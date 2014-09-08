using UnityEngine;
using System.Collections;

//This script can be used to simply spin an object of pre-defined speed at every fixed update.
public class Spinner : MonoBehaviour {
	public float fRotateSpeedX = 0;
	public float fRotateSpeedY = 0;
	public float fRotateSpeedZ = 0;
	
	Vector3 vRotate;
	// Use this for initialization
	void Start () {
		vRotate.x = fRotateSpeedX;
		vRotate.y = fRotateSpeedY;
		vRotate.z = fRotateSpeedZ;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (vRotate);
	}
	
	void FixedUpdate(){
		vRotate.x = fRotateSpeedX;
		vRotate.y = fRotateSpeedY;
		vRotate.z = fRotateSpeedZ;
		
		transform.Rotate (vRotate);
	}
}
