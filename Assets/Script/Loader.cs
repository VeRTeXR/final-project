using UnityEngine;
using System.Collections;

namespace Completed
{
public class Loader : MonoBehaviour {

	public GameObject manager;
	public GameObject playerManager;
	public GameObject title;

	// Use this for initialization
	void Awake () {
			title = GameObject.Find ("Title");

			if (Manager.instance==null) {
			Instantiate(manager);

			if (PlayerManager.instance==null) {
					Instantiate(playerManager);
				}
		}
	}

	public void GameOver () {
			// When the game ends, show the title.
			FindObjectOfType<Score> ().Save ();
			title.SetActive (true);
			
		}
	
	// Update is called once per frame
	void Update () {
			// When not playing, check if the X key is being pressed.
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
	}
}
}