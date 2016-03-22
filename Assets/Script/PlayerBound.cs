using UnityEngine;
using System.Collections;


public class PlayerBound : MonoBehaviour {
	
	private GameObject map;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	
	
	private float width;
	private float height;
	private Vector3 pos;
	private Transform target;
	private SpriteRenderer spriteBounds;
	// Use this for initialization
	void Start ()
	{
		map = GameObject.Find ("CellularAutomata");
		width = map.GetComponent<MapGenerator>().width;
		height = map.GetComponent<MapGenerator>().height;
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		//spriteBounds = GameObject.Find("Background").GetComponentInChildren<SpriteRenderer>();
		
		target = GameObject.FindWithTag("Player").transform;

		minX = (float)(horzExtent - width/2.0f)-(6.5f); 
		maxX = (float)(width/2.0f-horzExtent)+(6.5f);
		minY = (float)(vertExtent-height/2.0f)-(2.8f);
		maxY = (float)(height/2.0f-vertExtent)+(2.8f);

		/*leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 1.1f);
		rightBound = (float)(spriteBounds.sprite.bounds.size.x / 1.1f - horzExtent);
		bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 1.35f);
		topBound = (float)(spriteBounds.sprite.bounds.size.y / 1.35f - vertExtent);
		*/
	}
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log();
		
		var pos = new Vector3(target.position.x, target.position.y, transform.position.z);
		pos.x = Mathf.Clamp(pos.x, minX, maxX);
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
	
	void OnLevelWasLoaded()
	{
		Start();
	}
}
