using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public Transform shotSpawn;
	public float period;
	public float probability;
	public float angleRandomness, angleOffset;
	public GameObject projectile;
	public bool autoFire = true;
	public bool randomizeAim;
	Vector3 projectileRotation;

		// This is a coroutine that gets kicked off...
	IEnumerator UpdateFiring() {
		while (autoFire == true) {
			yield return new WaitForSeconds (period);				
			if (Random.value < probability)
				FireProjectile();
		}
	}

	void Start() {
		StartCoroutine ("UpdateFiring");
		projectileRotation = projectile.transform.rotation.eulerAngles; //takes prefabs initial rotation values
	}
	
	public virtual void FireProjectile() {

		if (randomizeAim) {
			angleOffset = Random.Range (-angleRandomness, angleRandomness);
		}
		projectileRotation.y += angleOffset;
		Instantiate (projectile, shotSpawn.position, Quaternion.Euler(projectileRotation));
		projectileRotation.y -= angleOffset;
	}
}