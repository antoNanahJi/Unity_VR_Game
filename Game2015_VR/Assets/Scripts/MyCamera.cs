using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
	[SerializeField]float speed=1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float newRotationY = transform.localEulerAngles.y + Input.GetAxis ("Mouse X")*speed;
		float newRotationX = transform.localEulerAngles.x - Input.GetAxis ("Mouse Y")*speed;
		this.gameObject.transform.localEulerAngles = new Vector3 (newRotationX,newRotationY,0.0f);
	}
}
