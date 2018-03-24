using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementScript : MonoBehaviour {
	[SerializeField] GameObject scrollPlaced1;
	[SerializeField] GameObject scrollPlaced2;
	[SerializeField] GameObject scrollPlaced3;
	[SerializeField] GameObject scrollPlaced4;
	private AudioSource complete;
	int count = 0;
	// Use this for initialization
	void Start () {
		complete = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider _collision){
		if (_collision.gameObject.name == "scroll1") 
		{
			Instantiate (scrollPlaced1,scrollPlaced1.transform.position ,scrollPlaced1.transform.rotation);
			complete.Play ();
			count++;
		}
		if (_collision.gameObject.name == "scroll2") 
		{
			Instantiate (scrollPlaced2,scrollPlaced2.transform.position ,scrollPlaced2.transform.rotation);
			complete.Play ();
			count++;
		}
		if (_collision.gameObject.name == "scroll3") 
		{
			

			Instantiate (scrollPlaced3,scrollPlaced3.transform.position ,scrollPlaced3.transform.rotation);
			complete.Play ();
			count++;
		}
		if (_collision.gameObject.name == "scroll4") 
		{
			

			Instantiate (scrollPlaced4,scrollPlaced3.transform.position ,scrollPlaced3.transform.rotation);
			complete.Play ();
			count++;
		}
		if (count == 4) 
		{
			Debug.Log ("Completed");
		}
	}
}
