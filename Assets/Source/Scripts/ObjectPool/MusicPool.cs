using UnityEngine;
using System.Collections;

public class MusicPool : MonoBehaviour {

	public AudioSource MusicStream;
	//public AudioClip Loop1;
	//public AudioClip Loop2;
	//public AudioClip Loop3;
	int SampleLength;
	int CurrentClip;
	int Clips;

	// Use this for initialization
	public void Start () {
		CurrentClip = 0;
		Clips = 3;
		AudioSource[] Loops = GetComponents<AudioSource> ();

		MusicStream = Loops[CurrentClip];
		SampleLength = MusicStream.clip.samples;
		MusicStream.Play ();
/*
		//while (CurrentClip != Clips) {
			MusicStream.Play ();
		
			if (MusicStream.isPlaying) { //this is not working - need something else to test whether end of clip is reached
				}
			else {
				++CurrentClip;
				MusicStream = Loops[CurrentClip];
				SampleLength = MusicStream.clip.samples;
			}
*/		//}
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
