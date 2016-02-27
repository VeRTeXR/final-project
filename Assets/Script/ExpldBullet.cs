using UnityEngine;
using System.Collections;

public class ExpldBullet : MonoBehaviour {

	public float lifeTime = 0.3f; //up lifetime
	public int speed = 10;
	public GameObject bullet;

	public GameObject lilSpawn;
	public GameObject lilSpawn2;
	public GameObject lilSpawn3;
	public GameObject lilSpawn4;
	public GameObject lilSpawn5;
	public GameObject lilSpawn6;

	void Start () {
		int strayFactor = Random.Range(1, 10);
		int strayFactor2 = Random.Range(1, 10);
		int strayFactor3 = Random.Range(1, 10);
		int strayFactor4 = Random.Range(1, 10);
		int strayFactor5 = Random.Range(1, 10);
		int strayFactor6 = Random.Range(1, 10);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);
		var randomNumberZ2 = Random.Range(-strayFactor2, strayFactor2);
		var randomNumberZ3 = Random.Range(-strayFactor3, strayFactor3);
		var randomNumberZ4 = Random.Range(-strayFactor4, strayFactor4);
		var randomNumberZ5 = Random.Range(-strayFactor5, strayFactor5);
		var randomNumberZ6 = Random.Range(-strayFactor6, strayFactor6);

		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

		Instantiate (bullet, transform.position, transform.rotation);	

		Instantiate (bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
		Instantiate (bullet, lilSpawn.transform.position, lilSpawn.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ));
		Instantiate (bullet, lilSpawn2.transform.position, lilSpawn2.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ2));
		Instantiate (bullet, lilSpawn3.transform.position, lilSpawn3.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ3));
		Instantiate (bullet, lilSpawn4.transform.position, lilSpawn4.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ4));
		Instantiate (bullet, lilSpawn5.transform.position, lilSpawn5.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ5));

	}

	void OnTriggerEnter2D (Collider2D c) {
		Vector3 bulletdir = this.gameObject.transform.forward;
		bulletdir.y = 0;
		float force = 1000;
		c.gameObject.GetComponent<Rigidbody2D>().AddForce (bulletdir.normalized * force);
	}
}
