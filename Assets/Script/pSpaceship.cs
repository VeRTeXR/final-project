using UnityEngine;
using System.Collections;

public class pSpaceship : MonoBehaviour {

	
	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	
	public void Shot (Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}
	

}
