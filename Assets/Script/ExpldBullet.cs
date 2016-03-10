using UnityEngine;
using System.Collections;

public class ExpldBullet : MonoBehaviour {

	public float lifeTime = 0.3f; //up lifetime
	public int speed = 10;
	public GameObject bullet;

	public GameObject[] lilSpawn;

	void Start () {
		int[] strayFactor = new int[6];
		int[] randomNumberZ = new int[6];
		for (int i=0; i<6; i++) {
			strayFactor[i] = Random.Range(1,10);
		}
		for (int i=0; i<6; i++) {
			randomNumberZ[i] = Random.Range(-strayFactor[i], strayFactor[i]);
		}
	
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

		Instantiate (bullet, transform.position, transform.rotation);	

		Instantiate (bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ[0]));
		Instantiate (bullet, lilSpawn[0].transform.position, lilSpawn[0].transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ[1]));
		Instantiate (bullet, lilSpawn[1].transform.position, lilSpawn[1].transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ[2]));
		Instantiate (bullet, lilSpawn[2].transform.position, lilSpawn[2].transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ[3]));
		Instantiate (bullet, lilSpawn[3].transform.position, lilSpawn[3].transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ[4]));
		Instantiate (bullet, lilSpawn[4].transform.position, lilSpawn[4].transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ[5]));

	}

	void OnTriggerEnter2D (Collider2D c) {
		Vector3 bulletdir = this.gameObject.transform.forward;
		bulletdir.y = 0;
		float force = 1000;
		c.gameObject.GetComponent<Rigidbody2D>().AddForce (bulletdir.normalized * force);
	}
}
