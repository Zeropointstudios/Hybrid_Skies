using UnityEngine;
using UnityEditor;
using System.Collections;

public class FlightPathMover : Mover {
	public int pathTime;
	public float lookAheadTime;
	
	void Start () {
		transform.position = iTweenPath.GetPath("FlightPath")[0];

		print ("FLIGHT PATH MOVER!!!");
		print ("FLIGHT PATH MOVER!!!");
		print ("FLIGHT PATH MOVER!!!");
		print (gameObject + " setting initial position to " + transform.position);

		if (gameObject.hideFlags == HideFlags.NotEditable || gameObject.hideFlags == HideFlags.HideAndDontSave) {
			print ("  Wrong flags");
		}
		
		if (PrefabUtility.GetPrefabType(gameObject) == PrefabType.Prefab) {
			print ("  Ignore prefab");
		}
		
		print ("Potential enemy: " + gameObject);
		print ("  tag: " + gameObject.tag);
		print ("  prefab type: " + PrefabUtility.GetPrefabType(gameObject));
		print ("  location: " + gameObject.transform.position);
		print ("  hit points: " + gameObject.GetComponent<HitPoints>().hitPoints);

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
