using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

#if UNITY_IPHONE
	//on event player puts down finger 1
	//time scale = 1.0
	void Awake() {
		Time.timeScale = 0.0f;
	}

	void OnEnable() {
		TestTouchInput.Pause += PauseGame;
		TestTouchInput.Unpause += UnpauseGame;
	}

	void OnDisable() {
		TestTouchInput.Pause -= PauseGame;
		TestTouchInput.Unpause -= UnpauseGame;
	}

	void PauseGame() {
		Time.timeScale = 0.0f;
	}

	void UnpauseGame() {
		Time.timeScale = 1.0f;
	}

#endif

}
