using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject EnemyOrg1;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		// No longer necessary since we have a Spawner.
		//StartCoroutine (SpawnWaves ()); // UNDO!!
	}
/*
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Instantiate(EnemyOrg1);
		
			yield return new WaitForSeconds (waveWait);
		}
	}
*/	
}
