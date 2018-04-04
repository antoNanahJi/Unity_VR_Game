using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoScript : MonoBehaviour {
	Animator anim;
	AudioSource aud;
	[SerializeField] AudioClip [] clips;
	int random;

	// Use this for initialization
	void Start () {
		aud = this.gameObject.GetComponent<AudioSource> ();
		anim = this.gameObject.GetComponent<Animator> ();
		anim.enabled = false;
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			anim.enabled = true;
			random = Random.Range (0,3);
			aud.clip=clips[random];
			aud.Play ();

		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag=="Player")
		{
			
			aud.Pause ();
			anim.enabled = false;
		}
	}

		
}
