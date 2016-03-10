using UnityEngine;
using System.Collections;


public class PlayerBound : MonoBehaviour {
	
	private float rightBound;
	private float leftBound;
	private float topBound;
	private float bottomBound;
	
	private Vector3 pos;
	private Transform target;
	private SpriteRenderer spriteBounds;
	// Use this for initialization
	void Start ()
	{
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		//spriteBounds = GameObject.Find("Background").GetComponentInChildren<SpriteRenderer>();
		
		target = GameObject.FindWithTag("Player").transform;

		leftBound = (float)(-1.5);
		rightBound = (float)(50);
		bottomBound = (float)(-.4);
		topBound = (float)(19.5);

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
		pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
		pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
		transform.position = pos;
	}
	
	void OnLevelWasLoaded()
	{
		Start();
	}
}
