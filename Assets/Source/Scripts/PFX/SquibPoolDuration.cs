using UnityEngine;
using System.Collections;

public class SquibPoolDuration : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("SetActiveFalse");
	}
	
	IEnumerator SetActiveFalse() {
		yield return new WaitForSeconds(2);
		gameObject.SetActive (false);		//disables squib after 2 seconds
	}
}
