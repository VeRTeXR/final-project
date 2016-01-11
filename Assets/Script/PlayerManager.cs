using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


	public static PlayerManager instance = null;
	private GameObject title;
	public Texture2D crosshair;
	public CursorMode cMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;



	// Use this for initialization
	void Start () {
	
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
		// When not playing, check if the X key is being pressed.
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
			title.SetActive(false);
			
		}
	}

}
