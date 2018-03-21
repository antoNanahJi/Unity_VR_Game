using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
 GameObject target;
	[SerializeField] float rotationSpeed=45.0f;
	[SerializeField] float movementSpeed=5.0f;
	//Quaternion destRot;
	float speedFactor;

	//Vector3 destVector;
	void Start()
	{
		target = GameObject.FindWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		Vector3 destVector = target.transform.position - transform.position;
		Quaternion destRot = Quaternion.LookRotation (destVector);
		float distTo = destVector.magnitude;
		//transform.rotation = Quaternion.RotateTowards (transform.rotation,destRot,rotationSpeed*Time.deltaTime);
		transform.rotation=Quaternion.LookRotation(destVector);
		speedFactor=(Mathf.Clamp((distTo/10.0f),0.01f,1.0f));
		transform.Translate (Vector3.forward*(speedFactor*movementSpeed*Time.deltaTime));
		Destroy (this.gameObject, 1.0f);
	
	}
}
