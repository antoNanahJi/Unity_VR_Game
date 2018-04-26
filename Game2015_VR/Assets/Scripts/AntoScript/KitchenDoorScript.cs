using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorScript : MonoBehaviour {
	Animator anim;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
		anim.enabled = false;
		aud = this.gameObject.GetComponent<AudioSource> ();
	}
	

	void CloseDoor()
	{
		anim.enabled = true;
		anim.SetBool("Close",true);
		aud.Play();
		Invoke ("KillTaha",1.5f);
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Invoke ("CloseDoor",0.10f);

		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name=="key") 
		{
			other.gameObject.transform.position = new Vector3(0.0f,0.0f,0.0f);
			other.gameObject.SetActive (false);
			//Destroy(other.gameObject);
			anim.enabled = true;
			anim.SetBool ("Close",false);
		}
	}

	void KillTaha()
	{
		aud.enabled = false;
	}
}
