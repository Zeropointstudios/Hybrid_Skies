using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject EnemyOrg1;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Instantiate(EnemyOrg1);
		
			yield return new WaitForSeconds (waveWait);
		}
	}
}
