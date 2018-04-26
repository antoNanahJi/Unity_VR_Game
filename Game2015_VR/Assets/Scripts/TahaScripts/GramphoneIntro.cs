using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramphoneIntro : MonoBehaviour {
	AudioSource BackgroundMusic;
	GameObject player;
	AudioSource playerMusic;
	bool music = false;
	// Use this for initialization
	void Start () {

			player = GameObject.FindWithTag ("Player");
			playerMusic = player.GetComponent<AudioSource> ();
		}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown(0) || OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) >= 1) && music) 
		{
			playerMusic.Stop ();
			//BackgroundMusic.Stop ();
			BackgroundMusic = this.gameObject.GetComponent<AudioSource> ();
			BackgroundMusic.Play ();
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
