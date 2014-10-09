using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Pauser : MonoBehaviour {

	public GameObject Menu;

#if UNITY_EDITOR			

	bool isMenu = true;
	
	void Update() {
		if (Input.GetKeyDown ("m")) {
			Menu.gameObject.SetActive(!isMenu);
			isMenu = !isMenu;
		}
	}

#elif UNITY_IPHONE
	public Canvas pauseMenu;
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
		Menu.setActive(true);

	}

	void UnpauseGame() {
		Time.timeScale = 1.0f;
		isPaused = false;
		Menu.setActive(false);

	}

#endif

}
