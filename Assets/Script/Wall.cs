using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public int wallHp;
	public int randIndex;
	public GameObject wallPieces;


	void OnCollisionEnter2D(Collision2D c){

		if (c.gameObject.tag == "PlayerBullet") {
			wallHp = wallHp - 1;
			if (wallHp <= 0) {
				onContact ();
				Destroy (c.gameObject);
			}
		}
		if (c.gameObject.tag == "EnemyBullet") {
			wallHp = wallHp - 1;
			if (wallHp <= 0) {
				onContact ();
				Destroy (c.gameObject);
			}
		}
		if (c.gameObject.tag == "Player") {
			onContact ();
		}
		if (c.gameObject.tag == "Enemy") {
			onContact ();
		}
	}

	void onContact () {
		randIndex = Random.Range (1,3);
		for (int i = 1; i < randIndex; i++) {
			GameObject b = Instantiate(wallPieces, transform.position, Quaternion.identity) as GameObject;
			b.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-400, 400));
			b.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(-200, 200));
		}
		Destroy (gameObject);
	}


}
