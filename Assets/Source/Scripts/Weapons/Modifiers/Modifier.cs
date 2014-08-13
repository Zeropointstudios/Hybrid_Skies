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
	Rebound
};

public class Modifier {
	 
}