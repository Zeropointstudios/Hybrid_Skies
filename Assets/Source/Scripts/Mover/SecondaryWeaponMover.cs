using UnityEngine;
using System.Collections;

public class SecondaryWeaponMover : Mover {

	bool isFired = false;

	public override void Move() {
		//change projectile rotation
		if (!isFired) {
		
			isFired = true;
		}
		//move it foward
//		print ("final rotation" + transform.rotation);
		transform.Translate(transform.forward * speed * Time.deltaTime);
	}
}
