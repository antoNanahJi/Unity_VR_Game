using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
	[SerializeField] GameObject target;
	[SerializeField] float Speed;
	Quaternion destRot;
	float speedFactor;
	float disTo;
	Vector3 destVector;

	// Update is called once per frame
	void Update () {
		destVector = target.transform.position - transform.position;
		destRot = Quaternion.LookRotation (destVector);
		disTo = destVector.magnitude;
		transform.rotation = Quaternion.RotateTowards (transform.rotation,destRot,45.0f*Time.deltaTime);
		speedFactor=(Mathf.Clamp((disTo/5.0f),0.01f,1.0f));
		transform.Translate (Vector3.forward*(speedFactor*Speed*Time.deltaTime));
		Destroy (this.gameObject, 0.5f);
	}
}
