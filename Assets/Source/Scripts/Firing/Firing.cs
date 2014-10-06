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
	public bool randomizeAim;
	protected Vector3 projectileRotation;
	public enum Direction {Up, Down};
	public Direction direction;
	public AudioSource mainWeapon;

	protected bool onScreen = true;  // It will get set to false via the "SetOnScreen" message if the ship has HitPoints
	
	public void SetOnScreen(bool _onScreen) {
		onScreen = _onScreen;
	}

	void Start() {
		if (direction == Direction.Down) //if the ship is flying down or is an enemy, shoot facing down not up
			projectileRotation.y += 180;
		if (autoFire)
			StartCoroutine ("UpdateFiring");
	}

	IEnumerator UpdateFiring() {
		while (!onScreen)
			yield return null;

		while (autoFire) {
			yield return new WaitForSeconds (period);				
			if (Random.value < probability)
				FireProjectile();
		}
	}
	
	public virtual void FireProjectile() {
		if (randomizeAim) {
			angleOffset = Random.Range (-angleRandomness, angleRandomness);	//randomizes angle at which projectile exits ship
		}
		projectileRotation.y += angleOffset;
		Finder.GetObjectPool().Activate(projectileID, shotSpawn.position, Quaternion.Euler(projectileRotation/2)); // activates projectile	
		projectileRotation.y -= angleOffset;

		if (mainWeapon != null)
			mainWeapon.Play();//play sound of mainGun firing
	}
}