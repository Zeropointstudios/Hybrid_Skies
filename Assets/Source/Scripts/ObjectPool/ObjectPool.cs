using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public GameObject[] pooledGameObjects;
	public int[] numberOfProjectilesToCreate;
	public List<GameObject>[] pool;
	
	
	// Use this for initialization
	void Start () {
		InstantiateProjectiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void InstantiateProjectiles() {
		GameObject tempParent;
		pool = new List<GameObject>[pooledGameObjects.Length];
		
		for (int i = 0; i < pooledGameObjects.Length; i++) {
			pool[i] = new List<GameObject>();
			
			for (int j = 0; j < numberOfProjectilesToCreate.Length; j++){
				tempParent = (GameObject)Instantiate(pooledGameObjects[j]);
				tempParent.transform.parent = this.transform; //keeps hierarchy clean by putting pooled objs under component transform
				pool[i].Add(tempParent);
			}
		}
	}
	
	GameObject Activate(int id) {
		for (int i = 0; i < pool.Length; i++) {
			if(!pool[id][i].activeSelf){
				pool[id][i].SetActive(true);
				return pool[id][i];
			}
		}
		pool[id].Add((GameObject)Instantiate(pooledGameObjects[id])); //incase pool runs out
		pool[id][pool[id].Count-1].transform.parent = this.transform;
		return null;
	}
	
	GameObject Activate(int id, Vector3 position, Quaternion rotation) {
		for (int i = 0; i < pool.Length; i++) {
			if(!pool[id][i].activeSelf){
				pool[id][i].SetActive(true);
				pool[id][i].transform.position = position;
				pool[id][i].transform.rotation = rotation;
				pool[id][i].SetActive(true);
				
				return pool[id][i];
			}
		}
		pool[id].Add((GameObject)Instantiate(pooledGameObjects[id])); //incase pool runs out
		pool[id][pool[id].Count-1].transform.position = position;
		pool[id][pool[id].Count-1].transform.rotation = rotation;
		pool[id][pool[id].Count-1].transform.parent = this.transform;
		return pool[id][pool[id].Count-1];
	}
	
	public void Deactivate(GameObject deactivateObject)
	{
		deactivateObject.SetActive(false);
	}
}