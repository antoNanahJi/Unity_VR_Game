using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookPuzzle : MonoBehaviour {
	



	void Start()
	{
		

	}
	void OnTriggerEnter(Collider _collision){
		if (_collision.gameObject.tag == "bookSpot") 
		{
			Debug.Log ("placed book");
		}
	



	}
}