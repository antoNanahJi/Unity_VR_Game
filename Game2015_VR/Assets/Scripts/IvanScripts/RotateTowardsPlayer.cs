﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour {

	[SerializeField] GameObject playerObj;
	private Vector3 directionVector;
	private float   distanceToPlayer;
	private float   minimunDistanceToRotate = 10.0f;
	private float   rotationSpeed = 10.0f;
	private Quaternion destRot;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Get the a direction vector towards the player
		directionVector = playerObj.transform.position - transform.position;
		//Get the magnitud of the direction vector
		distanceToPlayer = directionVector.magnitude;

		//If the distance from the object to the player is less than indicated then rotate towards player
		if (distanceToPlayer <= minimunDistanceToRotate) 
		{
			// Find destination rotation we want to look towards to
			destRot = Quaternion.LookRotation (directionVector);

			//Rotate transform from our current rotation to the angle indicated by destination rotation
			transform.rotation = Quaternion.RotateTowards (transform.rotation, destRot, rotationSpeed * Time.deltaTime);
			//Update rotation angles in Y as we only want to move on that axis.
			transform.eulerAngles = new Vector3 (0.0f, transform.eulerAngles.y, 0.0f);
		
		}
	}
}