using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scareSoundScript : MonoBehaviour {
	public GameObject soundHolder;
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

			Invoke ("killAudio", 10.0f);



		}

	}
	void killAudio()
	{
		Destroy (aud);
	}



}
