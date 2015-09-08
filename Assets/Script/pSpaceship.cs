using UnityEngine;
using System.Collections;

public class pSpaceship : MonoBehaviour {

	
	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	int strayFactor = 30;
	
	public void Shot (Transform origin){
		var randomNumberX = Random.Range(-strayFactor, strayFactor);
		var randomNumberY = Random.Range(-strayFactor, strayFactor);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);
		Instantiate(bullet, origin.position, origin.rotation);
		bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
		bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 10000);
		//Instantiate (bullet, origin.position, origin.rotation);
	}
	

}
