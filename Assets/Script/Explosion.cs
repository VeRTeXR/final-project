using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float lifeTime = 0.3f; //up lifetime
	void Start () {
		Destroy (gameObject, lifeTime);
	}

}