using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
	public bool canShot;

	public void Shot (Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);

	}



}
