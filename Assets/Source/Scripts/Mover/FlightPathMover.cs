using UnityEngine;
using System.Collections;

public class FlightPathMover : Mover {
	public int pathTime;
	public float lookAheadTime;
	
	void Start () {
		transform.position = iTweenPath.GetPath("FlightPath")[0];

		iTween.MoveTo(
			gameObject, 
			iTween.Hash(
				//"position", transform.position + new Vector3(10.0f, 0.0f, 0.0f), 
				//"islocal", true, 
				"path", iTweenPath.GetPath("FlightPath"), 
				"time", pathTime, 
				"orienttopath", true, 
				"easytype", iTween.EaseType.easeInOutSine, 
				"looktime", lookAheadTime
			)
		);
	}
}
