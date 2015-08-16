using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public int playerHP = 5; 
	pSpaceship spaceship;

	IEnumerator attk() {

				spaceship = GetComponent<pSpaceship> ();

						spaceship.Shot (transform);
						yield return new WaitForSeconds (0);
				
		}
		
	void FixedUpdate() 
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion roit = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = roit;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0;
			float verticalInput = Input.GetAxis ("Vertical");
			float horizontalInput = Input.GetAxis ("Horizontal"); 
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed * verticalInput);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * horizontalInput);

		if (Input.GetMouseButtonDown(0)) {
					StartCoroutine ("attk");

		}



	}


	void OnTriggerEnter2D (Collider2D c) {

		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//Transform enemyBulletTransform = transform.parent;
		//Bullet bullet = enemyBulletTransform.GetComponent<Bullet> ();


		if (layerName == "enemyBullet") {

								Destroy (c.gameObject);
								
						}
				
		if (layerName == "Enermy" || layerName == "enemyBullet") {
			//add explosion
				
			//FindObjectOfType<Manager>().GameOver();
				
			Destroy(c.gameObject);
			Destroy (gameObject);

			Application.LoadLevel(Application.loadedLevel);

		}

		
}
}
	