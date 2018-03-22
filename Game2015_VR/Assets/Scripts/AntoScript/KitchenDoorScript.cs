using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorScript : MonoBehaviour {
	Animator anim;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
		aud = this.gameObject.GetComponent<AudioSource> ();
		anim.enabled = false;
		aud.Pause ();
	}
	

	void CloseDoor()
	{
		aud.Play ();
		anim.enabled = true;
		anim.SetBool("Close",true);
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Invoke ("CloseDoor",0.10f);
		
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name=="key") {
			other.gameObject.transform.position = this.gameObject.transform.position;
			other.gameObject.SetActive (false);
			anim.enabled = true;
			anim.SetBool ("Close",false);
			aud.enabled = false;
		}
	}
}
