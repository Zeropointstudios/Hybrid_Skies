using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RadarSweep : MonoBehaviour {
	
	public float startSize, radarSize;
	public float colliderExpansionTime;
	public List<GameObject> enemiesOnScreen = new List<GameObject>();

	public delegate void ReturnEnemiesDelegate();
	public static event ReturnEnemiesDelegate ReturnEnemies;

	void Start ()
	{
		StartCoroutine ("RadarSweep");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			enemiesOnScreen.Add (other.gameObject);
		}
	}

	IEnumerator RadarSweep()
	{
		float t = 0;
		while (t < colliderExpansionTime)
		{
			//Creates an expanding sphere collider which gets the data for all enemies on screen
			collider.transform.localScale = Vector3.Lerp (new Vector3 (startSize, startSize, startSize),
			                                              new Vector3 (radarSize, radarSize, radarSize),
			                                              t/colliderExpansionTime);
			yield return null;
			t += Time.deltaTime;
		}
		ReturnEnemies ();
	}
}
