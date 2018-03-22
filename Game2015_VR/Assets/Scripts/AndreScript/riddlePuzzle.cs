using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddlePuzzle : MonoBehaviour {

	// Bool variables
	public static bool sunCheck = false;
	public static bool moonCheck = false;
	public static bool starCheck = false;

	public static int objectCheck = 0;

	// Light objects
	private Light sunLight;
	private Light moonLight;
	private Light starLight;

	// Private object
	private GameObject starObject;
	private GameObject triggerObject;

	// Audio Files
	private AudioSource correctObject;
	private AudioSource doorSlam;


	void Start()
	{
		sunLight = this.gameObject.GetComponentInChildren<Light> ();
		moonLight = this.gameObject.GetComponentInChildren<Light> ();
		starLight = this.gameObject.GetComponentInChildren<Light> ();
		correctObject = gameObject.GetComponent<AudioSource> ();
	}

	// Triggers when proper object is placed on pedestal
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 3.0f, this.transform.position.z);

		if (other.gameObject.name == "Sun" && this.gameObject.name == "PedestalSun") {
			sunCheck = true;
			sunLight.enabled = true;
			correctObject.Play ();
			objectCheck++;
		}

		if (other.gameObject.name == "Moon" && this.gameObject.name == "PedestalMoon") {
			moonCheck = true;
			moonLight.enabled = true;
			correctObject.Play ();
			objectCheck++;
		}

		if (other.gameObject.name == "Star" && this.gameObject.name == "PedestalStar") {
			starCheck = true;
			starLight.enabled = true;
		}
	}
}
