using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMobility_SideScroll : MonoBehaviour {

	public float speed = 3.0f;
	public int maxHP;
	public float playerHP = 20; 
	public float delay = 0.2f;
	public float restartLevelDelay = 0.2f;
	public int enemyCount;
	public GameObject chargeFx;
	public float chargeTime;
	public float degradeTime;
	public GameObject Explosion;
	public float explosionLifetime = 3.0f;
	public AudioClip explosion;
	public GameObject[] special;
	public GameObject[] secondary;
	public GameObject barrier;
	public float chargeFxTime;
	public float slowTimeCountdown;

	public bool isGrounded = false;
	public Transform groundCheck;
	float groundRad = 0.2f;
	public LayerMask whatIsGround;
	public AudioClip shoot;
	private float force = 0.5f;

	public float jumpcd;
	public float jumpHeight = 1.0f;
	public float timeToJumpApex = 5.0f;

	Vector3 velocity;
	public float gravity;
	public float jumpVelocity;
	float accelerationTimeAirborne = .1f;
	float accelerationTimeGrounded = .2f;
	float velocityXSmoothing;

	float targetVelocityX;



    public int gunUpgradeCount ;

    int score;
	pSpaceship2 spaceship;
	

    public Animator animator;
    public Rigidbody2D rigidbody2d;

 
    void Start()
    {
        playerHP = Manager.instance.HP;
        score = Manager.instance.score;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();


		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//Application.LoadLevel (Application.loadedLevel);
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
			
        if (other.gameObject.CompareTag("gunupgrade"))
        {
            gunUpgradeCount += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MaxHpUp"))

        {
            maxHP += 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))

        {
            isGrounded = true;
            velocity.x = 0;
            velocity.y = 0;
            Debug.Log("hit"+isGrounded);
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

	void Update() {

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRad, whatIsGround);

		if(isGrounded)
		{
			velocity.y = 0;
			velocity.x = 0;
		}
		Debug.Log("v:"+velocity);
//		Debug.Log("v:"+velocity);
		//Debug.Log("g"+isGrounded);
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		/*Quaternion roit = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = roit;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		*/

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Vertical"), Input.GetAxisRaw ("Horizontal")); 

		//GetComponent<Rigidbody2D>().velocity = (movement * speed)*(Time.deltaTime);
		//rigidbody2d.velocity = (movement * speed);

		//float targetVelocityX = verticalInput * speed;
		//velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);


		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		//Debug.Log("vInpu:"+verticalInput);
		

		//animator.SetBool("IsATK", true);

		degradeTime += Time.deltaTime;
		//Debug.Log (degradeTime);

		if (Input.GetKeyDown(KeyCode.O)) 
		{
			velocity.x = gravity*Time.deltaTime;
			
			Debug.Log(velocity.x);
			Debug.Log("wut");
		}

		if (Input.GetKeyDown(KeyCode.M)) //&& isGrounded 
		{
			isGrounded = false;
 			velocity.x = -jumpVelocity;
 			Debug.Log("jV:"+jumpVelocity);
 			
 			//jumpcd += Time.deltaTime;
 			//Debug.Log(jumpcd);
 			
		}
	//velocity.x = gravity*Time.deltaTime;
	targetVelocityX = input.y * speed;
	velocity.y = Mathf.SmoothDamp (velocity.y, targetVelocityX, 
	ref velocityXSmoothing, (isGrounded)?accelerationTimeGrounded:accelerationTimeAirborne);
		//velocity.y = input.x * speed;
		

//		Debug.Log("v*t"+velocity*Time.deltaTime);
		transform.Translate (velocity*Time.deltaTime);


		if (degradeTime > 100) {
			//Debug.Log (playerHP);
			FindObjectOfType<BarController>().decresebar();
			playerHP -= 1;
			degradeTime = 0;
		}
        

        if (Time.timeScale==0.7f){
			slowTimeCountdown += Time.deltaTime;
		}

		if (slowTimeCountdown > 3) {
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			Application.Quit();
		}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
        	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Application.LoadLevel(Application.loadedLevel);     //skip lv for dev p
        }

        if(Input.GetKeyDown(KeyCode.E)){
        	//change to alt fire
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
