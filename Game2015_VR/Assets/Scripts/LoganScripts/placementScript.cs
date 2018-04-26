using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementScript : MonoBehaviour {
	[SerializeField] GameObject scrollPlaced1;
	[SerializeField] GameObject scrollPlaced2;
	[SerializeField] GameObject scrollPlaced3;
	[SerializeField] GameObject scrollPlaced4;

	static GameObject framePicture;
	static GameObject blackFrame;
	static GameObject scroll;

	private AudioSource complete;
	static int count = 0;
	// Use this for initialization
	void Start () {
		complete = gameObject.GetComponent<AudioSource> ();

		if(framePicture == null)
		{
			framePicture = GameObject.FindWithTag ("LoganPainting");
			blackFrame = GameObject.FindWithTag ("LoganPaintingDark");
			scroll = GameObject.FindWithTag ("LoganScroll");
			framePicture.SetActive(false);
			scroll.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnTriggerEnter(Collider _collision)
	{
		if (_collision.gameObject.name == "placement1") 
		{
			Instantiate (scrollPlaced1,scrollPlaced1.transform.position ,scrollPlaced1.transform.rotation);
			complete.Play ();
			count++;
			checkCount();
			Destroy (gameObject, 0.5f);

		}
		if (_collision.gameObject.name == "placement2") 
		{
			Instantiate (scrollPlaced2,scrollPlaced2.transform.position ,scrollPlaced2.transform.rotation);
			complete.Play ();
			count++;
			checkCount();
			Destroy (gameObject, 0.5f);

		}
		if (_collision.gameObject.name == "placement3") 
		{
			Instantiate (scrollPlaced3,scrollPlaced3.transform.position ,scrollPlaced3.transform.rotation);
			complete.Play ();
			count++;
			checkCount();
			Destroy (gameObject, 0.5f);

		}
		if (_collision.gameObject.name == "placement4") 
		{
			Instantiate (scrollPlaced4,scrollPlaced3.transform.position ,scrollPlaced3.transform.rotation);
			complete.Play ();
			count++;
			checkCount();
			Destroy (gameObject, 0.5f);
		}


	}

	void checkCount()
	{
		if (count >= 4) 
		{
			Debug.Log ("Completed");
			framePicture.SetActive(true);
			scroll.SetActive(true);
			blackFrame.SetActive(false);
		}

	}
}
