using UnityEngine;
using System.Collections;

public class FlightPathMover : MonoBehaviour {
	public int pathTime;
	public float lookAheadTime;
	
	void Start () {
		transform.position = iTweenPath.GetPath("FlightPath")[0];
		iTween.MoveTo(
			gameObject, 
			iTween.Hash(
				"path", 
		        iTweenPath.GetPath("FlightPath"), 
				"time", 
				pathTime, 
				"orienttopath", 
				true, 
				"easytype", 
				iTween.EaseType.easeInOutSine, 
				"looktime", 
				lookAheadTime
		));
	}
}
