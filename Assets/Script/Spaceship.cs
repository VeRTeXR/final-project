using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}


	public void Shot (Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);

	}

	public Animator getAnimator () {
		return animator;
	}



}
