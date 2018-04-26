using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRoomPuzzle : MonoBehaviour {

	static int cubeCount = 0;
	[SerializeField] GameObject framePicture;
	[SerializeField] GameObject blackFrame;
	[SerializeField] GameObject scroll;

	private bool gotYellowCube = false;
	private bool gotRedCube = false;

	AudioSource aud;
	// Use this for initialization
	void Start () {
		aud = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YellowPuzzleCube" && !gotYellowCube) 
		{
			//this.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			//other.gameObject.tag = "Untagged";
			aud.Play();
			gotYellowCube = true;
			cubeCount++;
		}
		else if (other.gameObject.name == "RedPuzzleCube" && !gotRedCube)
		{
			//this.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			//other.gameObject.tag = "Untagged";
			gotRedCube = true;
			aud.Play();
			cubeCount++;
		}

		if(cubeCount >= 2)
		{
			Debug.Log("Cubes placed correctly");
			blackFrame.SetActive(false);
			framePicture.SetActive(true);
			scroll.SetActive(true);
		}

	}
}
