using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship2 : MonoBehaviour {

	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
    public Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
		
	}


	public void Shot (Transform origin){
		Debug.Log(origin);
        animator.SetBool("IsATK", true);
        GameObject puller = GameObject.Find ("ObjectPooler_EnemyBullets");
        GameObject obj = puller.GetComponent<ObjectPoolingScript>().GetPooledObject();
        obj.transform.position = origin.transform.position;
        obj.transform.rotation = origin.transform.rotation;
		//Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, randomNumberZ));
		//Instantiate (bullet, bulletSpawnRight.transform.position, bulletSpawnRight.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ));
		//Instantiate (bullet, bulletSpawnLeft.transform.position, bulletSpawnLeft.transform.rotation* Quaternion.Euler(0f, 0f, randomNumberZ));
		//obj.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ); //rotating teh shot
        obj.SetActive(true);
	}

	public Animator getAnimator () {
		return animator;
	}



}
