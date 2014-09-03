using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModifierDisplay : MonoBehaviour {

	public Text bMod, eMod;

	public void setBMod(string s){bMod.text = s;}
	public void setEMod(string s){eMod.text = s;}
}
