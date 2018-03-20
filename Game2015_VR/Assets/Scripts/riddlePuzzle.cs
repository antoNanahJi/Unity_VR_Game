using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddlePuzzle : MonoBehaviour {
	[SerializeField] GameObject sunObject;
	[SerializeField] GameObject moonObject;
	[SerializeField] GameObject starObject;

	private int counter = 0;
	private int counterMax = 3;

	void Start()
	{
		sunObject = GameObject.FindWithTag("sunToy");
		moonObject = GameObject.FindWithTag("moonToy");
		starObject = GameObject.FindWithTag("starToy");
	}

	// Triggers when proper object is placed on pedestal

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("sunSpot")) 
		{
			if (counter < counterMax) {
				counter++;
				// Display correct object messeage
			}

			if (counter == counterMax) {
				// All objects placed, puzzle solved
			}
		}

		if (col.CompareTag ("moonSpot")) {
			if (counter < counterMax) {
				counter++;
				// Display correct object messeage
			}

			if (counter == counterMax) {
				// All objects placed, puzzle solved
			}
		}

		if (col.CompareTag ("starSpot")) {
			if (counter < counterMax) {
				counter++;
				// Display correct object messeage
			}

			if (counter == counterMax) {
				// All objects placed, puzzle solved
			}
		}
	}
}
