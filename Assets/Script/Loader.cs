using UnityEngine;
using System.Collections;

namespace Completed
{
public class Loader : MonoBehaviour {

	public GameObject manager;
	public GameObject playerManager;

	// Use this for initialization
	void Awake () {
			if (Manager.instance==null) {
			Instantiate(manager);

			if (PlayerManager.instance==null) {
					Instantiate(playerManager);
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}