using UnityEngine;
using System.Collections;

public class SecondaryFiring : Firing {

	public int energy;

	void Awake() {
		autoFire = false;
	}

	void OnEnable()
	{
		ClickHandler.Tapped += FireProjectile;
	}
	
	void OnDisable()
	{
		ClickHandler.Tapped -= FireProjectile;
	}

	public override void FireProjectile() {
		if (energy > 0) {
			float hypotenuse, opposite, shotAngle; 
			Vector3 oppositePoint = new Vector3(shotSpawn.transform.position.x, 0, ClickHandler.PositionOfLastTap.z); //used to calculate opposite
			hypotenuse = Vector3.Distance(ClickHandler.PositionOfLastTap, shotSpawn.transform.position);
			opposite = Vector3.Distance (ClickHandler.PositionOfLastTap, oppositePoint);

			shotAngle = Mathf.Asin (opposite / hypotenuse) * Mathf.Rad2Deg;
			if (ClickHandler.PositionOfLastTap.z < shotSpawn.transform.position.z)	                        //determines if angle in 2nd or 3rd quad
				shotAngle = 180 - shotAngle;
			if (ClickHandler.PositionOfLastTap.x < shotSpawn.transform.position.x)							//determines positive or negative angle
				shotAngle = 360.0f - shotAngle;

			objectPool.Activate (projectileID, shotSpawn.transform.position, Quaternion.Euler(0, shotAngle/2, 0));
			//substract from energy pool
		}
	}

}