using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigSawPuzzleScript : MonoBehaviour {
	AudioSource aud;
	[SerializeField] PuzzleGameManager manager;
	void Start()
	{
		aud = this.gameObject.GetComponent<AudioSource> ();
		aud.Pause ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name == this.gameObject.name) {
			other.gameObject.transform.position = transform.position;
			manager.PuzzleNum++;
			aud.Play ();
		}
	}
}
