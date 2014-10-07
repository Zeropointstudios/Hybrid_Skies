using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public const float screenScrollRate = 4.0f;	// The overall rate at which the screen scrolls.
	public static float screenScrollSpeed = 1.0f;  // The speed turned up to 1 or down to 0, to pause, slow down, speed up, etc.

	private static GameController gameController;

	public void Awake() {
		gameController = Finder.GetGameController();
	}

	public static float GetScreenDrop() { 
		return screenScrollRate * screenScrollSpeed * Time.deltaTime; 
	}  
}
