using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("OnTriggerEnter: " + other.name);
		other.gameObject.SendMessage("EnterBoundary", SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Player") {
			HitPoints hitPoints = other.gameObject.GetComponent<HitPoints>();
			if (!(hitPoints != null && hitPoints.transcendsBoundary))
				other.gameObject.SetActive(false);
		}
	}
}
