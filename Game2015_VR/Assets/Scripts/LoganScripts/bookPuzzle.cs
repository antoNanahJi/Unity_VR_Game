using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookPuzzle : MonoBehaviour {
	[SerializeField]GameObject scroll1;
	[SerializeField]GameObject scroll2;
	[SerializeField]GameObject scroll3;
	[SerializeField]GameObject scroll4;


	private AudioSource complete;



	void Start()
	{
		complete = gameObject.GetComponent<AudioSource> ();

	}
	void OnTriggerEnter(Collider _collision){
		if (_collision.gameObject.name == "bookSpot1") 
		{
			Debug.Log ("placed book1");
			complete.Play ();
			Instantiate (scroll1,scroll1.transform.position ,scroll1.transform.rotation);
		}
		if (_collision.gameObject.name == "bookSpot2") 
		{
			Debug.Log ("placed book2");
			complete.Play ();
			Instantiate (scroll2,scroll2.transform.position ,scroll2.transform.rotation);
		}
		if (_collision.gameObject.name == "bookSpot3") 
		{
			Debug.Log ("placed book3");
			complete.Play ();
			Instantiate (scroll3,scroll3.transform.position ,scroll3.transform.rotation);
		}
		if (_collision.gameObject.name == "bookSpot4") 
		{
			Debug.Log ("placed book3");
			complete.Play ();
			Instantiate (scroll4,scroll4.transform.position ,scroll4.transform.rotation);
		}
	}


}