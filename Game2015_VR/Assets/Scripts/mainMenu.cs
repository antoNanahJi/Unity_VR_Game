using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
	private bool doorClosed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if ((Input.GetMouseButtonDown(0) ||OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 1.0f) && doorClosed) {
			
			SceneManager.LoadScene ("Main");

		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			
			doorClosed = true;
		}
	}
	void sceneChange()
	{
		
	}
}
