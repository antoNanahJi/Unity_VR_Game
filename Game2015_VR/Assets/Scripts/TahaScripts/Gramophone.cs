using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : MonoBehaviour {
	static AudioSource BackgroundMusic;
	AudioSource playerMusic;
	GameObject player;
	bool music = false;
	static bool playing = false;
	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		playerMusic = player.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if(OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) >= 1 && music)
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
				//BackgroundMusic.Stop ();
				BackgroundMusic.Play ();
				playing = true;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			music = true;

		}
	}
	void OnTriggerExit(Collider other)
	{
		music = false;
	}
}
