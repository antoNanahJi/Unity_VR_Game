using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : riddlePuzzle {

	public Collider screamTrigger;
	public GameObject slenderMan;
	public AudioSource _Scream;


	// Use this for initialization
	void Start () {
		
		//slenderMan = gameObject.GetComponent<GameObject> ();
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
			_Scream.Play ();
			GameObject Slender = Instantiate (slenderMan, new Vector3 (this.transform.position.x + 3.7f, this.transform.position.y, this.transform.position.z), this.transform.rotation); 
			Destroy (this.gameObject, 3.0f);
			Destroy (Slender, 2.5f);

		}
	}

	void SlenderDestroy()
	{
		DestroyImmediate (slenderMan, true);
	}
}
