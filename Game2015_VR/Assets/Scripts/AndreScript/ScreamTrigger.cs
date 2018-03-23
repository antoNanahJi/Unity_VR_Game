using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : riddlePuzzle {

	private GameObject triggerObject;
	private AudioSource _Scream;

	// Use this for initialization
	void Start () {
		//triggerObject = GetComponent<BoxCollider> ();
		_Scream = this.gameObject.GetComponent <AudioSource> ();
		triggerObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (sunCheck == true && moonCheck == true && starCheck == true) {
			triggerObject.SetActive (true);
		}
	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.CompareTag("Player")) {
			_Scream.Play ();
		}
	}

}
