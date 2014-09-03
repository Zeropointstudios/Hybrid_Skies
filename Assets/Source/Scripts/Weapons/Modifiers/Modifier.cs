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

public class ModifierCombo {
	string elementalModifier, behavioralModifier;		 //a modifier combo holds a field of each type of Modifier

	//getters
	public string returnElemental(){return elementalModifier;}
	public string returnBehavioral(){return behavioralModifier;}

	//setters
	public void setElemental(string e){elementalModifier = e;}
	public void setBehavioral(string b){behavioralModifier = b;}

	// Constructor
	public ModifierCombo() { 
		elementalModifier = "";
		behavioralModifier = "";
	}
}
