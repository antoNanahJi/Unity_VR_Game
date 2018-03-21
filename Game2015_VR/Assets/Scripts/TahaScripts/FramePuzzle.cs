using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePuzzle : MonoBehaviour {

	static bool fOne = false;
	static bool fTwo = false;
	static bool fThree = false;
	static bool fFour = false;
	public GameObject libDoor;
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

		}
		Debug.Log (fOne + " 1");
		Debug.Log (fTwo + " 2");
		Debug.Log (fThree + " 3");
		Debug.Log (fFour + " 4");
	}
	void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.position = this.transform.position;

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
