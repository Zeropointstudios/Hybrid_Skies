using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	public float speed;
	public int shipMovementBoundaryX1, shipMovementBoundaryX2, shipMovementBoundaryY1, shipMovementBoundaryY2;
	public static float cameraDistance;
	ModifierCombo modifierCombo;

	//Getters
	public ModifierCombo returnModCombo(){return modifierCombo;}

	void Start() {
		cameraDistance = Camera.main.transform.position.y; //distance from camera to plane
	}

	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 moveAmount = new Vector3(moveHorizontal, 0, moveVertical) * speed;	
		transform.Translate(moveAmount * Time.deltaTime );


		// Stops player from exiting the side of screen.
		transform.position = new Vector3 (
			Mathf.Clamp(transform.position.x, shipMovementBoundaryX1, shipMovementBoundaryX2), 
		    0.0f,
			Mathf.Clamp(transform.position.z, shipMovementBoundaryY1, shipMovementBoundaryY2)
		);
	}



	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Destroy (gameObject);
		}
	}

	void SetSecondaryWeaponModifier(ModifierType modifierType) {
		if ( modifierType == ModifierType.None)
			return;

		// We use string 
		modifierCombo = new ModifierCombo(modifierCombo); // copies the existing modifierCombo... new projectiles will use this, but old projectiles will use the old copy that they still have.  Getting the max bang for our buck out of reference counting :)

		if ( modifierType < ModifierType.NUM_ELEMENTAL_MODIFIERS ) { // ElementalModifier
			// update the elemental modifier
			switch(modifierType) {
				case ModifierType.Poison : modifierCombo.elementalModifier = new PoisonModifier(); break;
//				case ModifierType.EMP : modifierCombo.elementalModifier = new PoisonModifier(); break;
				case ModifierType.Explosion : modifierCombo.elementalModifier = new ExplosionModifier(); break;
				}
			}
		else { // BehavioralModifier
			// update the behavioral modifier
			switch(modifierType) {
//				case ModifierType.HeatSeeking : modifierCombo.behavioralModifier = new HeatSeekingModifier(); break;
				case ModifierType.Mitosis : modifierCombo.behavioralModifier = new MitosisModifier(); break;
			}
		}
	}
	
	// <--- This gets called by your script that does the nemey
//	public void OnEnemyPowerSteal(GameObject enemy) {
//		SetSecondaryWeaponModifier(enemy.GetComponent<HitPoints>.secondaryWeaponModifier);
//	}


}