using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoysRoomScript : MonoBehaviour {
	
	private GameObject boyDoor;

	public riddlePuzzle riddlePuzzleScript;

	private AudioSource doorSlam;
	// Use this for initialization
	void Start () {
		boyDoor = GameObject.Find("BoysRoomDoor2");
		doorSlam = boyDoor.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (riddlePuzzle.sunCheck == true && riddlePuzzle.moonCheck == true) {
			RoomDoor ();
		}
	}

	void RoomDoor()
	{
		boyDoor.transform.Rotate (0.0f, 90.0f, 0.0f);
		doorSlam.Play ();
	
	}
}
