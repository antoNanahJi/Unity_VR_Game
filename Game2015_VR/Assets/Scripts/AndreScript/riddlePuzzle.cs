using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddlePuzzle : MonoBehaviour {
	[SerializeField] GameObject sunObject;
	[SerializeField] GameObject moonObject;
	[SerializeField] GameObject starObject;
	[SerializeField] GameObject sunSpot;
	[SerializeField] GameObject moonSpot;
	[SerializeField] GameObject starSpot;

	private bool sunCheck = false;
	private bool moonCheck = false;
	private bool starCheck = false;

	void Start()
	{
		sunObject = GameObject.Find ("Sun");
		moonObject = GameObject.Find ("Moon");
		starObject = GameObject.Find ("Star");
		sunSpot = GameObject.Find ("PedestalSun");
		moonSpot = GameObject.Find ("PedestalMoon");
		starSpot = GameObject.Find ("PedestalStar");
	}

	// Triggers when proper object is placed on pedestal

	void OnTriggerEnter(Collider collider)
	{
		if (sunSpot == sunObject) {
			sunCheck = true;
			Debug.Log (sunCheck);
		}
		
	}
}
