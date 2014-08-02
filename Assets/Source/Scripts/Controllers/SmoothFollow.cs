using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour 

{
	public float xRatio;
	public GameObject player;
	float y;
	float z;

	void Start()
	{
		y = transform.position.y;
		z = transform.position.z;
	}

	void Update()
	{
		if ( player != null)
		{
			transform.position = new Vector3(xRatio * player.transform.position.x, y, z);
		}
	}

}