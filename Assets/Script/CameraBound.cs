using UnityEngine;
using System.Collections;

public class CameraBound : MonoBehaviour {

	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private float mapX = 100.00f;
	private float mapY = 20.00f;

	
	private Vector3 v3;
	private Transform target;

	// Use this for initialization
	void Start ()
	{
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		

		target = GameObject.FindWithTag("Player").transform;
		
		minX = (float)(0+3.5);
		maxX = (float)(50-4.7);
		minY = (float)(0+2);
		maxY = (float)(20-4);
		//fuck it 

		/*leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
		rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
		bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2.0f);
		topBound = (float)(spriteBounds.sprite.bounds.size.y  / 2.0f - vertExtent);*/
		
	}
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log();
		
		var v3 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		v3.x = Mathf.Clamp(v3.x, minX, maxX);
		v3.y = Mathf.Clamp(v3.y, minY, maxY);
		transform.position = v3;
	}
	
	void OnLevelWasLoaded()
	{
		Start();
	}
}
