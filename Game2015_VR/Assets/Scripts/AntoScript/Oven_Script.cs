﻿using System.Collections;
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
		
		aud = this.gameObject.GetComponent<AudioSource> ();
		light.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			light.enabled = true;
			Invoke ("Ghost",0.0f);
			aud.Play ();
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
			
			light.enabled = false;
			aud.Pause ();
		}
	}
}
