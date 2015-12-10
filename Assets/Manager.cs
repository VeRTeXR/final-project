using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public static Manager instance = null;
	public BoardManager boardScript;
	public GameObject player;

	private int level = 3;

	// Title
	private GameObject title;
	public Texture2D crosshair;
	public CursorMode cMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame() {
		boardScript.SetupScene (level);
	}


	void Start ()
	{
		// Search for the Title game object, and save it
		title = GameObject.Find ("Title");
		title.SetActive (false);
		Cursor.SetCursor (crosshair,hotSpot,cMode);
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
		FindObjectOfType<Score> ().Save ();
		title.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		// Determine whether the game is being played by the visibility of the title.
		return title.activeSelf == false;
	}
}
