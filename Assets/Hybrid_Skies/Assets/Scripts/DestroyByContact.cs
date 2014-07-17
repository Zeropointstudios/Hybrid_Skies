using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {


	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		gameController.AddScore (scoreValue);
		Destroy (other.gameObject); // destroys bullet
		Destroy (gameObject); //destroy asterioid (destroy destroys at end of frame, so order doesnt matter
	}
}
