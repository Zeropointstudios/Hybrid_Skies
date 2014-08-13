using UnityEngine;
using System.Collections;

[System.Serializable]
public enum ModifierType {
	Poison,
	EMP,
	Explosion,
	NUM_ELEMENTAL_MODIFIERS,

	HeatSeeking = NUM_ELEMENTAL_MODIFIERS, //divides the enum list into two types via this special constant trick
	Mitosis,
	Rebound,

	None
};

public class Modifier {
	public virtual void OnProjectileInit(Projectile projectile) {}
	public virtual void OnProjectileDestroy(Projectile projectile) {}
}

public class ElementalModifier : Modifier {}

public class BehavioralModifier : Modifier {}

// It's important for the two to stay together in a combination like this
public class ModifierCombo {
	ElementalModifier elementalModifier;
	BehavioralModifier behavioralModifier;

	// Copy constructor
	public ModifierCombo(ModifierCombo modifierCombo) {
		elementalModifier = modifierCombo.elementalModifier;
		behavioralModifier = modifierCombo.behavioralModifier;
	}
	
	// Mutators
	public void SetElementalModifier(ElementalModifier newElementalModifier) { elementalModifier = newElementalModifier; }
	public void SetBehavioralModifier(BehavioralModifier newBehavioralModifier) { behavioralModifier = newBehavioralModifier; }
	
	public void OnProjectileInit(Projectile projectile) {
		if ( elementalModifier != null) 
			elementalModifier.OnProjectileInit(projectile);
		if ( behavioralModifier != null) 
			behavioralModifier .OnProjectileInit(projectile);
	}
	
	public void OnProjectileDestroy(Projectile projectile) {
		if ( elementalModifier != null) 
			elementalModifier.OnProjectileDestroy(projectile);
		if ( behavioralModifier != null) 
			behavioralModifier .OnProjectileDestroy(projectile);
	}
}
