using UnityEngine;
using System.Collections;

public class EnergyPowerUp : MonoBehaviour {

	public float energy;
	GameObject player;
	public float ReturnEnergy(){return energy;}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.LookAt (player.transform.position);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			player.GetComponent<SecondaryFiring> ().AddEnergy (energy);
			print ("add energy");
			gameObject.SetActive (false);
		}
	}	
	                       
}
