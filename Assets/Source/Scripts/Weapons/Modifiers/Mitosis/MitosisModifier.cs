using UnityEngine;
using System.Collections;

public class MitosisModifier : BehavioralModifier {

	public GameObject mitotePrefab1;

	// TODO: use an array
	GameObject mitoteInstance1;
	GameObject mitoteInstance2;
	GameObject mitoteInstance3;
	GameObject mitoteInstance4;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			// TODO: use a loop
			mitoteInstance1 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
			mitoteInstance1.GetComponent<Mitote>().lastShipHit = other;
			mitoteInstance1.GetComponent<DirectionalMover>().SetDirection(new Vector3(1, 0, 1).normalized);

			mitoteInstance2 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
			mitoteInstance2.GetComponent<Mitote>().lastShipHit = other;
			mitoteInstance2.GetComponent<DirectionalMover>().SetDirection(new Vector3(-1, 0, 1).normalized);

			mitoteInstance3 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
			mitoteInstance3.GetComponent<Mitote>().lastShipHit = other;
			mitoteInstance3.GetComponent<DirectionalMover>().SetDirection(new Vector3(1, 0, -1).normalized);

			mitoteInstance4 = (GameObject)Instantiate(mitotePrefab1, transform.position, Quaternion.identity);
			mitoteInstance4.GetComponent<Mitote>().lastShipHit = other;
			mitoteInstance4.GetComponent<DirectionalMover>().SetDirection(new Vector3(-1, 0, -1).normalized);
		}
	}
}
