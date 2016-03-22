using UnityEngine;
using System.Collections;

public class CameraBound : MonoBehaviour {

	private GameObject map;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;


	private float width;
	private float height;
	private Vector3 v3;
	private Transform target;

	void Start ()
	{
		map = GameObject.Find ("CellularAutomata");
		width = map.GetComponent<MapGenerator>().width;
		height = map.GetComponent<MapGenerator>().height;
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		minX = (float)(horzExtent - width/2.0f); 
		maxX = (float)(width/2.0f-horzExtent);
		minY = (float)(vertExtent-height/2.0f);
		maxY = (float)(height/2.0f-vertExtent);

		/*leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
		rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
		bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2.0f);
		topBound = (float)(spriteBounds.sprite.bounds.size.y  / 2.0f - vertExtent);*/
		
	}

	void Update ()
	{
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
