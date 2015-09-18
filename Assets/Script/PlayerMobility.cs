using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public GameObject healthBar;

	public float speedY;

	public float speed;
	public int playerHP = 10; 

	int score;
	pSpaceship spaceship;
	float timeSpeedCountdown = Mathf.Infinity;



	IEnumerator attk() {

				spaceship = GetComponent<pSpaceship> ();

						spaceship.Shot (transform);
						yield return new WaitForSeconds (0);
				
		}
		
	void FixedUpdate() 
	{


		////////////////////////////////////////////////////////////////////
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion roit = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = roit;


		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0.5f;
			
			float verticalInput = Input.GetAxis ("Vertical");
			
			float horizontalInput = Input.GetAxis ("Horizontal"); 

		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speedY * verticalInput*2*(Time.deltaTime));
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * horizontalInput*2*(Time.deltaTime));

		if (Input.GetKeyDown(KeyCode.Space)) {
					StartCoroutine ("attk");

		}






	}


	void OnTriggerEnter2D (Collider2D c) {

		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//Transform enemyBulletTransform = transform.parent;
		//Bullet bullet = enemyBulletTransform.GetComponent<Bullet> ();


		if (layerName == "enemyBullet") {
			playerHP -= 1;
			Destroy (c.gameObject);
			FindObjectOfType<PlayerHp>().decreaseHp();

								
						}

	
				
		if (layerName == "Enermy" ) {
			//add explosion

			playerHP -= 1;	
			Destroy(c.gameObject);
			FindObjectOfType<PlayerHp>().decreaseHp();

			//Destroy (gameObject);

			//Application.LoadLevel(Application.loadedLevel);

		}

		if(c.CompareTag ("Heal") ){

			playerHP += 5;
			Destroy(c.gameObject);

		}

		if(c.CompareTag ("speedUp") ){
			
			speedY += 2000;



			Destroy(c.gameObject);


			Debug.Log(speedY);

		}
		if (speedY > 2500) {
			
			timeSpeedCountdown += Time.time + 0.5f;
			
			
			Debug.Log(timeSpeedCountdown);
			
		}
		if(timeSpeedCountdown == 300f){
			
			speedY -= 2000;
			Debug.Log(speedY);
			
		}
		
}

	void TimeCount(){
		
		//timeSpeedCountdown += Time.deltaTime;

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
	