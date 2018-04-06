using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour {

	[SerializeField] GameObject Demon;


	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Demon.SetActive(true);
		}			
	}

	void OnTriggerExit(Collider other)
	{
		Demon.SetActive(false);
	}
}
