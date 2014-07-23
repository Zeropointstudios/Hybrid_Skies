using UnityEngine;
using System.Collections;

public class HighLightTarget : MonoBehaviour {
	Color targetColor;
	public Color highLightColor;
	bool toggleHighlight = false;
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Absorb.cameraDistance))
		{

		}

	}
}

