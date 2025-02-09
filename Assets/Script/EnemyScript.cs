﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHP;
	public float speed;
	public Transform player;
	public int point = 100;
	public GameObject Explosion;
	public GameObject ExitTest;
	public float explosionLifetime = 3.0f;
	public int enemyCount;
	
	public AudioClip explosion;

    public GameObject bodyPart;
    public int totalParts = 7;

    Spaceship2 spaceship;

    private Animator animator;


    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
		spaceship = GetComponent<Spaceship2> ();
				
		if (spaceship.canShot == false) 
		{
			yield break;
		}
		while (true) 
			{
				for (int i = 0; i < transform.childCount; i++) 
					{
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
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
			
		if (enemyHP <= 0) {
			
			Instantiate(Explosion, transform.position, transform.rotation);
            OnExplode();
            FindObjectOfType<Score> ().AddPoint (point);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(explosion,transform.position);
		}
	}

	void OnTriggerEnter2D (Collider2D c) {

		if (c.gameObject.CompareTag("playerBullet")) {
            animator.SetBool("IsATKED", true);
			float force = 20;
			enemyHP -= 1;
			transform.Translate(-Vector2.up *force*Time.deltaTime);
			c.gameObject.SetActive(false);
			
            //OnExplode();

        } 

		else { 
			//Destroy (gameObject);
            //OnExplode();

        }

        /*if (enemyHP <= 0) {

            Destroy(this.gameObject);
            OnExplode();

        }*/

		//spaceship.getAnimator().SetTrigger("Damage");
	}

    void OnExplode()
    {
		if (enemyCount == 1) {
           
			Instantiate (ExitTest, transform.position, transform.rotation);	
		}

        for (int i = 0; i < totalParts; i++)
        {
            GameObject b = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-400, 400));
            b.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(-200, 200));
        }
       // Destroy(gameObject);
    }
    public void ResetAnimation()
    {
        animator.SetBool("IsATKED", false);
        animator.SetBool("IsATK", false);
    }
}
