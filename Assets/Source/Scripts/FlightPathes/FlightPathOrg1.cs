using UnityEngine;
using System.Collections;

public class FlightPathOrg1 : MonoBehaviour {
	public int pathTime;
	public float lookAheadTime;

	// Use this for initialization
	void Start () {
		transform.position = iTweenPath.GetPath("EnemyOrg1")[0];
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("EnemyOrg1"), "time", pathTime, "orienttopath", true, "easytype", iTween.EaseType.easeInOutSine, "looktime", lookAheadTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
