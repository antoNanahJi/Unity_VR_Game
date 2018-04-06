using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstructions : MonoBehaviour {

	GameObject player;
	bool ActiveCanvas = false;
	[SerializeField] GameObject canvas;

	float Distance = 2.0f;
	void Start()
	{   //Do not fuck with
		player = GameObject.FindWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {

		float magnitude = Vector3.Distance (player.transform.position, transform.position);

		if (magnitude <= Distance && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1.0f ) && !ActiveCanvas)
		{
			ActiveCanvas = true;
			canvas.SetActive(true);
			return;
		}
	}
}
