using UnityEngine;
using System.Collections;

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

	public static GameObject[] GetEnemies() { return GameObject.FindGameObjectsWithTag ("Enemy"); }
}
