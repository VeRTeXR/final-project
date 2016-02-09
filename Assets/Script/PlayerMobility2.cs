using UnityEngine;
using System.Collections;

public class PlayerMobility2 : MonoBehaviour {

	// Use this for initialization
	//public float speedY;
	public float speed;
	public int maxHP;
	public float playerHP = 20 ; 
	public float delay = 0.2f;
	public float restartLevelDelay = 0.2f;
	public int enemyCount;
	public GameObject chargeFx;
	public float chargeTime;
	public GameObject Explosion;
	public float explosionLifetime = 3.0f;
	public AudioClip explosion;
	public GameObject barrier;
	public float chargeFxTime;
	public AudioClip shoot;
	
	private float force = 0.5f;

	int score;
	pSpaceship2 spaceship;
	float timeSpeedCountdown = Mathf.Infinity;

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
	
	void Start(){

		playerHP = Manager.instance.HP;

	}

	private void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}

    void OnCollisionEnter2D(Collision2D other)
    {

		if (other.gameObject.tag == "Exit") {

			Invoke ("Restart", restartLevelDelay);
			Manager.instance.HP = playerHP;

		}

        if (other.gameObject.tag == "Enemy") {

            playerHP -= 2;
            FindObjectOfType<BarController>().decresebar2();
            Instantiate(Explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosion, transform.position);

            //Destroy(gameObject);
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
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Application.LoadLevel(Application.loadedLevel);     //skip lv for dev p
        }

        //GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speedY * verticalInput*2*(Time.deltaTime));
        //GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * horizontalInput*2*(Time.deltaTime));

        if (Input.GetMouseButton(0)) {
			StartCoroutine ("attk");
			transform.Translate(-Vector2.up *force*Time.deltaTime);
			
		}

        if (Input.GetMouseButton(1)) {
            float sp = FindObjectOfType<SpBarController>().curSp;
            chargeFxTime += Time.deltaTime;

            if (chargeFxTime >= 2f) {
                if(sp >= 2)
                {
                    StartCoroutine("attk2");
                    transform.Translate(-Vector2.up * force * Time.deltaTime);
                    FindObjectOfType<SpBarController>().decreseBar2();
                }
                

                chargeFxTime = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            float sp = FindObjectOfType<SpBarController>().curSp;
			Instantiate(barrier, this.transform.position, this.transform.rotation);
			FindObjectOfType<SpBarController>().decreseBar();
            /*if(sp >= 5)
            {
                Instantiate(barrier, this.transform.position, this.transform.rotation);
                FindObjectOfType<SpBarController>().decreseBar();
            }*/
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
		
		GUI.Label (new Rect (10, 280, 200, 60), "HP :  " + playerHP.ToString()); //display hp
		GUI.Label(new Rect (10,250,200,60), "Enemy : " + enemyCount.ToString()); //disp enemcount
		if (playerHP <= 0) {
			Destroy(this.gameObject);
			FindObjectOfType<Manager>().GameOver();
			FindObjectOfType<Spawn>().CancelInvoke("Spawner");
			//Application.LoadLevel(Application.loadedLevel);
			GUI.Label (new Rect (10, 100, 200, 60), "PRESS R TO RESTART" );
		}

}
}
