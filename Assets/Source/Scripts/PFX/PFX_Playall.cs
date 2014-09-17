using UnityEngine;
using System.Collections;

public class PFX_Playall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAll() {
		foreach (Transform child in transform)
		{
			child.particleSystem.Play ();
		}
	}

	public void StopAll() {
		foreach (Transform child in transform)
		{
			child.particleSystem.Stop ();
		}
	}
}
