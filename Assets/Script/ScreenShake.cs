using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	
	Vector3 originalCameraPosition;
	
	float shakeAmt = 0;
	
	private Camera mainCamera;

	void Start () {
		mainCamera = Camera.main;
	}

	void Update () {
		originalCameraPosition = mainCamera.transform.position;
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		
		shakeAmt = .03f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
		
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
	
}
