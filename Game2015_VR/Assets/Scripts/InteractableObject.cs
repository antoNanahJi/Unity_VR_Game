using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for interactable objects
public class InteractableObject : MonoBehaviour
{
	// unique identifier tag
	[SerializeField] private string id;

	public string GetId()
	{
		return id;
	}

	// method called on Player script interaction that defines what happens when held object interacts with world object
	// to be overwritten by child classes for individual objects
	// string of object in hand is passed to determine specific interaction outcome
	// return true if held object is to be consumed in interaction
	public virtual bool OnObjectInteract(string id)
	{
		return false;
	}

	// same but for empty hand on world objects
	public virtual bool OnInteract()
	{
		return false;
	}
}
