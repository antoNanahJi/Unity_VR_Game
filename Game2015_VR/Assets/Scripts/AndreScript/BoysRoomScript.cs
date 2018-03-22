using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoysRoomScript : riddlePuzzle {

	bool doorOpen = true;

	[SerializeField] GameObject starObj;
	// Objects
	private GameObject starFrame;
	private GameObject boyDoor;

	// Audio objects
	private AudioSource doorSlamSound;
	private AudioSource scaryWhispers;
	private AudioSource puzzleComplete;

	// Use this for initialization

	void Start () {
		boyDoor = GameObject.Find("BoysRoomDoor2");

		doorSlamSound = GameObject.Find ("doorAudio").GetComponent<AudioSource> ();
		scaryWhispers = GameObject.Find ("ScaryWhispers").GetComponent<AudioSource> ();
		puzzleComplete = GameObject.Find ("riddleComplete").GetComponent<AudioSource> ();
		// Initializes objects to inactive
		starFrame = GameObject.Find ("Puzzle3");
		starFrame.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (sunCheck == true && moonCheck == true) {
			starFrame.SetActive (true);
		}

		if (objectCheck == 2) {
			starObj.SetActive (true);
		}

		if (sunCheck == true && moonCheck == true && starCheck == false && doorOpen) {
			doorOpen = false;
			RoomDoor ();
			scaryWhispers.Play ();
		}

		if (sunCheck == true && moonCheck == true && starCheck == true && doorOpen == false) {
			doorOpen = true;
			boyDoor.transform.Rotate(0.0f, -90.0f, 0.0f);
			puzzleComplete.Play ();
		}
	}
		
		
	public void RoomDoor()
	{
		boyDoor.transform.Rotate (0.0f, 90.0f, 0.0f);
		doorSlamSound.Play ();
	}
}
