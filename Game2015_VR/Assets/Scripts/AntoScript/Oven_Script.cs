using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven_Script: MonoBehaviour {
	Animator anim;
	AudioSource aud;
	[SerializeField] Light light;
	[SerializeField] Transform ghostSP;
	[SerializeField] GameObject ghost;

	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
		aud = this.gameObject.GetComponent<AudioSource> ();
		anim.enabled = false;
		light.enabled = false;
		aud.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			anim.enabled = true;
			aud.Play ();
			light.enabled = true;
			InvokeRepeating ("Ghost",0.0f,2.0f);

		}
	}
	void Ghost()
	{
		Instantiate (ghost,ghostSP.transform.position,ghostSP.transform.rotation);
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag=="Player")
		{
			aud.Pause ();
			anim.enabled = false;
			CancelInvoke ();
			light.enabled = false;
		}
	}
}
