using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour {
	public int PuzzleNum=0;
	[SerializeField] GameObject key;
	[SerializeField] Light light;
	// Use this for initialization
	void Start () {
		light.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(PuzzleNum==5)
		{
			key.SetActive (true);
			light.gameObject.SetActive(true);
			Invoke ("DestroyObject",0.5f);
		}
	}
	void DextroyObject()
	{
		light.gameObject.SetActive(false);
	}
}
