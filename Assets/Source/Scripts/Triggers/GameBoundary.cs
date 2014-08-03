using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour {
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter: " + other.name);
		other.gameObject.SendMessage("EnterBoundary", SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Player") {
			Destroy (other.gameObject);
		}
	}
}
