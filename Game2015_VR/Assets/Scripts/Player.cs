using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float MovementSpeed=5.0f;
	[SerializeField] float RotationSpeed=45.0f;
	[SerializeField] GameObject myHand;
	private bool canGrapObject = true;
	private bool isTarget=false;
	private GameObject Target = null;
	Ray mRay;
	RaycastHit mHit;
	[SerializeField] float Distance=10.0f;
	// Use this for initialization
	void Start () {
		mHit = new RaycastHit ();
	}
	
	// Update is called once per frame
	void Update () {
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
		if (Input.GetMouseButton (1)) {
			if (!canGrapObject) {
				if (Physics.Raycast (mRay, out mHit, Mathf.Infinity)) {
					Target.transform.position = new Vector3 (mHit.transform.position.x,
						mHit.transform.position.y,
						mHit.transform.position.z);
						isTarget = false;
						canGrapObject = true;
					}
				}
			}


	}
}
