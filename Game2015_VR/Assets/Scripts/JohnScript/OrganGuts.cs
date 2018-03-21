using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganGuts : InteractableObject
{
	[SerializeField] GameObject teddyPrefab;
	[SerializeField] OrganKeys organKeys;

	override public bool OnInteract()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		var playerScript = player.GetComponent<Player>();
		var teddy = Instantiate(teddyPrefab, player.transform.position, player.transform.rotation);
		playerScript.PutObjectInHand(teddy);
		organKeys.enableKeys();
		print("There was an old teddy bear clogging the pipes.");
		return true;
	}
}
