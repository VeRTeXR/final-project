using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


	public static PlayerManager instance = null;
	public GameObject title;
	public Texture2D crosshair;
	public CursorMode cMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;



	// Use this for initialization
	void Awake () {
		title = GameObject.Find ("Title");
			title.SetActive (false);

		Cursor.SetCursor (crosshair, hotSpot, cMode);
	
	}

	
	public void GameOver () {
		// When the game ends, show the title.
		FindObjectOfType<Score> ().Save ();
		title.SetActive (true);
		
	}

	public bool IsPlaying (){
		// Determine whether the game is being played by the visibility of the title.
		return title.activeSelf == false;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			title.SetActive(false);
		}
	}

}
