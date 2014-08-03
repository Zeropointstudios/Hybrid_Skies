// Place this Spawner off-screen.  When it enters the screen, it starts spawning the specified type of 
// GameObject (such as an enemy).  Spawns the specified number of GameObjects and then destroys itself.

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject enemyToSpawn; // Spawn this enemy prefab once it gets on-screen.
	public int numEnemiesToSpawn = 1;
	public float timeBetweenSpawns = 1;

	private const float DROP_SPEED = 4;
	private new bool active = false;
	private float timeTilNextSpawn = 0;

	// Update is called once per frame
	void Update () 
	{
		// Move the spawner down a little bit from offscreen (above the screen) toward the screen, until it is on-screen.
		if (!active)
		{
			this.transform.position -= new Vector3(0, 0, Time.deltaTime * DROP_SPEED);
		}
		else // Once on-screen, it should continue spawning a fixed number of dudes at a fixed interval 
		{
			if (numEnemiesToSpawn > 0)
			{
				timeTilNextSpawn -= Time.deltaTime;
				if ( timeTilNextSpawn <= 0) 
				{
					SpawnObject();
				}
			}
			else // No enemies left to spawn, it's no longer necessary to keep the Spawner around.
			{
				Destroy(this);
			}
		}
	}

	public void EnterBoundary()
	{
		// Once it's on-screen...
		Debug.Log("Enter Boundary");

		// Spawn the first object
		SpawnObject();

		// Activate the Spawner so it will start spawning guys
		active = true;
	}

	private void SpawnObject()
	{
		Instantiate(enemyToSpawn, this.rigidbody.position, this.rigidbody.rotation);
		numEnemiesToSpawn--;

		if (numEnemiesToSpawn <= 0) 
		{
			Destroy (this);
		}

		// Time between spawns minus the time we've already waited.
		timeTilNextSpawn = timeBetweenSpawns - timeTilNextSpawn; 
	}
}
