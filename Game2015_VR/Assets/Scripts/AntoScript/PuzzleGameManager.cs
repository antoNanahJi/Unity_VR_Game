using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour {
	public int PuzzleNum=0;
	[SerializeField] GameObject key;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(PuzzleNum==6)
		{
			key.SetActive (true);
		}
	}

}
