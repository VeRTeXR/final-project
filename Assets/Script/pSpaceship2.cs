using UnityEngine;
using System.Collections;

public class pSpaceship2 : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
	int strayFactor = 3;

	public GameObject bulletSpawnRight;
	public GameObject bulletSpawnLeft;
	
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
}
