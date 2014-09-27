using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Finder : MonoBehaviour {
	static GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject GetPlayer() { return player; }

	public static List<GameObject> GetEnemies() { 
		List<GameObject> gameObjList = GameObject.FindGameObjectsWithTag ("Enemy").ToList(); 
		//gameObjList.AddRange(Spawner.GetInstantiatedGameObjects());

		print ("GET ENEMIES RESULT:");
		foreach (GameObject obj in gameObjList) {
			print ("   obj: " + obj);
		}

		return gameObjList;
		//return GameObject.FindGameObjectsWithTag ("Enemy"); 
		// Find all objects (including spawned objects) with the tag "Enemy".

		//return Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.tag=="Enemy").ToList();

		//return Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().ToList(); 
	}
}
