using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoysRoomScript : riddlePuzzle {

	bool doorOpen = true;
	
	private GameObject boyDoor;
	private GameObject starObj;

	// Audio objects
	private AudioSource doorSlam;
	private AudioSource scaryWhispers;
	private AudioSource puzzleComplete;
	// Use this for initialization

	void Start () {
		boyDoor = GameObject.Find("BoysRoomDoor2");

		doorSlam = GameObject.Find ("doorAudio").GetComponent<AudioSource> ();
		scaryWhispers = GameObject.Find ("ScaryWhispers").GetComponent<AudioSource> ();
		puzzleComplete = GameObject.Find ("riddleComplete").GetComponent<AudioSource> ();

		starObj = GameObject.Find ("Star");
		starObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
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
		doorSlam.Play ();
	}
}
