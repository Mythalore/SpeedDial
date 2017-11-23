using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicMode{
	FULL,
	HALF,
	MUTE,
}

public class MusicManager : MonoBehaviour {

	public AudioSource speaker;
	public MusicMode mode;

	// Use this for initialization
	void Start () {
		mode = MusicMode.FULL;
		speaker.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M)){
			switch(mode){
			case MusicMode.FULL:
				speaker.volume = 0.0f;
				mode = MusicMode.MUTE;
				break;
			case MusicMode.MUTE:
				speaker.volume = 0.5f;
				mode = MusicMode.HALF;
				break;
			case MusicMode.HALF:
				speaker.volume = 1.0f;
				mode = MusicMode.FULL;
				break;
			}
		}
	}
}
