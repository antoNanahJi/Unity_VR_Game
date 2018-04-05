using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : MonoBehaviour {
	static AudioSource BackgroundMusic;
	public AudioSource playerMusic;
	bool music = false;
	static bool playing = false;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse1)&&music)
		{
			if (playing) {
				playerMusic.Stop ();
				BackgroundMusic.Stop ();
				BackgroundMusic = this.gameObject.GetComponent<AudioSource> ();
				playing = false;
				BackgroundMusic.Play ();
			} 
			if (!playing) {
				playerMusic.Stop ();
				BackgroundMusic = this.gameObject.GetComponent<AudioSource> ();
				BackgroundMusic.Stop ();
				BackgroundMusic.Play ();
				playing = true;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			music = true;

		}
	}
	void OnTriggerExit(Collider other)
	{
		music = false;
	}
}
