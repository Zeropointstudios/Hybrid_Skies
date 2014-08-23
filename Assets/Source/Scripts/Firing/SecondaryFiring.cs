using UnityEngine;
using System.Collections;

public class SecondaryFiring : Firing {

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
		Vector3 relative = shotSpawn.transform.InverseTransformPoint(ClickHandler.PositionOfLastTap - shotSpawn.transform.position);
		float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
		shotSpawn.transform.eulerAngles = new Vector3 (0, angle/2, 0);
		objectPool.Activate (projectileID, shotSpawn.transform.position, shotSpawn.transform.rotation);
//		shotSpawn.transform.rotation = Quaternion.identity; //resets angle
		//substract from energy pool

	}
//
//	public class ExampleClass : MonoBehaviour {
//		public Transform target;
//		void Update() {
//			Vector3 relative = transform.InverseTransformPoint(target.position);
//			float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
//			transform.Rotate(0, angle, 0);
//		}
//	}
}