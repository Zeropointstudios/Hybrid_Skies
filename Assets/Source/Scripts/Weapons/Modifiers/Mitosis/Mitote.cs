	using UnityEngine;
using System.Collections;

public class Mitote : MonoBehaviour {

	public int mitoteDamage;

	public Collider lastShipHit;

	public GameObject mitotePrefab1;//, mitotePrefab2;
	GameObject mitoteInstance1,mitoteInstance2,mitoteInstance3,mitoteInstance4;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")//to avoid exploding on object it just hit
		{
			if (other != lastShipHit)
			{
				StartCoroutine(Explode(other));
			}
		}
	}

	IEnumerator Explode(Collider other)
	{
		yield return new WaitForSeconds (0.1f); //to avoid overpopulate
		mitoteInstance1 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
		mitoteInstance1.GetComponent<DirectionalMover>().SetDirection(new Vector3(1,0,1).normalized);
		mitoteInstance1.GetComponent<Mitote>().lastShipHit = other;
		
		mitoteInstance2 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
		mitoteInstance2.GetComponent<Mitote>().lastShipHit = other;
		mitoteInstance2.GetComponent<DirectionalMover>().SetDirection(new Vector3(-1,0,1).normalized);
		
		mitoteInstance3 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
		mitoteInstance3.GetComponent<Mitote>().lastShipHit = other;
		mitoteInstance3.GetComponent<DirectionalMover>().SetDirection(new Vector3(1,0,-1).normalized);
		
		mitoteInstance4 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
		mitoteInstance4.GetComponent<Mitote>().lastShipHit = other;
		mitoteInstance4.GetComponent<DirectionalMover>().SetDirection(new Vector3(-1,0,-1).normalized);
		
		if (other)
		{
			other.gameObject.GetComponent<HitPoints> ().doDamage (mitoteDamage);
		}

	}
}