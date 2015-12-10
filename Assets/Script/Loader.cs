using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (Manager.instance == null) {
			Instantiate(Manager);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
