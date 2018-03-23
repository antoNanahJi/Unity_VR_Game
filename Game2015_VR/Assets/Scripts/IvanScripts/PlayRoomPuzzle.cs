using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRoomPuzzle : MonoBehaviour {

	static int cubeCount = 0;
	private bool gotYellowCube = false;
	private bool gotRedCube = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YellowPuzzleCube" && !gotYellowCube) 
		{
			this.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			other.gameObject.tag = "Untagged";
			gotYellowCube = true;
			cubeCount++;
		}
		else if (other.gameObject.name == "RedPuzzleCube" && !gotRedCube)
		{
			this.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			other.gameObject.tag = "Untagged";
			gotRedCube = true;
			cubeCount++;
		}

		if(cubeCount >= 2)
		{
			Debug.Log("Cubes placed correctly");
		}

	}
}
