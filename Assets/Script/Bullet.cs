using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 10;
	public int power = 1;
	public float lifeTime = 2;
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}
	


}
