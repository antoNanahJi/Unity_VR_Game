using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibDoor: MonoBehaviour {

	bool doorClosed = false;
	public GameObject door;
	AudioSource doorSound;
	public AudioSource knocking;
	public GameObject audioHolder;
	// Use this for initialization
	void Start () {
		doorSound = this.gameObject.GetComponent<AudioSource> ();
		knocking = audioHolder.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)&& doorClosed) {
			door.transform.Rotate(0.0f,-90.0f,0.0f);

			Invoke ("doorAuto", 4.0f);

		}

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		doorClosed = true;
	
	}
	void OnTriggerExit(Collider other)
	{
		doorClosed = false;
	}
	void doorAuto()
	{
		door.transform.Rotate(0.0f,90.0f,0.0f);
		doorSound.Play ();
		Invoke ("knockingAudio", 10.0f);
	}
	void knockingAudio()
	{
		knocking.Play ();
	}


}
