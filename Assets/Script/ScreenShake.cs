using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	
	Vector3 originalCameraPosition;
	
	public float shakeAmt;
	Camera mainCamera;

	void Start () {
		mainCamera = Camera.main;
	}

	void Update () {
		originalCameraPosition = mainCamera.transform.position;
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		InvokeRepeating("CameraShake", 0, .5f);
		Invoke("StopShaking", 0.1f);
		
	}

	void OnCollisionEnter2D(Collision2D c) {
		InvokeRepeating("CameraShake", 0, .5f);
		Invoke("StopShaking", 0.1f);
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.x+= quakeAmt;
			pp.y+= quakeAmt/2;// can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
	
}
