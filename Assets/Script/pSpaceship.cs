using UnityEngine;
using System.Collections;

public class pSpaceship : MonoBehaviour {

	
	public float shotDelay;
	public GameObject bullet;
	int strayFactor = 10;
	
	public void Shot (Transform origin){
		var randomNumberX = Random.Range(-strayFactor, strayFactor);
		var randomNumberY = Random.Range(-strayFactor, strayFactor);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);

		Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
		bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ); //rotating teh shot
		bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 100);

	}
	

}
