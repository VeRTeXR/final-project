using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHP;
	public float speed;
	public Transform player;
	public int point = 100;
	public GameObject Explosion;
	public float explosionLifetime = 3.0f;

	public AudioClip explosion;

    public GameObject bodyPart;
    public int totalParts = 7;

    Spaceship spaceship;

    public GameObject bodyPart;
    public int totalParts = 7;

    IEnumerator Start() {
				spaceship = GetComponent<Spaceship> ();
				
		if (spaceship.canShot == false) {
			yield break;
		}
				while (true) {
						for (int i = 0; i < transform.childCount; i++) {

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

		if (enemyHP <= 0) {
			
			Instantiate(Explosion, transform.position, transform.rotation);
            OnExplode();
            FindObjectOfType<Score> ().AddPoint (point);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(explosion,transform.position);
            
        }
		}


	//Change to collision 
	void OnTriggerEnter2D (Collider2D c) {


		//Destroy (c.gameObject);
		//Destroy (gameObject);
		//FindObjectOfType<Score> ().AddPoint (point);


		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName == "playerBullet") {
			float force = 20;
			enemyHP -= 1;
			transform.Translate(-Vector2.up *force*Time.deltaTime);
			Destroy (c.gameObject);
            //OnExplode();

        } 
		else { 
			Destroy (gameObject);
            //OnExplode();

        }

        /*if (enemyHP <= 0) {

            Destroy(this.gameObject);
            OnExplode();

        }*/

		spaceship.getAnimator().SetTrigger("Damage");
	}

    void OnExplode()
    {
        for (int i = 0; i < totalParts; i++)
        {
            GameObject b = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-400, 400));
            b.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(-200, 200));
        }
       // Destroy(gameObject);
    }

}
