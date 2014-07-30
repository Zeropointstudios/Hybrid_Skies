using UnityEngine;
using System.Collections;

public class OnProjectileHit : MonoBehaviour {
	//does damage to enemy ship on collision, damage value determined with public field projectileDamage
	public int projectileDamage;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.GetComponent<HitPoints> ().doDamage (projectileDamage); //could potentially be a slow function due to the GetComponent call and multiple references.
			Destroy (gameObject);	
		}


	}
}
