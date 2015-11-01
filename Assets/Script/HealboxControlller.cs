using UnityEngine;
using System.Collections;

public class HealboxControlller : MonoBehaviour {

	public int count;
	public int speed = 25;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (0, 0, speed*Time.deltaTime));
	
	}

	/*void OntriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Player")) {

			Destroy(gameObject);

		}

	}*/

}
