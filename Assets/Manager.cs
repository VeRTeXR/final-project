using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject player;
	
	// Title
	private GameObject title;
	
	void Start ()
	{
		// Search for the Title game object, and save it
		title = GameObject.Find ("Title");
		title.SetActive (false);
	}
	
	void Update ()
	{
		// When not playing, check if the X key is being pressed.
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.R)) {
			GameStart();
		}
	}

	void GameStart ()
	{
				// When it’s time to start the game, hide the title and make the player
				
				Application.LoadLevel (Application.loadedLevel);
		}
	
	public void GameOver ()
	{
		// When the game ends, show the title.
		title.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		// Determine whether the game is being played by the visibility of the title.
		return title.activeSelf == false;
	}
}
