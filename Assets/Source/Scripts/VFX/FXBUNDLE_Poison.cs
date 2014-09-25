using UnityEngine;
using System.Collections;

public class FXBUNDLE_Poison : MonoBehaviour {
	Transform tFXSet_Persist_Poison;
	Transform tFXSet_Explode_PoisonOn;
	bool bPoisonIsOn = false;
	
	// **** Public Functions to Call to Invoke Effects
	
	// PoisonOn will turn the shields effects on.
	public void PoisonOn ()
	{
		if ((tFXSet_Persist_Poison)&&(tFXSet_Explode_PoisonOn)) {
			print ("FXBUNDLE_Poison: PoisonOn()");
			tFXSet_Persist_Poison.SendMessage ("PlayAll");
			tFXSet_Explode_PoisonOn.SendMessage ("PlayAll");
			bPoisonIsOn = true;
		}
		else {
			print ("FXBUNDLE_Poison: tFX_Persist_Poison is undefined");
		}
	}
	
	// PoisonOn will turn the shields effects on.
	public void PoisonOff()
	{
		if ((tFXSet_Persist_Poison)&&(tFXSet_Explode_PoisonOn)) {
			print ("FXBUNDLE_Poison: PoisonOff()");
			tFXSet_Persist_Poison.SendMessage ("StopAll");
			tFXSet_Explode_PoisonOn.SendMessage ("PlayAll");
			bPoisonIsOn = false;
		}
		else {
			print ("FXBUNDLE_Poison: tFXSet_Persist_Poison is undefined");
		}
	}
	
	// Use this for initialization
	void Start () {
		tFXSet_Persist_Poison = transform.FindChild ("FXSet_Persist_Poison");
		tFXSet_Explode_PoisonOn = transform.FindChild ("FXSet_Explode_PoisonOn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
