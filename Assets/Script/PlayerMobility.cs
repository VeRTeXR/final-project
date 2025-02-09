﻿using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {
	
	//public float speedY;
	public float speed;
	public int maxHP = 100;
	public int playerHP ; 
	public float delay = 0.2f;
	private float force = 0.5f;

	public GameObject Explosion;
	public float explosionLifetime = 3.0f;


	int score;
	pSpaceship spaceship;
	float timeSpeedCountdown = Mathf.Infinity;

	public AudioClip shoot;


	IEnumerator attk() {
		yield return new WaitForSeconds(0.1f);
		spaceship = GetComponent<pSpaceship> ();
		spaceship.Shot (transform);
		AudioSource.PlayClipAtPoint(shoot,transform.position);
		StopCoroutine("attk");

				
		}

	public GameObject chargeFx;
	public float chargeTime;

	void Start(){
				playerHP = maxHP;
				}

		

	// Change to Collision cuz trigger is shite 
	void OnTriggerEnter2D (Collider2D c) {

		if (c.gameObject.tag == "Enemy") {

					playerHP -=2;
					FindObjectOfType<BarController> ().decresebar2 ();
					//transform.Translate(-Vector2.up *force*Time.deltaTime);
					Instantiate(Explosion, transform.position, transform.rotation);
					Destroy(c.gameObject);
					
		}				

		if (c.gameObject.tag == "enemyBullet") {
			FindObjectOfType<BarController> ().decresebar ();
			Destroy(c.gameObject);
			playerHP -= 1; 

		}

		/*string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "playerBullet") {
		} else if (layerName == "enemyBullet") {
			playerHP -= 1;
			Destroy (c.gameObject);
			FindObjectOfType<PlayerHp> ().decreaseHp ();
		} else if (layerName == "Enemy") {
			//add explosion
			float force = 10;
			playerHP -= 2;	
			transform.Translate (-Vector2.up * force * Time.deltaTime);
			Destroy (c.gameObject);
			FindObjectOfType<PlayerHp> ().decreaseHp ();
		}*/



		if (c.CompareTag ("Heal")) {


			if (playerHP >= maxHP) {
				playerHP = maxHP;
			}

			playerHP += 5;
			Destroy (c.gameObject);
			FindObjectOfType<BarController> ().increseBar ();

		}

		if (c.CompareTag ("speedUp")) {
			speed += 50;
			Destroy (c.gameObject);
		}

		if (c.CompareTag ("MaxHpUp")) {

			//maxHP += 5;
			Destroy (c.gameObject);

		}
	}

	void FixedUpdate() {
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion roit = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = roit;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0.5f;
		float verticalInput = Input.GetAxis ("Vertical");
		float horizontalInput = Input.GetAxis ("Horizontal"); 
		Vector2 movement = new Vector2 (horizontalInput, verticalInput);
		GetComponent<Rigidbody2D>().velocity = (movement * speed)*(Time.deltaTime);
		
		
		//GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speedY * verticalInput*2*(Time.deltaTime));
		//GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * horizontalInput*2*(Time.deltaTime));
	
		if (Input.GetMouseButton(0)) {
			StartCoroutine ("attk");
			transform.Translate(-Vector2.up *force*Time.deltaTime);

		}
		if (speed > 450) {
			chargeTime += Time.deltaTime;
		}
		if (chargeTime >= 3) {
			speed -= 50;
			chargeTime = 0;
		}

	}



	void OnGUI(){
		
		//GUI.Label (new Rect (10, 280, 200, 60), "HP :  " + playerHP.ToString()); //display hp	
		if (playerHP <= 0) {
			Destroy (this.gameObject);
			FindObjectOfType<PlayerManager> ().GameOver ();
			FindObjectOfType<Spawn> ().CancelInvoke ("Spawner");
			if (Input.GetKeyDown (KeyCode.Q)) {
				Application.LoadLevel(Application.loadedLevel);
				
			}
		}
		}
}
	