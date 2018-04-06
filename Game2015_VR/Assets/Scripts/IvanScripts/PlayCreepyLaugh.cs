using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCreepyLaugh : MonoBehaviour {

	private AudioSource creepyLaughAudio;
	GameObject playerObj;
	private Vector3 directionVector;
	private float   distanceToPlayer;
	private float   minimunDistanceToplay = 2.0f;
	private bool   AudioNotPlayed = false;

	// Use this for initialization
	void Start () {

		playerObj = GameObject.FindWithTag ("Player");

		creepyLaughAudio = this.gameObject.GetComponent <AudioSource> ();
	
	}

	// Update is called once per frame
	void Update () 
	{
		//Get the a direction vector towards the player
		directionVector = playerObj.transform.position - transform.position;
		//Get the magnitud of the direction vector
		distanceToPlayer = directionVector.magnitude;

		//If the distance from the object to the player is less than indicated then play sound
		if (distanceToPlayer <= minimunDistanceToplay && !AudioNotPlayed ) 
		{
			AudioNotPlayed = true;
			creepyLaughAudio.Play();
		}
	}
}
