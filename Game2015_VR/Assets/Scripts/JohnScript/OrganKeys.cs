using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganKeys : InteractableObject
{
	private bool isWorking = false;

	override public bool OnInteract()
	{
		if (isWorking)
		{
			print("A haunting melody.");
		}
		else
		{
			print("It makes a muffled sound.");
		}
		return false;
	}

	public void enableKeys()
	{
		isWorking = true;
	}
}
