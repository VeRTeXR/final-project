﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 10;
	public int power = 1;
	public float lifeTime = 3; //up lifetime
	
	void OnEnable () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		Invoke("Destroy", lifeTime);
	}

	void OnDisable () {
		CancelInvoke();
	}

	void Destroy () {
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D (Collider2D c) {
		Vector3 bulletdir = this.gameObject.transform.forward;
		bulletdir.y = 0;
		float force = 1000;
		c.gameObject.GetComponent<Rigidbody2D>().AddForce (bulletdir.normalized * force);
	}
}
