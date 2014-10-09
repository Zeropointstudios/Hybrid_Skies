using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	
	#if UNITY_EDITOR
	
	
	#elif UNITY_IPHONE
	//on event player puts down finger 1
	//time scale = 1.0
	
	public static bool isPaused;
	void Awake() {
		Time.timeScale = 0.0f;
		isPaused = true;
	}
	
	void OnEnable() {
		iPhonePauseHandler.Pause += PauseGame;
		iPhonePauseHandler.Unpause += UnpauseGame;
	}
	
	void OnDisable() {
		iPhonePauseHandler.Pause -= PauseGame;
		iPhonePauseHandler.Unpause -= UnpauseGame;
	}
	
	void PauseGame() {
		Time.timeScale = 0.0f;
		isPaused = true;
		
	}
	
	void UnpauseGame() {
		Time.timeScale = 1.0f;
		isPaused = false;
		
	}
	
	#endif
	
}
