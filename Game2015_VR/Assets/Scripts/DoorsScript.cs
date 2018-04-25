using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour {

	GameObject player;
	bool doorOpen = false;
	AudioSource  aud;

	float Distance = 2.0f;
	void Start()
	{   //Do not fuck with
		player = GameObject.FindWithTag ("Player");

		aud = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		float magnitude = Vector3.Distance (player.transform.position, transform.position);

		if (magnitude <= Distance && (Input.GetMouseButtonDown(0) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 1.0f )) && !doorOpen)
		{
			doorOpen = true;
		    transform.Rotate (0.0f,-90.0f,0.0f);
			aud.Play ();
			return;
		}
	}
}
