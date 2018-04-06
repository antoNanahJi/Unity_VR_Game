using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigSawPuzzleScript : MonoBehaviour {
	AudioSource aud;
	[SerializeField] PuzzleGameManager manager;
	int count=0;
	void Start()
	{
		aud = this.gameObject.GetComponent<AudioSource> ();
		aud.Pause ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name == this.gameObject.name) {
			count++;
			if (count == 1) {
				other.gameObject.transform.position = transform.position;
				manager.PuzzleNum++;
				aud.Play ();
				Invoke ("KillTaha",0.5f);
			}
		}
	}
	void KillTaha()
	{
		aud.enabled = false;
	}
}
