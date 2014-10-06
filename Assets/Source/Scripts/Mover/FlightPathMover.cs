using UnityEngine;
using UnityEditor;
using System.Collections;

public class FlightPathMover : Mover {
	public string pathName = "flightPath";
	public int pathTime;
	public float lookAheadTime;
	
	void Start () {
		EditorUtility.SetDirty( gameObject );
		StartCoroutine("ExecuteFlightPath");
	}

	IEnumerator ExecuteFlightPath() {
		while(!onScreen)
			yield return null;

		iTweenPath path = gameObject.GetComponent<iTweenPath>();

		transform.position = path.GetPath(pathName)[0];
		
		iTween.MoveTo(
			gameObject, 
			iTween.Hash(
				//"position", transform.position + new Vector3(10.0f, 0.0f, 0.0f), 
				//"islocal", true, 
				"path", path.GetPath(pathName), 
				"time", pathTime, 
				"orienttopath", true, 
				"easytype", iTween.EaseType.easeInOutSine, 
				"looktime", lookAheadTime
			)
		);
		yield return null;
	}
}
