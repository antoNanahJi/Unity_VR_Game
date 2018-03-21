﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float MovementSpeed=5.0f;
	[SerializeField] float RotationSpeed=2.0f;
	[SerializeField]float speed=90.0f;
	[SerializeField] GameObject myHand;
	[SerializeField] GameObject laserPointer;
	[SerializeField] Camera     playerCamera;

	public LineRenderer Lazer;
	public float DistanceHand= 10.0f;
	float newRotationX;
	public bool isSneaking;

	Vector3 hitPosition;

	private bool canGrapObject = true;
	private bool isTarget=false;
	private Vector3 mousePosition;
	private GameObject Target = null;
	Ray mRay;
	RaycastHit mHit;
	[SerializeField] float Distance=10.0f;

	float distanceFromHandZ =  0.2f;
	float distanceFromHandY =  0.2f;
	// Use this for initialization
	void Start () {
		mHit = new RaycastHit ();
		Lazer.enabled = false;

	}

	// Update is called once per frame
	void Update () {
		HandFollowMouse ();
		MovePlayer ();
		GrabDropObject ();
	}
	void HandFollowMouse()
	{
		mousePosition = Input.mousePosition;
		mousePosition.z += DistanceHand;
		myHand.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

		myHand.transform.rotation = playerCamera.transform.rotation;

		if (isTarget) {

			mousePosition = Input.mousePosition;
			mousePosition.z += DistanceHand + 0.2f ;
			Target.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
	
		}

	}

	void MovePlayer()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward*MovementSpeed*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.forward*-MovementSpeed*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up*-RotationSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up*RotationSpeed);
		}
	}
	void GrabDropObject()
	{
		
		if (Input.GetMouseButton (0)) {
			
			if (canGrapObject) {
				mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast (mRay, out mHit, Distance)) {
					if (mHit.transform.gameObject.tag == "ObjectToGrap") {
						Target = mHit.transform.gameObject;
						isTarget = true;
						canGrapObject = false;
					}
				}
			}
		}

	
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!canGrapObject) {
				Lazer.enabled = true;
				Lazer.SetPosition (0, myHand.transform.position);
				Lazer.SetPosition (1, myHand.transform.position + (myHand.transform.up * -1.0f));
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			if (!canGrapObject) {
				Lazer.enabled = false;
				Target.transform.position = new Vector3 (Lazer.GetPosition (1).x,
					Lazer.GetPosition (1).y,
					Lazer.GetPosition (1).z);
				isTarget = false;
				canGrapObject = true;
			}
		}

		if (Input.GetMouseButton (1)) 
		{
			Lazer.enabled = true;
			mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Lazer.SetPosition (0, laserPointer.transform.position);
			Lazer.SetPosition (1, laserPointer.transform.position +  laserPointer.transform.forward * 10);	

			if (Physics.Raycast (mRay.origin, laserPointer.transform.TransformDirection(Vector3.forward), out mHit)) 
			{
				Lazer.SetPosition (1, mHit.point);	
				hitPosition = mHit.point;
			}


		}

		if (Input.GetMouseButtonUp (1)) 
		{
			Lazer.enabled = false;

			if (!canGrapObject)
			{
				isTarget = false;
				//mousePosition = Input.mousePosition;
				//mousePosition.z += DistanceHand + 0.2f ;
				Target.transform.position = hitPosition;
				canGrapObject = true;
			}
		}
	}

}
