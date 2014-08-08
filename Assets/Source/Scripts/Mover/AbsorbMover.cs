using UnityEngine;
using System.Collections;

public class AbsorbMover : Mover {

	void Update()
	{				
		// Makes absorb field follow mouse while click is held down.
		Vector3 target = Camera.main.ScreenToWorldPoint (
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, PlayerController.cameraDistance));
		transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
	}
}
