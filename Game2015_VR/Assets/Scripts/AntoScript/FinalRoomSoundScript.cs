using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomSoundScript : MonoBehaviour {

	AudioSource aud;
	// Use this for initialization
	void Start () {
		aud = this.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log ("AHH");
			aud.Play ();
		}

	}
}
