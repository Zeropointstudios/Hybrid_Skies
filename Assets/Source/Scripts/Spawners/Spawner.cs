// Place this Spawner off-screen.  When it enters the screen, it starts spawning the specified type of 
// GameObject (such as an enemy).  Spawns the specified number of GameObjects and then destroys itself.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject objectToSpawn; // Spawn this enemy prefab once it gets on-screen.
	public int numObjectsToSpawn = 1;
	public float timeBetweenSpawns = 1;

	private new bool active = false;

	public static List<GameObject> instantiatedGameObjects = new List<GameObject>(); // TODO: do we need this variable?

	// Update is called once per frame
	void Update () 
	{
		// Move the spawner down a little bit from offscreen (above the screen) toward the screen, until it is on-screen.
		if (!active)
		{
			this.transform.position -= new Vector3(0, 0, GameController.GetScreenDrop());
		}
	}

	public void EnterBoundary()
	{
		// Once it's on-screen...

		// Activate the Spawner so it will start spawning objects and stop moving.
		active = true;

		// Start spawning dudes.
		StartCoroutine(SpawnObjects());
	}

	IEnumerator SpawnObjects()
	{
		for (int i = 0; i < numObjectsToSpawn; i++)
		{
			GameObject go = Instantiate(objectToSpawn, this.rigidbody.position, this.rigidbody.rotation) as GameObject;
			instantiatedGameObjects.Add(go);

			yield return new WaitForSeconds (timeBetweenSpawns);
		}
		Destroy (this);
	}

	public static List<GameObject> GetInstantiatedGameObjects() { return instantiatedGameObjects; }
}