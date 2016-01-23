using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	
	public static Manager instance = null; 
	//private Manager managerScript;
	private BoardManager boardScript;
	public GameObject player;
	public GameObject title;
	public float levelStartDelay = 0.3f;

	private GameObject levelImage;
	private Text levelText;
	private int level;
	private bool doingSetup = true;

	// Title

	void Start () {

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();

	}
	void OnLevelWasLoaded(int index)  {
		level++;
		InitGame ();	
		title = GameObject.Find ("Title");
		title.SetActive(false);
	}


	void InitGame() {
		doingSetup = true;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Dive " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		boardScript.SetupScene (level);
	}

	void HideLevelImage () {
		levelImage.SetActive (false);
		doingSetup = false;
	}

	public void LvTransition () {	

	}

	public void GameOver() {
		FindObjectOfType<Score> ().Save ();
		levelText.text = "After " + level + " your shite is done.";
		levelImage.SetActive (true);

		enabled = false;
	}

}
