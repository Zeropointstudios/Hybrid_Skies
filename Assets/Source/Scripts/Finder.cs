using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Finder : MonoBehaviour {
	static GameObject player;
	static PlayerController playerController;
	static ObjectPool objectPool;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController>();
		objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static ObjectPool GetObjectPool() { return objectPool; }

	public static GameObject GetPlayer() { return player; }

	public static PlayerController GetPlayerController () { return playerController; }

	public static List<GameObject> GetEnemies() { 
		return GameObject.FindGameObjectsWithTag ("Enemy").ToList(); 
	}
}
