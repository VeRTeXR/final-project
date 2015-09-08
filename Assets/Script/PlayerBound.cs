﻿using UnityEngine;
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
		
		spriteBounds = GameObject.Find("Background").GetComponentInChildren<SpriteRenderer>();
		
		target = GameObject.FindWithTag("Player").transform;
		
		leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 1.15f);
		rightBound = (float)(spriteBounds.sprite.bounds.size.x / 1.15f - horzExtent);
		bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 1.4f);
		topBound = (float)(spriteBounds.sprite.bounds.size.y / 1.4f - vertExtent);
		
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
