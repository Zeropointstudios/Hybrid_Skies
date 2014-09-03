using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public Transform shotSpawn;
	public float period;
	public float probability;
	public float angleRandomness, angleOffset;
	public int projectileID;
	public bool autoFire = true;
	public ObjectPool objectPool;
	public bool randomizeAim;
	protected Vector3 projectileRotation;

		// This is a coroutine that gets kicked off...
	IEnumerator UpdateFiring() {
		while (autoFire == true) {
			yield return new WaitForSeconds (period);				
			if (Random.value < probability)
				FireProjectile();
		}
	}

	void Start() {
		projectileRotation.y += transform.rotation.y;
		if (autoFire)
			StartCoroutine ("UpdateFiring");

	}
	
	public virtual void FireProjectile() {

		if (randomizeAim) {
			angleOffset = Random.Range (-angleRandomness, angleRandomness);
		}
		projectileRotation.y += angleOffset;
		objectPool.Activate(projectileID, shotSpawn.position, Quaternion.Euler(projectileRotation));
		projectileRotation.y -= angleOffset;
	}
}