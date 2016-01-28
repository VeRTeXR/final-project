using UnityEngine;
using System.Collections;

public class PlayerMobility2 : MonoBehaviour {

	// Use this for initialization
	//public float speedY;
	public float speed;
	public int maxHP = 100;
	public int playerHP ; 
	public float delay = 0.2f;
	private float force = 0.5f;

	public GameObject Explosion;
	public float explosionLifetime = 3.0f;
	public AudioClip explosion;
	
	int score;
	pSpaceship2 spaceship;
	float timeSpeedCountdown = Mathf.Infinity;
	
	public AudioClip shoot;

    public GameObject baria;

    public float chargeFxTime;


    IEnumerator attk() {
		yield return new WaitForSeconds(0.1f);

			spaceship = GetComponent<pSpaceship2> ();
			spaceship.Shot (transform);
			AudioSource.PlayClipAtPoint (shoot, transform.position);
			StopCoroutine("attk");
			yield return new WaitForSeconds (0.5f);
		
		
	}

    IEnumerator attk2() {

        yield return new WaitForSeconds(0.1f);
        spaceship = GetComponent<pSpaceship2>();
        spaceship.shot2(transform);

        StopCoroutine("attk2");
        yield return new WaitForSeconds(0.5f);


    }
	
	public GameObject chargeFx;
	public float chargeTime;
	
	void Start(){
		playerHP = maxHP;
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerHP -= 2;
            FindObjectOfType<BarController>().decresebar2();
            //Instantiate(Explosion, transform.position, transform.rotation);
            //AudioSource.PlayClipAtPoint(explosion, transform.position);
        }

        if (other.gameObject.tag == "enemyBullet")
        {
            FindObjectOfType<BarController>().decresebar();
            playerHP -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Heal")
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }

            playerHP += 5;
            Destroy(other.gameObject);
            FindObjectOfType<BarController>().increseBar();
        }

        if (other.gameObject.tag == "speedUp")
        {
            speed += 50;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "MaxHpUp")
        {
            maxHP += 5;
            Destroy(other.gameObject);
        }


    }

    void OnTriggerEnter2D (Collider2D c) {
		
		/*if (c.gameObject.tag == "Enemy") {
			
			playerHP -=2;
			FindObjectOfType<BarController> ().decresebar2 ();
			Instantiate(Explosion, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(explosion,transform.position);
			Destroy(c.gameObject);
		
			
		}*/				
		
		/*if (c.gameObject.tag == "enemyBullet") {
			FindObjectOfType<BarController> ().decresebar ();
			Destroy(c.gameObject);
			playerHP -= 1; 
			
		}*/
		
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
		
		
		/*
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
			
			maxHP += 5;
			Destroy (c.gameObject);
			
		}*/
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

        if (Input.GetMouseButton(1)) {

            chargeFxTime += Time.deltaTime;

            if (chargeFxTime >= 2f) {

                StartCoroutine("attk2");
                transform.Translate(-Vector2.up * force * Time.deltaTime);

                chargeFxTime = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            Instantiate(baria, this.transform.position, this.transform.rotation);
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
			Destroy(this.gameObject);
			FindObjectOfType<PlayerManager>().GameOver();
			FindObjectOfType<Spawn>().CancelInvoke("Spawner");
			//Application.LoadLevel(Application.loadedLevel);
			GUI.Label (new Rect (10, 100, 200, 60), "PRESS R TO RESTART" );
		}

}
}
