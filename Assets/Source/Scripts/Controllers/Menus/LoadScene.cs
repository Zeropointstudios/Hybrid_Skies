using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public string scene;

	public void LoadMainGame() {
		Application.LoadLevel ("Pablo"); 
	}
}
