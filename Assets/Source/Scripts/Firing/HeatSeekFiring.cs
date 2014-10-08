using UnityEngine;
using System.Collections;

public class HeatSeekFiring : Firing {

	GameObject heatSeeker;
	GameObject player;
	bool seekEnemy = true;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public virtual void FireProjectile() {

		heatSeeker = Finder.GetObjectPool().Activate(projectileID, shotSpawn.position, Quaternion.Euler(projectileRotation/2)); // activates projectile	
		print ("seek");
		if (mainWeapon != null)
			mainWeapon.Play();//play sound of mainGun firing
		StartCoroutine ("Seek");
	}

	IEnumerator Seek(){
		while(seekEnemy) {
			heatSeeker.transform.LookAt (player.transform.position);
			yield return new WaitForSeconds(0.1f);
			print ("seeking");
		}
	}
}
