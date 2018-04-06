using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	[SerializeField] private Image bloodOverlay;

	// Use this for initialization
	void Start()
	{
		bloodOverlay.canvasRenderer.SetAlpha(0.0f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void BloodSplatter()
	{
		bloodOverlay.canvasRenderer.SetAlpha(1.0f);
		bloodOverlay.CrossFadeAlpha(0.0f, 1.0f, false);
	}
}
