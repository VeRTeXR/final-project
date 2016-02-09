using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


	public static PlayerManager instance = null;

	public Texture2D crosshair;
	public CursorMode cMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;



	// Use this for initialization
	void Awake () {


		Cursor.SetCursor (crosshair, hotSpot, cMode);
	
	}

	
	public void GameOver () {
		// When the game ends, show the title.
		FindObjectOfType<Score> ().Save ();
	
		
	}


}
