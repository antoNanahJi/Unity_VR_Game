using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float MovementSpeed=5.0f;
	[SerializeField] float RotationSpeed=45.0f;
	[SerializeField] GameObject myHand;

	public LineRenderer Lazer;
	public float DistanceHand=0.4f;
	public bool isSneaking;

	private bool canGrapObject = true;
	private bool isTarget=false;
	private Vector3 mousePosition;
	private GameObject Target = null;
	Ray mRay;
	RaycastHit mHit;
	[SerializeField] float Distance=10.0f;
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
		mousePosition.z = DistanceHand;
		myHand.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
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
			transform.Rotate (Vector3.up*-RotationSpeed*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up*RotationSpeed*Time.deltaTime);
		}
	}
	void GrabDropObject()
	{
		mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButton (0)) {
			if (canGrapObject) {
				if (Physics.Raycast (mRay, out mHit, Distance)) {
					if (mHit.transform.gameObject.tag == "ObjectToGrap") {
						Target = mHit.transform.gameObject;
						isTarget = true;
						canGrapObject = false;
					}
				}
			}
		}
		if (isTarget) {
			Target.transform.position = new Vector3 (myHand.transform.position.x,
				myHand.transform.position.y,
				myHand.transform.position.z);
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
			if (!canGrapObject)
			{
				isTarget = false;
				Target.transform.position = new Vector3 (myHand.transform.position.x,
					myHand.transform.position.y,
					myHand.transform.position.z);
				canGrapObject = true;
			}
		}
	}

}
