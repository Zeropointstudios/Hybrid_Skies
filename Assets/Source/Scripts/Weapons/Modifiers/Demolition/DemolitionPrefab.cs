using UnityEngine;
using System.Collections;

public class DemolitionPrefab : MonoBehaviour {

	public float explosionDuration;
	public int explosionDamage;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Destroy");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.GetComponent<HitPoints> ().doDamage (explosionDamage);
		}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(explosionDuration);
		Destroy (gameObject);
	}
}
