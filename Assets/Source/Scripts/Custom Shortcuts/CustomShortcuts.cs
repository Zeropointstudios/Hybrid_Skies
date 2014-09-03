using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyShortcuts : Editor
{
	[MenuItem("GameObject/ActiveToggle _a")]
	static void ToggleActivationSelection()
	{
		var go = Selection.activeGameObject;
		go.SetActive(!go.activeSelf);
	}
}