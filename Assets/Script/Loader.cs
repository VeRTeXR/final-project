using UnityEngine;
using System.Collections;

namespace Completed
{
public class Loader : MonoBehaviour {

	public GameObject manager;
	public GameObject playerManager;
	public GameObject title;
	public bool gameOver = false;
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
			gameOver = true;
			
		}
	void Update() {
			if (gameOver) {
				if (Input.GetKeyDown (KeyCode.R)) {
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}

}
}