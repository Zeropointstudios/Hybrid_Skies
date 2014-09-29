using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public Transform shotSpawn;
	public float period;
	public float probability;
	public float angleRandomness;
	float angleOffset;
	public int projectileID;
	public bool autoFire = true;
	public ObjectPool objectPool;
	public bool randomizeAim;
	protected Vector3 projectileRotation;
	public enum Direction {Up, Down};
	public Direction direction;

	public AudioSource mainWeapon;
	//AudioSource secondWeapon01;

		// This is a coroutine that gets kicked off...
	IEnumerator UpdateFiring() {
		while (autoFire == true) {
			yield return new WaitForSeconds (period);				
			if (Random.value < probability)
				FireProjectile();
		}
	}

	void Start() {
		if (direction == Direction.Down) //if the ship is flying down or is an enemy, shoot facing down not up
			projectileRotation.y += 180;
		if (autoFire)
			StartCoroutine ("UpdateFiring");

	}
	
	public virtual void FireProjectile() {

		if (randomizeAim) {
			angleOffset = Random.Range (-angleRandomness, angleRandomness);	//randomizes angle at which projectile exits ship
		}
		projectileRotation.y += angleOffset;
		objectPool.Activate(projectileID, shotSpawn.position, Quaternion.Euler(projectileRotation/2)); // activates projectile	
		projectileRotation.y -= angleOffset;

		if (mainWeapon != null)
			mainWeapon.Play();//play sound of mainGun firing
	}
}