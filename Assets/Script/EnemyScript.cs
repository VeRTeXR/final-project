using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed;
	public Transform player;
	public int point = 100;

	Spaceship spaceship;

	IEnumerator Start() {
				spaceship = GetComponent<Spaceship> ();
				
		if (spaceship.canShot == false) {
			yield break;
		}
				while (true) {
						for (int i = 0; i < transform.childCount; i++) {

				Transform shotPos = transform.GetChild(i);
								spaceship.Shot (shotPos);
						}

						yield return new WaitForSeconds (spaceship.shotDelay);
				}

		}


	void FixedUpdate() 
	{	
		player = GameObject.FindWithTag("Player").transform;
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90; 
		transform.eulerAngles = new Vector3 (0, 0, z);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);

		}

	void OnTriggerEnter2D (Collider2D c) {

		Destroy (c.gameObject);
		Destroy (gameObject);
		FindObjectOfType<Score> ().AddPoint (point);

	}
}
