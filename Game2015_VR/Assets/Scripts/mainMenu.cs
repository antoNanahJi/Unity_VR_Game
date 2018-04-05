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
		if (Input.GetKeyDown(KeyCode.Mouse0)&& doorClosed) {
			
			SceneManager.LoadScene ("Main");

		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			doorClosed = true;
		}
	}
	void sceneChange()
	{
		
	}
}
