// Place this HaltScrolling off-screen.  When it enters the screen, it pauses the scrolling of the screen
// until some condition is met, such as all enemies dying.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HaltScrolling : MonoBehaviour {
	public GameObject objectToSpawn; // Spawn this enemy prefab once it gets on-screen.
	public int numObjectsToSpawn = 1;
	public float timeBetweenSpawns = 1;

	private new bool active = false;
	
	public static List<GameObject> instantiatedGameObjects = new List<GameObject>(); // TODO: do we need this variable?
	
	// Update is called once per frame
	public void Update () 
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
		StartCoroutine("UpdateScreenScrollingSpeed");
	}
	
	IEnumerator UpdateScreenScrollingSpeed()
	{
		// Wait until it's on-screen.
		while (!active)
			yield return null;

		// Halt screen scrolling.
		GameController.screenScrollSpeed = 0.0f;
		print ("Halted screened scrolling");

		// Wait until all enemies are eliminated.  
		// (TODO: other functionality could be added, such as waiting X seconds,
		//        or waiting for a boss (GameObject) to die.)
		while (Finder.GetEnemies().Length > 0) {
			yield return null;
		}

		// Continue screen scroling.
		GameController.screenScrollSpeed = 1.0f;
		print ("Continued screened scrolling");

		Destroy (this);
	}
}