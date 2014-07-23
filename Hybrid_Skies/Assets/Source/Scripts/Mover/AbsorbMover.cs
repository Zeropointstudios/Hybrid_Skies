using UnityEngine;
using System.Collections;

public class AbsorbMover : MonoBehaviour {

	void Update()
	{				//makes absorb field follow mouse while click is held down
		Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Absorb.cameraDistance));
		transform.position = Vector3.MoveTowards (transform.position, target, 0.5f);
	}
}
