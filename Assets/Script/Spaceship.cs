using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
    public Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}


	public void Shot (Transform origin){
        animator.SetBool("IsATK", true);
		Instantiate (bullet, origin.position, origin.rotation);

	}

	public Animator getAnimator () {
		return animator;
	}



}
