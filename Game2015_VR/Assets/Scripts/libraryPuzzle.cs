using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class libraryPuzzle : MonoBehaviour {

	bool doorClosed = false;

	float time = 5.0f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)&& doorClosed) {
			this.transform.Rotate(0.0f,-90.0f,0.0f);
			time -= Time.deltaTime;
			doorAuto ();
		}

			


	}
	void OnTriggerEnter(Collider other)
	{
		doorClosed = true;
	}
	void OnTriggerExit(Collider other)
	{
		doorClosed = false;
	}
	void doorAuto()
	{
		
		if (time >= 0)
		{
			this.transform.Rotate(0.0f,90.0f,0.0f*Time.deltaTime);
		}
	}

}
