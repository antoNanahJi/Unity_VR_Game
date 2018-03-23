using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : riddlePuzzle {

	public Collider screamTrigger;
	public GameObject slenderMan;
	public AudioSource _Scream;


	// Use this for initialization
	void Start () {
		slenderMan = GameObject.Find ("SlenderMan");
		slenderMan.SetActive (false);

		screamTrigger = this.gameObject.GetComponent<Collider>();
		screamTrigger.enabled = false;

		_Scream = this.gameObject.GetComponent <AudioSource> ();

	}

	// Update is called once per frame
	void Update () {
		if (sunCheck == true && moonCheck == true && starCheck == true) {
			screamTrigger.enabled = true;
		}
	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.CompareTag("Player")) 
		{
			SlenderPlay ();
		}
	}

	void SlenderPlay()
	{
		//triggerObject.enabled = false;
		_Scream.Play ();
		slenderMan.SetActive (true);
		Destroy (this.gameObject, 3.0f);
	}
}
