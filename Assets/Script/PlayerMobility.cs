using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {
	
	public float speedY;
	public float speed;
	public int playerHP = 10; 

	int score;
	pSpaceship spaceship;
	

	IEnumerator attk() {

				spaceship = GetComponent<pSpaceship> ();

						spaceship.Shot (transform);
						yield return new WaitForSeconds (0);
				
		}
		
	void FixedUpdate() {
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion roit = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = roit;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 1;
			float verticalInput = Input.GetAxis ("Vertical");
			float horizontalInput = Input.GetAxis ("Horizontal"); 
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speedY * verticalInput*2*(Time.deltaTime));
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * horizontalInput*2*(Time.deltaTime));

		if (Input.GetMouseButtonDown(0)) {
					StartCoroutine ("attk");
		}
	}
	
	void OnTriggerEnter2D (Collider2D c) {
		/*if (c.gameObject.tag == "Enemy") {
					playerHP -=2;
					//Destroy(c.gameObject);
		}				
					if (c.gameObject.tag == "enemyBullet") {
			Destroy(c.gameObject);
			playerHP -= 1; 
		}*/
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "playerBullet") {
		}
		else if (layerName == "enemyBullet") {
			playerHP -= 1;
			Destroy (c.gameObject);
			FindObjectOfType<PlayerHp> ().decreaseHp ();
		}
		else if (layerName == "Enemy") {
				//add explosion
				float force = 10;
				playerHP -= 2;	
				transform.Translate (-Vector2.up * force * Time.deltaTime);
				Destroy (c.gameObject);
				FindObjectOfType<PlayerHp> ().decreaseHp ();
			}
		}

	void OnGUI(){
		
		GUI.Label (new Rect (10, 280, 200, 60), "HP :  " + playerHP.ToString()); //display hp	
		if (playerHP < 1) {
					Destroy(this.gameObject);
					FindObjectOfType<Manager>().GameOver();
					FindObjectOfType<Spawn>().CancelInvoke("Spawner");
			//Application.LoadLevel(Application.loadedLevel);
			//GUI.Label (new Rect (10, 100, 200, 60), "PRESS R TO RESTART" );
			}
		if (Input.GetKey (KeyCode.R)) {
					Application.LoadLevel(Application.loadedLevel);
			}
		}
}
	