using UnityEngine;
using System.Collections;

public class FXBUNDLE_Shields : MonoBehaviour {
	Transform tFXSet_Shields;
	Transform tFXSet_Explode_Shields;
	//bool bShieldIsOn = false;

	// **** Public Functions to Call to Invoke Effects

	// ShieldsOn will turn the shields effects on.
	public void ShieldsOn ()
	{
		if (tFXSet_Shields) {
			print ("FXBUNDLE_Shields: ShieldsOn()");
			tFXSet_Shields.SendMessage ("PlayAll");
			//bShieldIsOn = true;
		}
		else {
			print ("FXBUNDLE_Shields: tFX_Shields is undefined");
		}
	}

	// ShieldsOn will turn the shields effects on.
	public void ShieldsOff()
	{
		if (tFXSet_Shields) {
				print ("FXBUNDLE_Shields: ShieldsOff()");
				tFXSet_Shields.SendMessage ("StopAll");
				//bShieldIsOn = false;
		}
		else {
			print ("tFX_Shields is undefined");
		}
	}

	//ShieldsExplode will play the Explode_Shields effect and then turn off the shields.
	public void ShieldsExplode()
	{
		if (tFXSet_Explode_Shields) {
			tFXSet_Explode_Shields.SendMessage ("PlayAll");
			ShieldsOff ();
			//bShieldIsOn = false;
		}
		else {
			print ("tFX_Shields is undefined");
		}
	}

	// Use this for initialization
	void Start () {
		tFXSet_Shields = transform.FindChild ("FXSet_Shields");
		tFXSet_Explode_Shields = transform.FindChild ("FXSet_Explode_Shields");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
