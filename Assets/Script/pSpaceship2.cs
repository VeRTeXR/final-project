using UnityEngine;
using System.Collections;

public class pSpaceship2 : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
    public GameObject bullet2;
	int strayFactor = 10;

	public GameObject bulletSpawnRight;
	public GameObject bulletSpawnLeft;

    public GameObject bulletSpawnCenter;
    public GameObject bulletSpawnRight2;
    public GameObject bulletSpawnLeft2;

    private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator> ();
	}

	public Animator getAnimator () {
		return animator;
	}

	public void Shot (Transform origin){
		var randomNumberX = Random.Range(-strayFactor, strayFactor);
		var randomNumberY = Random.Range(-strayFactor, strayFactor);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);
		
		//Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
		Instantiate (bullet, bulletSpawnRight.transform.position, bulletSpawnRight.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ));
		Instantiate (bullet, bulletSpawnLeft.transform.position, bulletSpawnLeft.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ));
		bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ); //rotating teh shot
		bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 100*Time.deltaTime);
		
	}

    public void shot2(Transform origin) {

        var randomNumberX = Random.Range(-strayFactor, strayFactor);
        var randomNumberY = Random.Range(-strayFactor, strayFactor);
        var randomNumberZ = Random.Range(-strayFactor, strayFactor);

        Instantiate(bullet2, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
        bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ); //rotating teh shot
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 100);
    }

    public void Shot3(Transform origin)
    {
        var randomNumberX = Random.Range(-strayFactor, strayFactor);
        var randomNumberY = Random.Range(-strayFactor, strayFactor);
        var randomNumberZ = Random.Range(-strayFactor, strayFactor);

        //Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
        Instantiate(bullet, bulletSpawnRight.transform.position, bulletSpawnRight.transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
        Instantiate(bullet, bulletSpawnLeft.transform.position, bulletSpawnLeft.transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));

        Instantiate(bullet, bulletSpawnRight2.transform.position, bulletSpawnRight.transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
        Instantiate(bullet, bulletSpawnLeft2.transform.position, bulletSpawnLeft.transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));

        Instantiate(bullet, bulletSpawnCenter.transform.position, bulletSpawnLeft.transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
        bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ); //rotating teh shot
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 100 * Time.deltaTime);

    }
    
}
