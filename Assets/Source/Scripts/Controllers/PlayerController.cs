using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	public float speed;
	public float shipMovementBoundaryX1, shipMovementBoundaryX2, shipMovementBoundaryY1, shipMovementBoundaryY2;
	public static float cameraDistance;
	public static GameObject playerController;
	ModifierCombo modifierCombo;
	ModifierDisplay modifierDisplay;


	//Getters
	public ModifierCombo returnModCombo(){return modifierCombo;}
	void Awake() {
		cameraDistance = Camera.main.transform.position.y; //distance from camera to plane
		modifierCombo = new ModifierCombo ();
		modifierDisplay = GetComponent<ModifierDisplay> ();
	}

	void OnEnable() {
		Targeter.AbsorbModEvent += SetSecondaryWeaponModifier; //
	}
	
	void OnDisable() {
		Targeter.AbsorbModEvent -= SetSecondaryWeaponModifier;
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
			// Upon collision, player and enemy ship each deal damage to each other equal to their own hit points.
			float hitPoints = GetComponent<HitPoints>().hitPoints;
			GetComponent<HitPoints>().DoDamage (other.GetComponent<HitPoints>().hitPoints, transform.position);
			other.GetComponent<HitPoints>().DoDamage(hitPoints, other.transform.position);
		}
	}

	void SetSecondaryWeaponModifier(ModifierType modifierType) {
		if ( modifierType == ModifierType.None)
			return;

		if ( modifierType < ModifierType.NUM_ELEMENTAL_MODIFIERS ) { // ElementalModifier
			// update the elemental modifier
			switch(modifierType) {
				case ModifierType.Poison : modifierCombo.setElemental("PoisonModifier"); modifierDisplay.setEMod("Poison"); break;
				case ModifierType.EMP : modifierCombo.setElemental("EMPModifier"); modifierDisplay.setEMod("EMP"); break;
				case ModifierType.Explosion : modifierCombo.setElemental("ExplosionModifier"); modifierDisplay.setEMod("Explosion"); break;
				}
			}
		else { // BehavioralModifier
			// update the behavioral modifier
			switch(modifierType) {
				case ModifierType.HeatSeek : modifierCombo.setBehavioral("HeatSeekModifier"); modifierDisplay.setBMod("HeatSeek"); break;
				case ModifierType.Spread : modifierCombo.setBehavioral("SpreadModifier"); modifierDisplay.setBMod("Spread"); break;
				case ModifierType.Rebound : modifierCombo.setBehavioral("RebounderModifier"); modifierDisplay.setBMod("Rebound"); break;
			}
		}
		GetComponent<SecondaryFiring> ().setEnergyCost (modifierCombo);
	}
}