using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour 

{

	public float LockedX = 0;
	public float LockedY = 0;
	public float LockedZ = 0;
	
	public GameObject Player;
	
	void Update()
	{
		transform.position = new Vector3(LockedX * Player.transform.position.x, LockedY, LockedZ);
	}

}