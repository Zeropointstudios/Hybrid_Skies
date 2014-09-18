using UnityEngine;
using System.Collections;


//This script makes the object follow a target object.
public class Follower : MonoBehaviour {
	public Transform tTarget;

	public float fOffsetX = 0;
	public float fOffsetY = 0;
	public float fOffsetZ = 0;

	Vector3 vOffset;
	Vector3 vTargetPos;

	void UpdatevOffset()
	{
		vOffset.x = fOffsetX;
		vOffset.y = fOffsetY;
		vOffset.z = fOffsetZ;
	}

	// Use this for initialization
	void Start () {
		UpdatevOffset ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tTarget) {
			UpdatevOffset ();
			vTargetPos = tTarget.position + vOffset;
			transform.position = vTargetPos;
		}
	}
}
