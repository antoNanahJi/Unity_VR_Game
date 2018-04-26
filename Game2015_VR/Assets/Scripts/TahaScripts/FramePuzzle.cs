using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePuzzle : MonoBehaviour {

	static bool fOne = false;
	static bool fTwo = false;
	static bool fThree = false;
	static bool fFour = false;
	public GameObject libDoor;
	bool releaseObject = false;
	public GameObject frame;
	public GameObject scroll;
	//public GameObject snapsy;
	static bool stop = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fOne &&fTwo&&fThree&&fFour && stop) {
			stop = false;
			libDoor.transform.Rotate (0.0f, -90.0f, 0.0f);
			frame.SetActive (false);
			scroll.SetActive(true);
		}

		if (OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) <= 0) 
		{
			releaseObject = true;
		//Debug.Log ("0");
		}
		if (OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) >= 1) 
		{
			//Debug.Log ("1");
			releaseObject = false;
		}
			



	}
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Letter" && releaseObject)
		{
			other.gameObject.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
			Debug.Log ("We here ");
		}
		if (other.gameObject.name == "eLet" && this.gameObject.name == "Frame1") {
			fOne = true;
		}
		if (other.gameObject.name == "zLet" && this.gameObject.name == "Frame2")
			fTwo = true;
		if (other.gameObject.name == "oLet" && this.gameObject.name == "Frame3")
			fThree = true;
		if (other.gameObject.name == "nLet" && this.gameObject.name == "Frame4")
			fFour = true;
	}

}
