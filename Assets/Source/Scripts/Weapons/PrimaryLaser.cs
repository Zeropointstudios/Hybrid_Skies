using UnityEngine;
using System.Collections;

public class PrimaryLaser : MonoBehaviour {
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	void Start ()
	{
		InvokeRepeating("FirePrimary", 0.1f, fireRate);
	}
	
	void FirePrimary ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
	}
	
}
