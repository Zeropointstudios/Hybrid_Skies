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

public class Modifier : MonoBehaviour {
	public string modifierName;						//name is needed for when the modifier component is added to the Projectile
	public string returnName(){return modifierName;}
	protected void setName(string name){modifierName = name;}
}

public class ElementalModifier : Modifier {}	 //two types of modifiers that are seperate for the sake of identification 
public class BehavioralModifier : Modifier {}		 //you can only have one of teach type at a time

// It's important for the two to stay together in a combination like this
public class ModifierCombo {
	public ElementalModifier elementalModifier;		 //a modifier combo holds a field of each type of Modifier
	public BehavioralModifier behavioralModifier;	 //these fields are used to modify the projectile 

	// Copy constructor
	public ModifierCombo(ModifierCombo modifierCombo) {
		elementalModifier = modifierCombo.elementalModifier;		//when the copy constructor is called, copies the current state of
		behavioralModifier = modifierCombo.behavioralModifier;		//each type of modifier onto a projectile's modifierCombo
	}
	
//	// Mutators
//	public void SetElementalModifier(ElementalModifier newElementalModifier) { elementalModifier = newElementalModifier; }
//	public void SetBehavioralModifier(BehavioralModifier newBehavioralModifier) { behavioralModifier = newBehavioralModifier; }
//	
//	public void OnProjectileInit(Projectile projectile) {
//		if ( elementalModifier != null) 
//			elementalModifier.OnProjectileInit(projectile);
//		if ( behavioralModifier != null) 
//			behavioralModifier.OnProjectileInit(projectile);
//	}
//	
//	public void OnProjectileDestroy(Projectile projectile) {
//		if ( elementalModifier != null) 
//			elementalModifier.OnProjectileDestroy(projectile);
//		if ( behavioralModifier != null) 
//			behavioralModifier.OnProjectileDestroy(projectile);
//	}
}
