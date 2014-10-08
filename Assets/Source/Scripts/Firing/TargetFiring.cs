using UnityEngine;
using System.Collections;

public class TargetFiring : Firing { //this class is for enemies firing at the player

	GameObject target;

	void Awake() {
		target = GameObject.FindGameObjectWithTag ("Player");
	}


	public override void FireProjectile() {

		float hypotenuse, opposite, shotAngle; 
		Vector3 oppositePoint = new Vector3(shotSpawn.transform.position.x, 0, target.transform.position.z); //used to calculate opposite
		hypotenuse = Vector3.Distance(target.transform.position, shotSpawn.transform.position);
		opposite = Vector3.Distance (target.transform.position, oppositePoint);
		
		shotAngle = Mathf.Asin (opposite / hypotenuse) * Mathf.Rad2Deg;
		if (target.transform.position.z < shotSpawn.transform.position.z)	                        //determines if angle in 2nd or 3rd quad
			shotAngle = 180 - shotAngle;
		if (target.transform.position.x < shotSpawn.transform.position.x)							//determines positive or negative angle
			shotAngle = 360.0f - shotAngle;
		
		Finder.GetObjectPool().Activate (projectileID, shotSpawn.transform.position, Quaternion.Euler(0, shotAngle/2, 0));

		if (mainWeapon != null)
			mainWeapon.Play();//play sound of mainGun firing
	}

}
