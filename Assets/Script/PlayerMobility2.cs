using UnityEngine;
using System.Collections;

public class PlayerMobility2 : MonoBehaviour {

	public float speed;
	public int maxHP;
	public float playerHP = 20; 
	public float delay = 0.2f;
	public float restartLevelDelay = 0.2f;
	public int enemyCount;
	public GameObject chargeFx;
	public float chargeTime;
	public GameObject Explosion;
	public float explosionLifetime = 3.0f;
	public AudioClip explosion;
	public GameObject[] special;
	public GameObject[] secondary;
	public GameObject barrier;
	public float chargeFxTime;
	public float slowTimeCountdown;
	public AudioClip shoot;
	private float force = 0.5f;

    public int gunUpgradeCount ;

    int score;
	pSpaceship2 spaceship;
	float timeSpeedCountdown = Mathf.Infinity;

    public Animator animator;

 
    void Start()
    {
        playerHP = Manager.instance.HP;
        score = Manager.instance.score;
        animator = GetComponent<Animator>();
    }

    IEnumerator attk() {
      
		yield return new WaitForSeconds(0.1f);

        
			spaceship = GetComponent<pSpaceship2> ();
			spaceship.Shot (transform);
            if(gunUpgradeCount > 1)
            {
                spaceship.Shot3(transform);
            }
			AudioSource.PlayClipAtPoint (shoot, transform.position);
			StopCoroutine("attk");
			yield return new WaitForSeconds (0.5f);
           
		
		
	}

    IEnumerator attk3()
    {
        
        yield return new WaitForSeconds(0.1f);
    
        spaceship = GetComponent<pSpaceship2>();
        spaceship.Shot3(transform);
        AudioSource.PlayClipAtPoint(shoot, transform.position);
        StopCoroutine("attk3");
        yield return new WaitForSeconds(0.5f);


    }

    IEnumerator attk2() {

        yield return new WaitForSeconds(0.1f);
   
        spaceship = GetComponent<pSpaceship2>();
        spaceship.shot2(transform);

        StopCoroutine("attk2");
        yield return new WaitForSeconds(0.5f);


    }
	


	private void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}

    void OnCollisionEnter2D(Collision2D other)
    {

		if (other.gameObject.CompareTag("Exit")) {
			Invoke ("Restart", restartLevelDelay);
			Manager.instance.HP = playerHP;
			Manager.instance.score = score;
		}

		if (other.gameObject.CompareTag("Enemy")) {

            animator.SetBool("IsATKED", true);
            playerHP -= 2;
            FindObjectOfType<BarController>().decresebar2();
            //Instantiate(Explosion, transform.position, transform.rotation);
            //AudioSource.PlayClipAtPoint(explosion, transform.position);
            //Destroy(gameObject);
        }

		if (other.gameObject.CompareTag("enemyBullet"))
        {
            animator.SetBool("IsATKED", true);
            FindObjectOfType<BarController>().decresebar();
            playerHP -= 1;
            Destroy(other.gameObject);
        }

		if (other.gameObject.CompareTag("Heal"))
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }
            playerHP += 5;
            Destroy(other.gameObject);
            FindObjectOfType<BarController>().increseBar();
        }

		if (other.gameObject.CompareTag("speedUp"))
        {
            speed += 50;
            Destroy(other.gameObject);
        }
			
        if (other.gameObject.tag == "gunupgrade")
        {
            gunUpgradeCount += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "MaxHpUp")

        {
            maxHP += 5;
            Destroy(other.gameObject);
        }

	/*	if (other.gameObject.CompareTag("altChange")) {
			int i = Random.Range (0,secondary.Length);
			//Debug.Log ("i+"+i);
			spaceship.bullet2 = secondary[i];
			Destroy(other.gameObject);
		}*/
		//spaceship.getAnimator().SetTrigger("Damage");

		/*if (other.gameObject.tag == "spChange") {
			int i = Random.Range (0,sec.Length);
			Debug.Log ("i+"+i);
			playermobility2.barriar = sec[i]; // fucking rename this!!
			Destroy(other.gameObject);
		}*/ // use this 2 change special also


    }

	/*				Obsolete Shit 
    void OnTriggerEnter2D (Collider2D c) {
		
		if (c.gameObject.tag == "Enemy") {
			
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
			
		}
	}*/
	
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
		
		animator.SetBool("IsATK", true);
        

        if (Time.timeScale==0.7f){
			slowTimeCountdown += Time.deltaTime;
		}

		if (slowTimeCountdown > 3) {
			Time.timeScale = 1;
		}


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Application.LoadLevel(Application.loadedLevel);     //skip lv for dev p
        }

        if (Input.GetMouseButton(0))
        {
            if (gunUpgradeCount > 1)
            {
                StartCoroutine("attk3");
                transform.Translate(-Vector2.up * force * Time.deltaTime);
            }
            StartCoroutine ("attk");
			transform.Translate(-Vector2.up *force*Time.deltaTime);

        }

        if (Input.GetMouseButton(1))
        {


            animator.SetBool("IsATK", true);
            float sp = FindObjectOfType<SpBarController>().curSp;
            chargeFxTime += Time.deltaTime;
            if (chargeFxTime >= 0.5f) {
                if(sp >= 2)
                {
                    StartCoroutine("attk2");
                    transform.Translate(-Vector2.up * force * Time.deltaTime);
                    FindObjectOfType<SpBarController>().decreseBar2();
					chargeFxTime = 0;
				}
   
            }
        }
      

        if (Input.GetKeyDown(KeyCode.Space))
        {

            float sp = FindObjectOfType<SpBarController>().curSp;
			if(sp >= 5)
            {
				slowTime();
                FindObjectOfType<SpBarController>().decreseBar();
            }
        }

		if (speed > 450)
        {
			chargeTime += Time.deltaTime;
		}

		if (chargeTime >= 3)
        {
			speed -= 50;
			chargeTime = 0;
		}


		
	}

	void slowTime()
    {
		Time.timeScale = 0.7f;
	}

	void armor()
    {
		Instantiate(barrier, this.transform.position, this.transform.rotation);
	}
	
	
	void OnGUI()
    {
		
		//GUI.Label (new Rect (10, 280, 200, 60), "HP :  " + playerHP.ToString()); //display hp
		GUI.Label(new Rect (10,250,200,60), "Enemy : " + enemyCount.ToString()); //disp enemcount
		if (playerHP <= 0) {
			Destroy(this.gameObject);
			FindObjectOfType<Manager>().GameOver();
			FindObjectOfType<Spawn>().CancelInvoke("Spawner");
			//Application.LoadLevel(Application.loadedLevel);
			//GUI.Label (new Rect (10, 100, 200, 60), "PRESS R TO RESTART" );
		}
    }

    public void ResetAnimation()
    {
  
        animator.SetBool("IsATKED", false);
        animator.SetBool("IsATK", false);
    }
    
}
