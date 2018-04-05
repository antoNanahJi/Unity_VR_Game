using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour {
	Ray mRay;
	RaycastHit mHit;
	[SerializeField] float Distance = 10.0f;


	// Update is called once per frame
	void Update () {
		
		//Input.GetKeyDown(KeyCode.J)
		if (Input.GetMouseButton(1)) {
			mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mRay, out mHit, Distance))
			{
				if(mHit.transform.gameObject.tag=="Door")
					mHit.transform.gameObject.transform.Rotate (0.0f,-50.0f,0.0f);
				
			}

		}
	}
}
