using UnityEngine;
using System.Collections;

public class DemolitionPrefab : MonoBehaviour {

	public int explosionDamage;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Destroy");
	}

	void OnTriggerEnter(GameObject other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.GetComponent<HitPoints> ().doDamage (explosionDamage);
		}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
}
