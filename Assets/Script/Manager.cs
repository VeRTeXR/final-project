using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	
	public static Manager instance = null; 
	//private Manager managerScript;
	private BoardManager boardScript;
	public GameObject ExitTest;
	public GameObject[] enemy;
	public GameObject player;

	//public GameObject ExitTest;
	public float levelStartDelay = 0.1f;
	public float HP = 20;
	public int level;
	public int score;



	private GameObject levelImage;
	private Text levelText;
	private bool doingSetup = true;

	// Title

	void Start () {
		HP = 20;
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

	void Update () {
		
		if(doingSetup)

			return;

        if (level < 2)
        {
            HP = 20;
        }

        if (levelImage.activeSelf) {
			if (Input.GetKeyDown (KeyCode.R)) {
				level = 0;
				Application.LoadLevel(Application.loadedLevel);  	//	reload will actually reload from beginning
			}
		}
	}

	void HideLevelImage () {
		levelImage.SetActive (false);
		doingSetup = false;
	}



	public void GameOver() {
		FindObjectOfType<Score> ().Save ();
		levelText.text = "After " + level + " you're dead";
		levelImage.SetActive (true);
		



	}

}
