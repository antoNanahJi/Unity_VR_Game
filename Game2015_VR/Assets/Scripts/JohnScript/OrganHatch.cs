using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganHatch : InteractableObject
{
	private bool isLocked = true;

	override public bool OnObjectInteract(string id)
	{
		if (id == "AquaRegia")
		{
			// unstick hatch with solution
			isLocked = false;
			print("Unstuck the hatch.");
			return true;
		}
		return false;
	}

	override public bool OnInteract()
	{
		if (!isLocked)
		{
			// open hatch
			print("Opened the hatch.");
			return true;
		}
		else
		{
			print("Looks like a maintenence hatch. It's rusted shut.");
			return false;
		}
	}
}
