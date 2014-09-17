using UnityEngine;
using System.Collections;

public class PFX_Playall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayAll ();
		StartCoroutine ("Disappear");
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

	IEnumerator Disappear()
	{
		yield return new WaitForSeconds (3);
			Destroy (gameObject);
	}
}
