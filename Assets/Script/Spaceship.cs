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
		//GameObject puller = GameObject.Find ("ObjectPooler_EnemyBullets");
        animator.SetBool("IsATK", true);
        //GameObject obj = puller.GetComponent<ObjectPoolingScript>().GetPooledObject();
        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;
        //obj2.transform.position = 
		Instantiate (bullet, origin.position, origin.rotation);
		//obj.SetActive(true);

	}

	public Animator getAnimator () {
		return animator;
	}



}
