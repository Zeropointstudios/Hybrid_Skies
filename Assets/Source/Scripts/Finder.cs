using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Finder : MonoBehaviour {
	static GameObject player;
	static PlayerController playerController;
	static GameController gameController;
	static ObjectPool objectPool;

	// Use this for initialization
	public void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController>();
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	public void Update () {
	}

	public static ObjectPool GetObjectPool() { return objectPool; }

	public static GameObject GetPlayer() { return player; }

	public static PlayerController GetPlayerController () { return playerController; }

	public static GameController GetGameController () { return gameController; }

	public static GameObject[] GetEnemies() { 
		return (from enemy 
		        in GameObject.FindGameObjectsWithTag ("Enemy") 
		        where enemy.activeSelf &&
		              enemy.GetComponent<HitPoints>() && 
		              enemy.GetComponent<HitPoints>().onScreen 
		        select enemy).ToArray (); 
	}
}
