using UnityEngine;
using System.Collections;

namespace Completed
{
public class Loader : MonoBehaviour {

	public GameObject gameManager;

	// Use this for initialization
	void Awake () {
		if (Manager.instance == null) {
			Instantiate(gameManager);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}